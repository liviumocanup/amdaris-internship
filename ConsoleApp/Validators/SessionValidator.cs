using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Validators
{
    public class SessionValidator : IValidator
    {
        private readonly List<string> _outdatedTechnologies = new List<string> { "Cobol", "Punch Cards", "Commodore", "VBScript" };

        public bool IsValid(Speaker speaker)
        {
            List<Session> sessions = speaker.Sessions;
            if (sessions.Count == 0)
            {
                throw new ArgumentException("Can't register speaker with no sessions to present.");
            }

            bool anyApproved = false;
            foreach (var session in sessions)
            {
                if (_outdatedTechnologies.Exists(tech => session.Title.Contains(tech) || session.Description.Contains(tech)))
                {
                    session.Approved = false;
                }
                else
                {
                    session.Approved = true;
                    anyApproved = true;
                }
            }
            return anyApproved;
        }
    }
}