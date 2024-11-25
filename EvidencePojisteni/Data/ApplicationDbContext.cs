using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteni.Models;

namespace EvidencePojisteni.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	    public DbSet<EvidencePojisteni.Models.InsuredUser> InsuredUser { get; set; } = default!;
	    public DbSet<EvidencePojisteni.Models.Insurance> Insurance { get; set; } = default!;
	}
}
