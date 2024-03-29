using ConsoleApp.Models;

namespace ConsoleApp.Repositories
{
    public interface IRepository
    {
        int SaveSpeaker(Speaker speaker);
    }
}