using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.Services;
using ConsoleApp.Validators;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRepository repository = new SqlServerCompactRepository();
            IFeeService feeService = new FeeService();
            IValidator speakerValidator = new SpeakerValidator();
            IValidator sessionValidator = new SessionValidator();
            IValidator qualificationValidator = new QualificationValidator();
            ISpeakerValidationService speakerValidationService = new SpeakerValidationService(speakerValidator, sessionValidator, qualificationValidator);

            WebBrowser browser = new WebBrowser("IE", 9);
            Speaker speaker = new Speaker("John", "Doe", "jd@gmail.com", "Google");

            speaker.Certifications.Add("C#");
            speaker.Sessions.Add(new Session("C# 101", "Introduction to C#"));
            speaker.Browser = browser;

            ISpeakerService speakerService = new SpeakerService(repository, speakerValidationService, feeService);

            int? id = speakerService.Register(speaker);

            Console.WriteLine($"Speaker {id} registered successfully.");
        }
    }
}