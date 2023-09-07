using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using Microsoft.EntityFrameworkCore;
namespace DbServicesEFCore.ModelClass
{
    public class VideoDetectContext : DbContext
    {
        #region Members
        public DbSet<CameraConfiguration> CameraConfigurations { get; set; }
        public DbSet<MonitoringDetail> MonitoringDetails { get; set; }
        public DbSet<ConfigurationModificationDetail> ConfigurationModificationDetails { get; set; }
        public DbSet<VideoExtension> VideoExtensions { get; set; }
        public DbSet<PhotoExtension> PhotoExtensions { get; set; }

        public DbSet<Actions> Actions { get; set; }
        #endregion
        //fluent api 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actions>()
                .Property(a => a.Action)
                .HasConversion<string>(); // Optional: Convert enum to string

            modelBuilder.Entity<Actions>()
                .Property(a => a.Action)
                .HasDefaultValue(ActionsEnum.Created.ToString()); // Set default value to Created

            modelBuilder.Entity<Actions>()
                .HasKey(a => a.Id); // Specify the primary key

            // Additional configurations for other entities...

            // Seed initial data if needed
            modelBuilder.Entity<Actions>().HasData(
                new Actions { Id = (int)ActionsEnum.Created, Action = ActionsEnum.Created.ToString() },
                new Actions { Id = (int)ActionsEnum.Modified, Action = ActionsEnum.Modified.ToString() },
                new Actions { Id = (int)ActionsEnum.Deleted, Action = ActionsEnum.Deleted.ToString() }
            );
            modelBuilder.Entity<VideoExtension>()
                   .HasKey(ve => ve.Id);

            // Configure additional properties
            modelBuilder.Entity<VideoExtension>()
                .Property(ve => ve.Extension)
                .HasConversion<string>();
            // Seed initial data if needed
            modelBuilder.Entity<VideoExtension>().HasData(
            new VideoExtension { Id = (int)VideoExtensionsEnum.MPG, Extension = VideoExtensionsEnum.MPG.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.MP2, Extension = VideoExtensionsEnum.MP2.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.MP3, Extension = VideoExtensionsEnum.MP3.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.MPEG, Extension = VideoExtensionsEnum.MPEG.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.MPE, Extension = VideoExtensionsEnum.MPE.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.MPV, Extension = VideoExtensionsEnum.MPV.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.WEBM, Extension = VideoExtensionsEnum.WEBM.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.OGG, Extension = VideoExtensionsEnum.OGG.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.AVI, Extension = VideoExtensionsEnum.AVI.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.WMV, Extension = VideoExtensionsEnum.WMV.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.AVCHD, Extension = VideoExtensionsEnum.AVCHD.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.AVC, Extension = VideoExtensionsEnum.AVC.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.MP4, Extension = VideoExtensionsEnum.MP4.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.M4P, Extension = VideoExtensionsEnum.M4P.ToString() }
        );
            modelBuilder.Entity<PhotoExtension>()
           .HasKey(ve => ve.Id);

            // Configure additional properties
            modelBuilder.Entity<PhotoExtension>()
                .Property(ve => ve.Extension)
                .HasConversion<string>();
            modelBuilder.Entity<PhotoExtension>().HasData(
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jpg, Extension = PhotoExtensionsEnum.jpg.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jpeg, Extension = PhotoExtensionsEnum.jpeg.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jfi, Extension = PhotoExtensionsEnum.jfi.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jpe, Extension = PhotoExtensionsEnum.jpe.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jif, Extension = PhotoExtensionsEnum.jif.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jfif, Extension = PhotoExtensionsEnum.jfif.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.png, Extension = PhotoExtensionsEnum.png.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.svg, Extension = PhotoExtensionsEnum.svg.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.svgz, Extension = PhotoExtensionsEnum.svgz.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.pdf, Extension = PhotoExtensionsEnum.pdf.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.webp, Extension = PhotoExtensionsEnum.webp.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.tiff, Extension = PhotoExtensionsEnum.tiff.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.tif, Extension = PhotoExtensionsEnum.tif.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.psd, Extension = PhotoExtensionsEnum.psd.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.raw, Extension = PhotoExtensionsEnum.raw.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.arw, Extension = PhotoExtensionsEnum.arw.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.cr, Extension = PhotoExtensionsEnum.cr.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.rw2, Extension = PhotoExtensionsEnum.rw2.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.nrw, Extension = PhotoExtensionsEnum.nrw.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.k25, Extension = PhotoExtensionsEnum.k25.ToString() }
);
        }

        #region Cosntructors
        public VideoDetectContext()
        {

        }
        #endregion
        #region Constructors

        public VideoDetectContext(string connectionString) : base(GetOptions(connectionString))
        {
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=VideoDetectDb;trusted_connection=true;");
        }
        private static DbContextOptions GetOptions(string ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

    }
}