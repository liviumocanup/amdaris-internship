using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Validators
{
    public class QualificationValidator : IValidator
    {
        private const int RequiredExperienceYears = 10;
        private const int RequiredCertifications = 3;
        private const int RequiredBrowserVersion = 9;
        private readonly List<string> _domains = new List<string> { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
        private readonly List<string> _preferredEmployers = new List<string> { "Microsoft", "Google", "Fog Creek Software", "37Signals" };

        public bool IsValid(Speaker speaker)
        {
            return HasSufficientExperienceOrCertifications(speaker) ||
                   IsPreferredEmployer(speaker) ||
                   (IsUsingModernBrowser(speaker) && !IsUsingRestrictedEmailDomain(speaker));
        }

        private static bool HasSufficientExperienceOrCertifications(Speaker speaker)
        {
            return speaker.ExperienceYears > RequiredExperienceYears ||
                   speaker.HasBlog ||
                   speaker.Certifications.Count > RequiredCertifications;
        }

        private bool IsPreferredEmployer(Speaker speaker)
        {
            return _preferredEmployers.Contains(speaker.Employer);
        }

        private static bool IsUsingModernBrowser(Speaker speaker)
        {
            return speaker.Browser.Name != WebBrowser.BrowserName.InternetExplorer ||
                   speaker.Browser.MajorVersion >= RequiredBrowserVersion;
        }

        private bool IsUsingRestrictedEmailDomain(Speaker speaker)
        {
            var emailDomain = speaker.Email.Split('@');
            var domain = emailDomain[emailDomain.Length - 1];
            return _domains.Contains(domain);
        }
    }
}
