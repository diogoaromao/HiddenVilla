using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
			
		}

		public DbSet<HotelRoom> HotelRooms { get; set; }
	}
}
