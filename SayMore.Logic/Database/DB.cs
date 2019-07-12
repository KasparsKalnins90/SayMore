namespace SayMore.Logic.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB2")
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Questions)
                .HasForeignKey(e => e.QuestionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Questions)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }
    }
}
