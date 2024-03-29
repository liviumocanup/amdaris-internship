using ConsoleApp.Models;

namespace ConsoleApp.Repositories
{
	public class SqlServerCompactRepository : IRepository
	{
		public int SaveSpeaker(Speaker speaker)
		{
			//TODO: Save speaker to DB for now. For demo, just assume success and return 1.
			return 1;
		}
	}
}