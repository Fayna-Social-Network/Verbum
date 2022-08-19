using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fayna.AdminPanel.Models
{
    public partial class VerbumDbContext : DbContext
    {
        public VerbumDbContext()
        {
        }

        public VerbumDbContext(DbContextOptions<VerbumDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AudioMessage> AudioMessages { get; set; } = null!;
        public virtual DbSet<ContactGroup> ContactGroups { get; set; } = null!;
        public virtual DbSet<FileMessage> FileMessages { get; set; } = null!;
        public virtual DbSet<Hobby> Hobbies { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<ImageAlbum> ImageAlbums { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<MessageReaction> MessageReactions { get; set; } = null!;
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;
        public virtual DbSet<SocialNetwork> SocialNetworks { get; set; } = null!;
        public virtual DbSet<Sticker> Stickers { get; set; } = null!;
        public virtual DbSet<StickersGroup> StickersGroups { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAdress> UserAdresses { get; set; } = null!;
        public virtual DbSet<UserBlackList> UserBlackLists { get; set; } = null!;
        public virtual DbSet<UserContact> UserContacts { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<VideoMessage> VideoMessages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Settings settings = new Settings();

                List<string> DbData = new List<string>();
                DbData = settings.GetDbSettings();

                string connectionString = "";
                if (DbData.Count > 0)
                {
                    connectionString = String.Format("Host={0};Port={1};Database={2};Username={3};Password={4}",
                    DbData[0], DbData[1], DbData[2], DbData[3], DbData[4]);
                }

                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioMessage>(entity =>
            {
                entity.ToTable("audioMessages");

                entity.HasIndex(e => e.MessageId, "IX_audioMessages_MessageId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Path).HasColumnName("path");

                entity.HasOne(d => d.Message)
                    .WithOne(p => p.AudioMessage)
                    .HasForeignKey<AudioMessage>(d => d.MessageId);
            });

            modelBuilder.Entity<ContactGroup>(entity =>
            {
                entity.ToTable("contactGroups");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasMany(d => d.VerbumUsers)
                    .WithMany(p => p.ContactGroups)
                    .UsingEntity<Dictionary<string, object>>(
                        "ContactGroupVerbumUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("VerbumUsersId"),
                        r => r.HasOne<ContactGroup>().WithMany().HasForeignKey("ContactGroupsId"),
                        j =>
                        {
                            j.HasKey("ContactGroupsId", "VerbumUsersId");

                            j.ToTable("ContactGroupVerbumUser");

                            j.HasIndex(new[] { "VerbumUsersId" }, "IX_ContactGroupVerbumUser_verbumUsersId");

                            j.IndexerProperty<Guid>("VerbumUsersId").HasColumnName("verbumUsersId");
                        });
            });

            modelBuilder.Entity<FileMessage>(entity =>
            {
                entity.ToTable("fileMessages");

                entity.HasIndex(e => e.MessageId, "IX_fileMessages_MessageId")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_fileMessages_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Message)
                    .WithOne(p => p.FileMessage)
                    .HasForeignKey<FileMessage>(d => d.MessageId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FileMessages)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Hobby>(entity =>
            {
                entity.ToTable("hobbies");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasMany(d => d.UserDetails)
                    .WithMany(p => p.Hobbies)
                    .UsingEntity<Dictionary<string, object>>(
                        "HobbyUserDetail",
                        l => l.HasOne<UserDetail>().WithMany().HasForeignKey("UserDetailsId"),
                        r => r.HasOne<Hobby>().WithMany().HasForeignKey("HobbiesId"),
                        j =>
                        {
                            j.HasKey("HobbiesId", "UserDetailsId");

                            j.ToTable("HobbyUserDetails");

                            j.HasIndex(new[] { "UserDetailsId" }, "IX_HobbyUserDetails_userDetailsId");

                            j.IndexerProperty<Guid>("UserDetailsId").HasColumnName("userDetailsId");
                        });
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(e => e.ImageAlbumId, "IX_Images_ImageAlbumId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.HasOne(d => d.ImageAlbum)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ImageAlbumId);
            });

            modelBuilder.Entity<ImageAlbum>(entity =>
            {
                entity.HasIndex(e => e.MessageId, "IX_ImageAlbums_MessageId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Message)
                    .WithOne(p => p.ImageAlbum)
                    .HasForeignKey<ImageAlbum>(d => d.MessageId);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Messages_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<MessageReaction>(entity =>
            {
                entity.HasIndex(e => e.MessageId, "IX_MessageReactions_MessageId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessageReactions)
                    .HasForeignKey(d => d.MessageId);
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.ToTable("phoneNumbers");

                entity.HasIndex(e => e.UserDetailsId, "IX_phoneNumbers_UserDetailsId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.UserDetails)
                    .WithMany(p => p.PhoneNumbers)
                    .HasForeignKey(d => d.UserDetailsId);
            });

            modelBuilder.Entity<SocialNetwork>(entity =>
            {
                entity.ToTable("socialNetworks");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasMany(d => d.UserDetails)
                    .WithMany(p => p.SocialNetworks)
                    .UsingEntity<Dictionary<string, object>>(
                        "SocialNetworkUserDetail",
                        l => l.HasOne<UserDetail>().WithMany().HasForeignKey("UserDetailsId"),
                        r => r.HasOne<SocialNetwork>().WithMany().HasForeignKey("SocialNetworksId"),
                        j =>
                        {
                            j.HasKey("SocialNetworksId", "UserDetailsId");

                            j.ToTable("SocialNetworkUserDetails");

                            j.HasIndex(new[] { "UserDetailsId" }, "IX_SocialNetworkUserDetails_userDetailsId");

                            j.IndexerProperty<Guid>("SocialNetworksId").HasColumnName("socialNetworksId");

                            j.IndexerProperty<Guid>("UserDetailsId").HasColumnName("userDetailsId");
                        });
            });

            modelBuilder.Entity<Sticker>(entity =>
            {
                entity.HasIndex(e => e.StickersGroupId, "IX_Stickers_stickersGroupId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StickersGroupId).HasColumnName("stickersGroupId");

                entity.HasOne(d => d.StickersGroup)
                    .WithMany(p => p.Stickers)
                    .HasForeignKey(d => d.StickersGroupId);
            });

            modelBuilder.Entity<StickersGroup>(entity =>
            {
                entity.ToTable("stickersGroups");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasMany(d => d.VerbumUsers)
                    .WithMany(p => p.StickersGroups)
                    .UsingEntity<Dictionary<string, object>>(
                        "StickersGroupVerbumUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("VerbumUsersId"),
                        r => r.HasOne<StickersGroup>().WithMany().HasForeignKey("StickersGroupsId"),
                        j =>
                        {
                            j.HasKey("StickersGroupsId", "VerbumUsersId");

                            j.ToTable("StickersGroupVerbumUser");

                            j.HasIndex(new[] { "VerbumUsersId" }, "IX_StickersGroupVerbumUser_verbumUsersId");

                            j.IndexerProperty<Guid>("StickersGroupsId").HasColumnName("stickersGroupsId");

                            j.IndexerProperty<Guid>("VerbumUsersId").HasColumnName("verbumUsersId");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserAdress>(entity =>
            {
                entity.ToTable("userAdresses");

                entity.HasIndex(e => e.UserDetailsId, "IX_userAdresses_UserDetailsId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.UserDetails)
                    .WithOne(p => p.UserAdress)
                    .HasForeignKey<UserAdress>(d => d.UserDetailsId);
            });

            modelBuilder.Entity<UserBlackList>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserBlackLists_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBlackLists)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserContact>(entity =>
            {
                entity.HasIndex(e => e.Contact, "IX_UserContacts_Contact");

                entity.HasIndex(e => e.GroupId, "IX_UserContacts_GroupId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.Contact);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("userDetails");

                entity.HasIndex(e => e.UserId, "IX_userDetails_UserId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserDetail)
                    .HasForeignKey<UserDetail>(d => d.UserId);
            });

            modelBuilder.Entity<VideoMessage>(entity =>
            {
                entity.ToTable("videoMessages");

                entity.HasIndex(e => e.MessageId, "IX_videoMessages_MessageId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Message)
                    .WithOne(p => p.VideoMessage)
                    .HasForeignKey<VideoMessage>(d => d.MessageId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
