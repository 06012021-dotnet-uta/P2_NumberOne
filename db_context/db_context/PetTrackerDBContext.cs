using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace data_models
{
    public partial class PetTrackerDBContext : DbContext
    {
        public PetTrackerDBContext()
        {
        }

        public PetTrackerDBContext(DbContextOptions<PetTrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AggressionCode> AggressionCodes { get; set; }
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coloration> Colorations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<ForumImg> ForumImgs { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetDescriptor> PetDescriptors { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostImage> PostImages { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:pettrackerapp.database.windows.net,1433;Initial Catalog=PetTrackerDB;Persist Security Info=False;User ID=group1;Password=admin123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AggressionCode>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_AGGRESSION");

                entity.ToTable("AggressionCode");

                entity.Property(e => e.Descriptor)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.ToTable("Breed");

                entity.Property(e => e.BreedId).HasColumnName("BreedID");

                entity.Property(e => e.Breed1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Breed");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Breeds)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGORYID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Coloration>(entity =>
            {
                entity.ToTable("Coloration");

                entity.Property(e => e.ColorationId).HasColumnName("ColorationID");

                entity.Property(e => e.Color1)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Color2).HasMaxLength(20);

                entity.Property(e => e.Pattern).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.UserName, "UQ__Customer__C9F284562E869C99")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AccountCreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.ToTable("Forum");

                entity.Property(e => e.ForumId).HasColumnName("ForumID");

                entity.Property(e => e.Descriptor).HasMaxLength(1000);

                entity.Property(e => e.ForumName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PetId).HasColumnName("PetID");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Forums)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PETID");
            });

            modelBuilder.Entity<ForumImg>(entity =>
            {
                entity.HasKey(e => e.ImgId)
                    .HasName("PK_FORUM_IMG");

                entity.ToTable("ForumImg");

                entity.Property(e => e.ImgId).HasColumnName("ImgID");

                entity.Property(e => e.ForumId).HasColumnName("ForumID");

                entity.Property(e => e.ImgPath)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.ForumImgs)
                    .HasForeignKey(d => d.ForumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FORUM");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Gender");

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Gender");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.PetId).HasColumnName("PetID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.HasOne(d => d.AggressionCodeNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.AggressionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AGGRESSION");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGORY");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENDER");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OWNER");
            });

            modelBuilder.Entity<PetDescriptor>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BreedId).HasColumnName("BreedID");

                entity.Property(e => e.ColorationId).HasColumnName("ColorationID");

                entity.Property(e => e.PetId).HasColumnName("PetID");

                entity.HasOne(d => d.Breed)
                    .WithMany()
                    .HasForeignKey(d => d.BreedId)
                    .HasConstraintName("FK_Breed");

                entity.HasOne(d => d.Coloration)
                    .WithMany()
                    .HasForeignKey(d => d.ColorationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coloration");

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PET");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.ForumId).HasColumnName("ForumID");

                entity.Property(e => e.PostTime).HasColumnType("datetime");

                entity.Property(e => e.PosterId).HasColumnName("PosterID");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.TextBody).HasMaxLength(1000);

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ForumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FORUMID");

                entity.HasOne(d => d.Poster)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PosterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSTERID");

                entity.HasOne(d => d.Reply)
                    .WithMany(p => p.InverseReply)
                    .HasForeignKey(d => d.ReplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REPLYID");
            });

            modelBuilder.Entity<PostImage>(entity =>
            {
                entity.HasKey(e => e.ImgId)
                    .HasName("PK_POST_IMG");

                entity.ToTable("PostImage");

                entity.Property(e => e.ImgId).HasColumnName("ImgID");

                entity.Property(e => e.ImgPath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostImages)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSTID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
