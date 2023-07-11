using Microsoft.EntityFrameworkCore;

namespace TrainComponentManagement.Models
{
    public class TrainComponentContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TrainComponentContext(DbContextOptions<TrainComponentContext> options): base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public DbSet<TrainComponent> TrainComponents { get; set; }
        public DbSet<ComponentHierarchy> ComponentHierarchies { get; set; }

        public DbSet<TrainComponentQuantityAssignment> TrainComponentQuantityAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainComponent>()
                .HasKey(tc => tc.ID);

            modelBuilder.Entity<TrainComponentQuantityAssignment>()
                .HasKey(tc => tc.ID);

            modelBuilder.Entity<ComponentHierarchy>()
                .HasKey(ch => new { ch.ParentComponentID, ch.ChildComponentID });

            modelBuilder.Entity<ComponentHierarchy>()
                .HasOne(ch => ch.ParentComponent)
                .WithMany()
                .HasForeignKey(ch => ch.ParentComponentID)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<ComponentHierarchy>()
                .HasOne(ch => ch.ChildComponent)
                .WithMany()
                .HasForeignKey(ch => ch.ChildComponentID)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<TrainComponentQuantityAssignment>()
                .HasOne(ch => ch.TrainComponent)
                .WithMany()
                .HasForeignKey(ch => ch.TrainComponentID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
