namespace HandwrittenTextRecognitionSystem.Services
{
    public interface IImageService
    {
        public Task CreateImageAsync(string userId, IFormFile image);
    }
}
