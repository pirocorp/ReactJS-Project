namespace HospitalBookingSystemApi.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Data.Common.Models;
    using HospitalBookingSystemApi.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class HospitalBookingSystemDbContext : IdentityDbContext<User, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(HospitalBookingSystemDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public HospitalBookingSystemDbContext(DbContextOptions<HospitalBookingSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<DoctorShift> DoctorsShifts { get; set; }

        public DbSet<DoctorSpecialization> DoctorsSpecializations { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Slot> Slots { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        /// <see cref="SaveChanges(bool)"/>
        public override int SaveChanges() => this.SaveChanges(true);

        /// <summary>
        /// Overrides default method adding auto auditing rules.
        /// </summary>
        /// <remarks>
        /// Automatically adjust CreatedOn and ModifiedOn properties.
        /// </remarks>
        /// <param name="acceptAllChangesOnSuccess">Default implementation.</param>
        /// <returns></returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <see cref="SaveChangesAsync(bool, CancellationToken)"/>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        /// <summary>
        /// Overrides default method adding auto auditing rules.
        /// </summary>
        /// <remarks>
        /// Automatically adjust CreatedOn and ModifiedOn properties.
        /// </remarks>
        /// <param name="acceptAllChangesOnSuccess">Default implementation.</param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// This method is invoked by EF Core to apply EF Core configurations.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            AppliesEntitiesConfigurations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));

            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod
                    .MakeGenericMethod(deletableEntityType.ClrType);

                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        /// <summary>
        /// Filter only none deleted entities. When entity is IDeletableEntity.
        /// </summary>
        /// <remarks>Applies EF Core Global filter.</remarks>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="builder">Model builder for configuring filter.</param>
        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        /// <summary>
        /// Applies all entity configurations which implements IEntityTypeConfiguration.
        /// </summary>
        /// <param name="builder">ModelBuilder.</param>
        private static void AppliesEntitiesConfigurations(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(typeof(User).Assembly);

        /// <summary>
        /// Modifies CreatedOn ModifiedOn properties if entity implements IAuditInfo.
        /// </summary>
        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
