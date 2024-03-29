using ConsoleApp.Services;

namespace ConsoleApp.Models
{
    public class Speaker
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int? ExperienceYears { get; set; } // Renamed for clarity
        public bool HasBlog { get; set; }
        public string? BlogURL { get; set; }
        public WebBrowser Browser { get; set; } = default!;
        public List<string> Certifications { get; set; }
        public string Employer { get; set; } = "";
        public int RegistrationFee { get; set; }
        public List<Session> Sessions { get; set; }

        public Speaker()
        {
            Certifications = new List<string>();
            Sessions = new List<Session>();
        }

        public Speaker(string firstName, string lastName, string email, string employer)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Employer = employer;
            Certifications = new List<string>();
            Sessions = new List<Session>();
        }


    }
}