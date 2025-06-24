using Feedback.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Data
{
    public class FeedbackContext: DbContext
    {
        public DbSet<Data.Entities.Feedback> Feedback { get; set; }

        public FeedbackContext(DbContextOptions<FeedbackContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedbackEntity>().HasKey(_ => _.Id);
            modelBuilder.Entity<FeedbackEntity>().Property(_ => _.UserId).IsRequired();
            modelBuilder.Entity<FeedbackEntity>().Property(_ => _.ModuleId).IsRequired();
            modelBuilder.Entity<FeedbackEntity>().Property(_ => _.Rating).IsRequired();
            modelBuilder.Entity<FeedbackEntity>().ToTable(_=>_.HasCheckConstraint("CK_Feedback_Rating", "[Rating] BETWEEN 1 AND 5"));
            modelBuilder.Entity<FeedbackEntity>().Property(_ => _.PublishDate).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<FeedbackEntity>().HasData(new List<FeedbackEntity>()
            {
                new FeedbackEntity(){ Id=1, Comment="Lorem ipsum dolor sit amet.", Rating=1, ModuleId=1, UserId=1 },
                new FeedbackEntity(){ Id=2, Comment="Lorem ipsum.", Rating=1, ModuleId=2, UserId=2 },
                new FeedbackEntity(){ Id=3, Rating=4, ModuleId=1, UserId=2 },
                new FeedbackEntity(){ Id=4, Rating=5, ModuleId=2, UserId=3 },
                new FeedbackEntity(){ Id=5, Comment="Lorem ipsum dolor sit amet consectetur adipiscing elit quisque faucibus ex sapien vitae pellentesque sem.", Rating=2, ModuleId=1, UserId=4 }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
