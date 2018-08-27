using SimpleTwitterApp.API.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SimpleTwitterApp.API.Contexts
{
    /// <summary>
    /// Tweet context interface.
    /// </summary>
    public interface ITweetContext : IDisposable
    {
        /// <summary>
        /// Gets or sets Tweets
        /// </summary>
        DbSet<TweetEntity> Tweets { get; set; }

        /// <summary>
        /// Gets or sets Users
        /// </summary>
        DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// Gets or sets UserDevices
        /// </summary>
        DbSet<UserDeviceEntity> UserDevices { get; set; }

        /// <summary>
        /// Gets or sets DeviceTypes
        /// </summary>
        DbSet<DeviceTypeEntity> DeviceTypes { get; set; }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }

    /// <summary>
    /// Tweet context class.
    /// </summary>
    public class TweetContext : DbContext, ITweetContext
    {
        /// <summary>
        /// TweetContext constructor
        /// </summary>
        public TweetContext()
            : base("name=SimpleTwitterContext")
        {
        }

        /// <inheritdoc select="*" />
        public DbSet<TweetEntity> Tweets { get; set; }

        /// <inheritdoc select="*" />
        public DbSet<UserEntity> Users { get; set; }

        /// <inheritdoc select="*" />
        public DbSet<UserDeviceEntity> UserDevices { get; set; }

        /// <inheritdoc select="*" />
        public DbSet<DeviceTypeEntity> DeviceTypes { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TweetEntity>().Map(x => x.ToTable("tweet"))
                .HasKey(x => x.TweetId).Property(x => x.TweetId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TweetEntity>().Property(x => x.TweetId).HasColumnName("tweet_id");
            modelBuilder.Entity<TweetEntity>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<TweetEntity>().Property(x => x.UserDeviceId).HasColumnName("user_device_id");
            modelBuilder.Entity<TweetEntity>().Property(x => x.TweetContent).HasColumnName("tweet_content");
            modelBuilder.Entity<TweetEntity>().Property(x => x.TwittedBy).HasColumnName("twitted_by");
            modelBuilder.Entity<TweetEntity>().Property(x => x.TweetTime).HasColumnName("tweet_time");

            modelBuilder.Entity<UserEntity>().Map(x => x.ToTable("user"))
                .HasKey(x => x.UserId).Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserEntity>().Property(x => x.Username).HasColumnName("username");
            modelBuilder.Entity<UserEntity>().Property(x => x.Password).HasColumnName("password");
            modelBuilder.Entity<UserEntity>().Property(x => x.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<UserEntity>().Property(x => x.MiddleName).HasColumnName("middle_name");
            modelBuilder.Entity<UserEntity>().Property(x => x.LastName).HasColumnName("last_name");
            modelBuilder.Entity<UserEntity>().Property(x => x.EMail).HasColumnName("e_mail");
            modelBuilder.Entity<UserEntity>().Property(x => x.Mobile).HasColumnName("mobile");
            modelBuilder.Entity<UserEntity>().Property(x => x.State).HasColumnName("state");
            modelBuilder.Entity<UserEntity>().Property(x => x.Country).HasColumnName("country");

            modelBuilder.Entity<UserDeviceEntity>().Map(x => x.ToTable("user_device"))
                .HasKey(x => x.UserId).Property(x => x.UserDeviceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDeviceEntity>().Property(x => x.UserDeviceId).HasColumnName("user_device_id");
            modelBuilder.Entity<UserDeviceEntity>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserDeviceEntity>().Property(x => x.DeviceTypeId).HasColumnName("device_type_id");
            modelBuilder.Entity<UserDeviceEntity>().Property(x => x.DeviceName).HasColumnName("device_name");

            modelBuilder.Entity<DeviceTypeEntity>().Map(x => x.ToTable("device_type"))
                .HasKey(x => x.DeviceTypeId).Property(x => x.DeviceTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeviceTypeEntity>().Property(x => x.DeviceTypeId).HasColumnName("device_type_id");
            modelBuilder.Entity<DeviceTypeEntity>().Property(x => x.DeviceTypeName).HasColumnName("device_type_name");
        }
    }
}