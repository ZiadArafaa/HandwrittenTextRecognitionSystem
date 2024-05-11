using HandwrittenTextRecognitionSystem.Dtos;
using HandwrittenTextRecognitionSystem.Models;

namespace HandwrittenTextRecognitionSystem.Services
{
    public interface IAuthenticationService
    {
        public Task<AuthorizedDto> LoginAsync(ApplicationUser user);
    }
}
