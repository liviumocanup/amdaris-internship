using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.Exceptions;
using ConsoleApp.Validators;

namespace ConsoleApp.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository _repository;
        private readonly ISpeakerValidationService _speakerValidationService;
        private readonly IFeeService _feeService;

        public SpeakerService(IRepository repository, ISpeakerValidationService speakerValidationService, IFeeService feeService)
        {
            _repository = repository;
            _speakerValidationService = speakerValidationService;
            _feeService = feeService;
        }

        public int? Register(Speaker speaker)
        {
            _speakerValidationService.ValidateSpeaker(speaker);

            _speakerValidationService.ValidateQualifications(speaker);

            _speakerValidationService.ValidateSessions(speaker);

            speaker.RegistrationFee = _feeService.CalculateFee(speaker.ExperienceYears);

            return SaveSpeaker(speaker);
        }

        private int? SaveSpeaker(Speaker speaker)
        {
            return _repository.SaveSpeaker(speaker);
        }
    }
}