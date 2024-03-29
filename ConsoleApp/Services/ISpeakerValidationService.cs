using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    public interface ISpeakerValidationService
    {
        bool ValidateSpeaker(Speaker speaker);
        bool ValidateSessions(Speaker speaker);
        bool ValidateQualifications(Speaker speaker);
    }
}