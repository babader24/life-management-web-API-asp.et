﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_managemant_web_API.Data;

#nullable disable

namespace Task_managemant_web_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContectModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task_managemant_web_API.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Colors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorCode = "#FF6B6B"
                        },
                        new
                        {
                            Id = 2,
                            ColorCode = "#4ECDC4"
                        },
                        new
                        {
                            Id = 3,
                            ColorCode = "#96CEB4"
                        },
                        new
                        {
                            Id = 4,
                            ColorCode = "#FFEEAD"
                        },
                        new
                        {
                            Id = 5,
                            ColorCode = "#D4A5A5"
                        });
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.DaysOfWeek", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<short>("DayNumber")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("DaysOfWeeks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayNumber = (short)1
                        },
                        new
                        {
                            Id = 2,
                            DayNumber = (short)2
                        },
                        new
                        {
                            Id = 3,
                            DayNumber = (short)3
                        },
                        new
                        {
                            Id = 4,
                            DayNumber = (short)4
                        },
                        new
                        {
                            Id = 5,
                            DayNumber = (short)5
                        },
                        new
                        {
                            Id = 6,
                            DayNumber = (short)6
                        },
                        new
                        {
                            Id = 7,
                            DayNumber = (short)7
                        });
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.NoteBook", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NoteBookDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NoteBookTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Notebooks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NoteBookDescription = "I Should Run 3KM",
                            NoteBookTitle = "Sport",
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            NoteBookDescription = "Get Some Mobility Excercises ",
                            NoteBookTitle = "LifeStyle",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.Priority", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<short>("PriorityType")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Priorities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PriorityType = (short)1
                        },
                        new
                        {
                            Id = 2,
                            PriorityType = (short)2
                        },
                        new
                        {
                            Id = 3,
                            PriorityType = (short)3
                        });
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.StickyNote", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ColorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("StickyNotes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorID = 1,
                            CreatedAt = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteDescription = "I am Jose Morinho",
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            ColorID = 2,
                            CreatedAt = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteDescription = "I am Ahmed Babader",
                            UserID = 1
                        },
                        new
                        {
                            Id = 3,
                            ColorID = 3,
                            CreatedAt = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteDescription = "I am Salim Mohammed",
                            UserID = 1
                        },
                        new
                        {
                            Id = 4,
                            ColorID = 4,
                            CreatedAt = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteDescription = "I am Ali Ammar",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("UserID");

                    b.ToTable("Tasks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayId = 1,
                            IsDone = false,
                            PriorityId = 1,
                            TaskDescription = "i love Football",
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            DayId = 4,
                            IsDone = false,
                            PriorityId = 2,
                            TaskDescription = "i love Moon",
                            UserID = 1
                        },
                        new
                        {
                            Id = 3,
                            DayId = 3,
                            IsDone = false,
                            PriorityId = 1,
                            TaskDescription = "i love Study",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ahmed@gmail.com",
                            Image = "asfjhkjnbvm",
                            Password = "123",
                            UserName = "Ahmed Babder"
                        });
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.NoteBook", b =>
                {
                    b.HasOne("Task_managemant_web_API.Models.User", "User")
                        .WithMany("Notebooks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.StickyNote", b =>
                {
                    b.HasOne("Task_managemant_web_API.Models.Color", "Color")
                        .WithOne("StickyNote")
                        .HasForeignKey("Task_managemant_web_API.Models.StickyNote", "ColorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task_managemant_web_API.Models.User", "User")
                        .WithMany("stickyNotes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.Tasks", b =>
                {
                    b.HasOne("Task_managemant_web_API.Models.DaysOfWeek", "DayOfWeek")
                        .WithMany("Tasks")
                        .HasForeignKey("DayId");

                    b.HasOne("Task_managemant_web_API.Models.Priority", "Priority")
                        .WithMany("Tasks")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task_managemant_web_API.Models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserID");

                    b.Navigation("DayOfWeek");

                    b.Navigation("Priority");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.Color", b =>
                {
                    b.Navigation("StickyNote");
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.DaysOfWeek", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.Priority", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Task_managemant_web_API.Models.User", b =>
                {
                    b.Navigation("Notebooks");

                    b.Navigation("Tasks");

                    b.Navigation("stickyNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
