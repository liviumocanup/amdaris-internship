using ConsoleApp.Models;

namespace ConsoleApp.Repositories
{
	public class SqlServerCompactRepository : IRepository
	{
		public int SaveSpeaker(Speaker speaker)
		{
			return 1;
		}
	}
}