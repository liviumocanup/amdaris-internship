using ConsoleApp.Models;
using ConsoleApp.Exceptions;
using ConsoleApp.Validators;

namespace ConsoleApp.Services
{
    public class SpeakerValidationService : ISpeakerValidationService
    {
        private readonly IValidator _speakerValidator, _sessionValidator, _qualificationValidator;

        public SpeakerValidationService(IValidator speakerValidator, IValidator sessionValidator, IValidator qualificationValidator)
        {
            _speakerValidator = speakerValidator;
            _sessionValidator = sessionValidator;
            _qualificationValidator = qualificationValidator;
        }

        public bool ValidateSpeaker(Speaker speaker)
        {
            return _speakerValidator.IsValid(speaker);
        }

        public bool ValidateSessions(Speaker speaker)
        {
            bool sessionsApproved = _sessionValidator.IsValid(speaker);
            if (!sessionsApproved)
            {
                throw new SessionsNotApprovedException("No sessions approved.");
            }
            return sessionsApproved;
        }

        public bool ValidateQualifications(Speaker speaker)
        {
            bool isQualified = _qualificationValidator.IsValid(speaker);
            if (!isQualified)
            {
                throw new SpeakerRequirementsNotMetException("Speaker doesn't meet our abitrary and capricious standards.");
            }
            return isQualified;
        }
    }
}