using KuceZBronksuWebApi.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace KuceZBronksuWebApi.DAL.Context
{
	public class APIDbContext : DbContext
	{
		public APIDbContext(DbContextOptions<APIDbContext> options)
		{
		}

		public DbSet<Raport> Raports { get; set; }

		//protected override void OnCofiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Ex9;TrustServerCertificate=True;Integrated Security=true;", b => b.MigrationsAssembly("KuceZBronksuAPI"));
		//}
	}
}
