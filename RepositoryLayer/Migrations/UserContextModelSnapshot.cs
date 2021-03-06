// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer.Context;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepositoryLayer.Entity.Collaboration", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CollaborationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("Collaborations");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Label", b =>
                {
                    b.Property<int>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("LabelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LabelId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddReminder")
                        .HasColumnType("datetime2");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNote")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrash")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddReminder = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Color = "White",
                            CreatedDate = new DateTime(2021, 10, 5, 23, 7, 3, 826, DateTimeKind.Local).AddTicks(7254),
                            Image = "abc.jpg",
                            IsArchive = false,
                            IsNote = true,
                            IsPin = false,
                            IsTrash = false,
                            Message = "Hello, this is my new note",
                            ModifiedDate = new DateTime(2021, 10, 5, 23, 7, 3, 828, DateTimeKind.Local).AddTicks(2463),
                            Title = "New Note",
                            UserId = 15L
                        });
                });

            modelBuilder.Entity("RepositoryLayer.Entity.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            CreatedAt = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "uncle.bob@gmail.com",
                            FirstName = "Uncle",
                            LastName = "Bob",
                            ModifiedAt = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "1234"
                        },
                        new
                        {
                            UserId = 2L,
                            CreatedAt = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "aunty.bob@gmail.com",
                            FirstName = "Aunty",
                            LastName = "Bob",
                            ModifiedAt = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Collaboration", b =>
                {
                    b.HasOne("RepositoryLayer.Entity.Notes", "Notes")
                        .WithMany("Collaborations")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Entity.User", "User")
                        .WithMany("Collaborations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notes");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Label", b =>
                {
                    b.HasOne("RepositoryLayer.Entity.Notes", "Notes")
                        .WithMany("Labels")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Entity.User", "User")
                        .WithMany("Labels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notes");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Notes", b =>
                {
                    b.Navigation("Collaborations");

                    b.Navigation("Labels");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.User", b =>
                {
                    b.Navigation("Collaborations");

                    b.Navigation("Labels");
                });
#pragma warning restore 612, 618
        }
    }
}
