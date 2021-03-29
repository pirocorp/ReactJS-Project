namespace HospitalBookingSystemApi.Services.Implementations
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;

        public ImageService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        /// <summary>
        /// Uploads image to the Cloudinary.
        /// </summary>
        /// <param name="imageData">Image as byte array.</param>
        /// <returns>Url for the image.</returns>
        public async Task<string> UploadAsync(byte[] imageData)
        {
            await using var destinationStream = new MemoryStream(imageData);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), destinationStream),
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);

            return result.SecureUrl.AbsolutePath;
        }
    }
}
