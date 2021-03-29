namespace HospitalBookingSystemApi.Services
{
    using System.Threading.Tasks;

    public interface IImageService
    {
        Task<string> UploadAsync(byte[] imageData);
    }
}
