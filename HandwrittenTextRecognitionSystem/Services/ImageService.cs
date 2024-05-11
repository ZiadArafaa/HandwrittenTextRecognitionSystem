using Microsoft.AspNetCore.Hosting;

namespace HandwrittenTextRecognitionSystem.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task CreateImageAsync(string userId, IFormFile image)
        {
            var imageName = $"{userId}.jpg";
            var path = $"{_webHostEnvironment.WebRootPath}/images/users/{imageName}";

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            using var imageStream = image.OpenReadStream();
            using var stream = System.IO.File.Create(path);
            await imageStream.CopyToAsync(stream);
        }
    }
}
