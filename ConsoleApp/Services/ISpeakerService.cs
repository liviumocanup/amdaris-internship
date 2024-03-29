using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    public interface ISpeakerService
    {
        int? Register(Speaker speaker);
    }
}