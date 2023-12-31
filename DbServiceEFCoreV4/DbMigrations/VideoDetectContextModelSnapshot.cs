﻿// <auto-generated />
using System;
using DbServicesEFCore.ModelClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbServiceEFCoreV4.DbMigrations
{
    [DbContext(typeof(VideoDetectContext))]
    partial class VideoDetectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassLibrary.ModelClass.CameraConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CameraName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FolderPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoExtension")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CameraConfigurations");
                });

            modelBuilder.Entity("ClassLibrary.ModelClass.ConfigurationModificationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionsID")
                        .HasColumnType("int");

                    b.Property<string>("CameraName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FolderPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoExtension")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActionsID");

                    b.ToTable("ConfigurationModificationDetails");
                });

            modelBuilder.Entity("ClassLibrary.ModelClass.MonitoringDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionsID")
                        .HasColumnType("int");

                    b.Property<int>("CameraConfigurationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FolderPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVideo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActionsID");

                    b.HasIndex("CameraConfigurationID");

                    b.ToTable("MonitoringDetails");
                });

            modelBuilder.Entity("DbServiceEFCoreV4.ModelClass.Actions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Created");

                    b.HasKey("Id");

                    b.ToTable("Actions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Action = "Created"
                        },
                        new
                        {
                            Id = 2,
                            Action = "Modified"
                        },
                        new
                        {
                            Id = 3,
                            Action = "Deleted"
                        });
                });

            modelBuilder.Entity("DbServiceEFCoreV4.ModelClass.PhotoExtension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhotoExtensions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Extension = "jpg"
                        },
                        new
                        {
                            Id = 2,
                            Extension = "jpeg"
                        },
                        new
                        {
                            Id = 3,
                            Extension = "jfi"
                        },
                        new
                        {
                            Id = 4,
                            Extension = "jpe"
                        },
                        new
                        {
                            Id = 5,
                            Extension = "jif"
                        },
                        new
                        {
                            Id = 6,
                            Extension = "jfif"
                        },
                        new
                        {
                            Id = 7,
                            Extension = "png"
                        },
                        new
                        {
                            Id = 8,
                            Extension = "svg"
                        },
                        new
                        {
                            Id = 9,
                            Extension = "svgz"
                        },
                        new
                        {
                            Id = 10,
                            Extension = "pdf"
                        },
                        new
                        {
                            Id = 11,
                            Extension = "webp"
                        },
                        new
                        {
                            Id = 12,
                            Extension = "tiff"
                        },
                        new
                        {
                            Id = 13,
                            Extension = "tif"
                        },
                        new
                        {
                            Id = 14,
                            Extension = "psd"
                        },
                        new
                        {
                            Id = 15,
                            Extension = "raw"
                        },
                        new
                        {
                            Id = 16,
                            Extension = "arw"
                        },
                        new
                        {
                            Id = 17,
                            Extension = "cr"
                        },
                        new
                        {
                            Id = 18,
                            Extension = "rw2"
                        },
                        new
                        {
                            Id = 19,
                            Extension = "nrw"
                        },
                        new
                        {
                            Id = 20,
                            Extension = "k25"
                        });
                });

            modelBuilder.Entity("DbServiceEFCoreV4.ModelClass.VideoExtension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VideoExtensions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Extension = "MPG"
                        },
                        new
                        {
                            Id = 2,
                            Extension = "MP2"
                        },
                        new
                        {
                            Id = 3,
                            Extension = "MP3"
                        },
                        new
                        {
                            Id = 4,
                            Extension = "MPEG"
                        },
                        new
                        {
                            Id = 5,
                            Extension = "MPE"
                        },
                        new
                        {
                            Id = 6,
                            Extension = "MPV"
                        },
                        new
                        {
                            Id = 7,
                            Extension = "WEBM"
                        },
                        new
                        {
                            Id = 8,
                            Extension = "OGG"
                        },
                        new
                        {
                            Id = 9,
                            Extension = "AVI"
                        },
                        new
                        {
                            Id = 10,
                            Extension = "WMV"
                        },
                        new
                        {
                            Id = 11,
                            Extension = "AVCHD"
                        },
                        new
                        {
                            Id = 12,
                            Extension = "AVC"
                        },
                        new
                        {
                            Id = 13,
                            Extension = "MP4"
                        },
                        new
                        {
                            Id = 14,
                            Extension = "M4P"
                        });
                });

            modelBuilder.Entity("ClassLibrary.ModelClass.ConfigurationModificationDetail", b =>
                {
                    b.HasOne("DbServiceEFCoreV4.ModelClass.Actions", "Actions")
                        .WithMany("ConfigurationModificationDetails")
                        .HasForeignKey("ActionsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassLibrary.ModelClass.MonitoringDetail", b =>
                {
                    b.HasOne("DbServiceEFCoreV4.ModelClass.Actions", "Actions")
                        .WithMany("MonitoringDetails")
                        .HasForeignKey("ActionsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.ModelClass.CameraConfiguration", "CameraConfiguration")
                        .WithMany("MonitoringDetails")
                        .HasForeignKey("CameraConfigurationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
