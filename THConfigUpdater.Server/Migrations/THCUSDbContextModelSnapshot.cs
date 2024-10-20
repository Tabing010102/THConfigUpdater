﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using THConfigUpdater.Server.Data;

#nullable disable

namespace THConfigUpdater.Server.Migrations
{
    [DbContext(typeof(THCUSDbContext))]
    partial class THCUSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("THConfigUpdater.Server.Models.ConfigFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FileBasedConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServerPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sha256")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FileBasedConfigId");

                    b.ToTable("ConfigFiles");
                });

            modelBuilder.Entity("THConfigUpdater.Server.Models.FileBasedConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomOperations")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FileBasedConfigs");
                });

            modelBuilder.Entity("THConfigUpdater.Server.Models.ConfigFile", b =>
                {
                    b.HasOne("THConfigUpdater.Server.Models.FileBasedConfig", "FileBasedConfig")
                        .WithMany("ConfigFiles")
                        .HasForeignKey("FileBasedConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileBasedConfig");
                });

            modelBuilder.Entity("THConfigUpdater.Server.Models.FileBasedConfig", b =>
                {
                    b.Navigation("ConfigFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
