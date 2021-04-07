namespace HospitalBookingSystemApi.Services
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IImageService
    {
        Task<string> UploadAsync(byte[] imageData);

        Task<string> UploadAsync(MemoryStream imageStream);
    }
}
