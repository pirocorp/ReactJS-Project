namespace HospitalBookingSystemApi.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class DoctorsSeeder : ISeeder
    {
        public async Task SeedAsync(HospitalBookingSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Doctors.AnyAsync())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var imageService = serviceProvider.GetRequiredService<IImageService>();

            var doctors = new List<DoctorModel>()
            {
                new DoctorModel()
                {
                    FirstName = "Ruby",
                    LastName = "Perrin",
                    Education = "MDS - Periodontology and Oral Implantology, BDS",
                    ImagePath = "doctor-01.jpg",
                    Username = "doctor01",
                    Password = "123456",
                    WorkEmail = "doctor01@example.com",
                    WorkPhone = "+01 555 000 111",
                    Specializations = new List<string> { "Dentist" },
                },
                new DoctorModel()
                {
                    FirstName = "Darren",
                    LastName = "Elder",
                    Education = "BDS, MDS - Oral &amp; Maxillofacial Surgery",
                    ImagePath = "doctor-02.jpg",
                    Username = "doctor02",
                    Password = "123456",
                    WorkEmail = "doctor02@example.com",
                    WorkPhone = "+01 555 000 222",
                    Specializations = new List<string> { "Dentist", "Surgeon" },
                },
                new DoctorModel()
                {
                    FirstName = "Deborah",
                    LastName = "Angel",
                    Education = "MBBS, MD - General Medicine, DNB - Cardiology",
                    ImagePath = "doctor-03.jpg",
                    Username = "doctor03",
                    Password = "123456",
                    WorkEmail = "doctor03@example.com",
                    WorkPhone = "+01 555 000 333",
                    Specializations = new List<string> { "GP", "Cardiologist" },
                },
                new DoctorModel()
                {
                    FirstName = "Sofia",
                    LastName = "Brient",
                    Education = "MBBS, MS - General Surgery, MCh - Urology",
                    ImagePath = "doctor-04.jpg",
                    Username = "doctor04",
                    Password = "123456",
                    WorkEmail = "doctor04@example.com",
                    WorkPhone = "+01 555 000 444",
                    Specializations = new List<string> { "Surgeon", "Urology" },
                },
                new DoctorModel()
                {
                    FirstName = "Marvin",
                    LastName = "Campbell",
                    Education = "MBBS, MD - Ophthalmology, DNB - Ophthalmology",
                    ImagePath = "doctor-05.jpg",
                    Username = "doctor05",
                    Password = "123456",
                    WorkEmail = "doctor05@example.com",
                    WorkPhone = "+01 555 000 555",
                    Specializations = new List<string> { "Ophthalmology" },
                },
                new DoctorModel()
                {
                    FirstName = "Katharine",
                    LastName = "Berthold",
                    Education = "MS - Orthopaedics, MBBS, M.Ch - Orthopaedics",
                    ImagePath = "doctor-06.jpg",
                    Username = "doctor06",
                    Password = "123456",
                    WorkEmail = "doctor06@example.com",
                    WorkPhone = "+01 555 000 666",
                    Specializations = new List<string> { "Orthopedic" },
                },
                new DoctorModel()
                {
                    FirstName = "Linda",
                    LastName = "Tobin",
                    Education = "MBBS, MD - General Medicine, DM - Neurology",
                    ImagePath = "doctor-07.jpg",
                    Username = "doctor07",
                    Password = "123456",
                    WorkEmail = "doctor07@example.com",
                    WorkPhone = "+01 555 000 777",
                    Specializations = new List<string> { "GP", "Neurology" },
                },
                new DoctorModel()
                {
                    FirstName = "Paul",
                    LastName = "Richard",
                    Education = "MBBS, MD - Dermatology &amp; Lepros",
                    ImagePath = "doctor-08.jpg",
                    Username = "doctor08",
                    Password = "123456",
                    WorkEmail = "doctor08@example.com",
                    WorkPhone = "+01 555 000 888",
                    Specializations = new List<string> { "Dermatology", },
                },
                new DoctorModel()
                {
                    FirstName = "Max",
                    LastName = "Pain",
                    Education = "MBBS, MD - Neurology",
                    ImagePath = "doctor-09.jpg",
                    Username = "doctor09",
                    Password = "123456",
                    WorkEmail = "doctor09@example.com",
                    WorkPhone = "+01 555 000 999",
                    Specializations = new List<string> { "Neurology", },
                },
                new DoctorModel()
                {
                    FirstName = "Eveline",
                    LastName = "Henry",
                    Education = "MBBS, MD - General Medicine",
                    ImagePath = "doctor-10.jpg",
                    Username = "doctor10",
                    Password = "123456",
                    WorkEmail = "doctor10@example.com",
                    WorkPhone = "+01 555 111 000",
                    Specializations = new List<string> { "GP", },
                },
                new DoctorModel()
                {
                    FirstName = "Eveline",
                    LastName = "Henry",
                    Education = "MBBS, MD - General Medicine, MBBS - Pediatry",
                    ImagePath = "doctor-11.jpg",
                    Username = "doctor11",
                    Password = "123456",
                    WorkEmail = "doctor11@example.com",
                    WorkPhone = "+01 555 111 111",
                    Specializations = new List<string> { "GP", "Family" },
                },
                new DoctorModel()
                {
                    FirstName = "Richard",
                    LastName = "Gen",
                    Education = "MBBS, MD - General Medicine, MBBS - Pediatry",
                    ImagePath = "doctor-12.jpg",
                    Username = "doctor12",
                    Password = "123456",
                    WorkEmail = "doctor12@example.com",
                    WorkPhone = "+01 555 111 222",
                    Specializations = new List<string> { "GP", "Urology", "Surgeon" },
                },
            };

            foreach (var doctor in doctors)
            {
                await SeedDoctor(dbContext, userManager, imageService, doctor);
            }
        }

        private static async Task SeedDoctor(HospitalBookingSystemDbContext dbContext, UserManager<User> userManager, IImageService imageService, DoctorModel model)
        {
            var imageContent = await File.ReadAllBytesAsync($"../../img/{model.ImagePath}");

            var imageUrl = GlobalConstants.CloudinaryResourceBaseAddress + await imageService.UploadAsync(imageContent);

            var user = new User()
            {
                UserName = model.Username,
                Email = model.WorkEmail,
            };

            await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, GlobalConstants.RolesNames.Doctor);

            var doctor = new Doctor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                WorkEmail = model.WorkEmail,
                WorkPhone = model.WorkPhone,
                ImageUrl = imageUrl,
                Education = model.Education,

                UserId = user.Id,
            };

            await dbContext.Doctors.AddAsync(doctor);
            await dbContext.SaveChangesAsync();

            var specializations = new List<DoctorSpecialization>();

            foreach (var specialization in model.Specializations)
            {
                var spec = await dbContext.Specializations.FirstOrDefaultAsync(s => s.Name.Equals(specialization));

                var doctorSpec = new DoctorSpecialization()
                {
                    DoctorId = doctor.Id,
                    SpecializationId = spec.Id,
                };

                specializations.Add(doctorSpec);
            }

            await dbContext.DoctorsSpecializations.AddRangeAsync(specializations);
            await dbContext.SaveChangesAsync();
        }

        private class DoctorModel
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string WorkEmail { get; set; }

            public string WorkPhone { get; set; }

            public string Education { get; set; }

            public string ImagePath { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public List<string> Specializations { get; set; }
        }
    }
}
