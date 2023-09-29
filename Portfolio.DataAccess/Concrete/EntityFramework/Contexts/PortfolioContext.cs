using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Portfolio.Core.Entities.Abstract;
using Portfolio.DataAccess.Concrete.EntityFramework.TrackingServices;
using Portfolio.Entities.Concrete;
using System.Reflection;

namespace Portfolio.DataAccess.Concrete.EntityFramework.Contexts
{
    public class PortfolioContext : DbContext
    {
        private readonly EntityChangeTrackingService _changeTrackingService;

        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
            _changeTrackingService = new EntityChangeTrackingService(this);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity<int>>())
            {
                _changeTrackingService.TrackEntityChanges(entry.Entity);
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Introduce> Introduces { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuHeader> MenuHeaders { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}