﻿// <auto-generated />
using System;
using Medical.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Medical.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240724101804_friend")]
    partial class friend
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Medical.Models.AppFiles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("id");

                    b.ToTable("files", (string)null);
                });

            modelBuilder.Entity("Medical.Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("commentImageId")
                        .HasColumnType("int");

                    b.Property<int>("postId")
                        .HasColumnType("int");

                    b.Property<int>("profileId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("commentImageId")
                        .IsUnique()
                        .HasFilter("[commentImageId] IS NOT NULL");

                    b.HasIndex("postId");

                    b.HasIndex("profileId");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("Medical.Models.CommentLike", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("commentId")
                        .HasColumnType("int");

                    b.Property<int>("profileId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("commentId");

                    b.HasIndex("profileId");

                    b.ToTable("commentLikes", (string)null);
                });

            modelBuilder.Entity("Medical.Models.Friend", b =>
                {
                    b.Property<int>("profileId")
                        .HasColumnType("int");

                    b.Property<int>("friendId")
                        .HasColumnType("int");

                    b.HasKey("profileId", "friendId");

                    b.HasIndex("friendId");

                    b.ToTable("friends", (string)null);
                });

            modelBuilder.Entity("Medical.Models.FriendRequests", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("recievedProfileId")
                        .HasColumnType("int");

                    b.Property<int>("sendedProfileId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("recievedProfileId");

                    b.HasIndex("sendedProfileId");

                    b.ToTable("friendRequests", (string)null);
                });

            modelBuilder.Entity("Medical.Models.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("post")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("postImageId")
                        .HasColumnType("int");

                    b.Property<int>("profileId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("postImageId")
                        .IsUnique()
                        .HasFilter("[postImageId] IS NOT NULL");

                    b.HasIndex("profileId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("Medical.Models.PostLike", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("postId")
                        .HasColumnType("int");

                    b.Property<int>("profileId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("postId");

                    b.HasIndex("profileId");

                    b.ToTable("postLikes", (string)null);
                });

            modelBuilder.Entity("Medical.Models.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("profiles", (string)null);
                });

            modelBuilder.Entity("Medical.Models.Reply", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("parentCommentID")
                        .HasColumnType("int");

                    b.Property<string>("reply")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("id");

                    b.HasIndex("parentCommentID");

                    b.ToTable("replies", (string)null);
                });

            modelBuilder.Entity("Medical.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Medical.Models.Comment", b =>
                {
                    b.HasOne("Medical.Models.AppFiles", "commentImage")
                        .WithOne()
                        .HasForeignKey("Medical.Models.Comment", "commentImageId");

                    b.HasOne("Medical.Models.Post", "post")
                        .WithMany("comments")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical.Models.Profile", "profile")
                        .WithMany("comments")
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("commentImage");

                    b.Navigation("post");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Medical.Models.CommentLike", b =>
                {
                    b.HasOne("Medical.Models.Comment", "comment")
                        .WithMany("commentLikes")
                        .HasForeignKey("commentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical.Models.Profile", "profile")
                        .WithMany("commentLikes")
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("comment");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Medical.Models.Friend", b =>
                {
                    b.HasOne("Medical.Models.User", "friend")
                        .WithMany()
                        .HasForeignKey("friendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical.Models.Profile", "profile")
                        .WithMany("FriendsTo")
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("friend");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Medical.Models.FriendRequests", b =>
                {
                    b.HasOne("Medical.Models.Profile", "recievedProfile")
                        .WithMany("ReceievedFriendRequests")
                        .HasForeignKey("recievedProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Medical.Models.Profile", "sendedProfile")
                        .WithMany("SentFriendRequests")
                        .HasForeignKey("sendedProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("recievedProfile");

                    b.Navigation("sendedProfile");
                });

            modelBuilder.Entity("Medical.Models.Post", b =>
                {
                    b.HasOne("Medical.Models.AppFiles", "postImage")
                        .WithOne()
                        .HasForeignKey("Medical.Models.Post", "postImageId");

                    b.HasOne("Medical.Models.Profile", "profile")
                        .WithMany("posts")
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("postImage");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Medical.Models.PostLike", b =>
                {
                    b.HasOne("Medical.Models.Post", "post")
                        .WithMany("postLikes")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Medical.Models.Profile", "profile")
                        .WithMany("postLikes")
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Medical.Models.Profile", b =>
                {
                    b.HasOne("Medical.Models.User", "user")
                        .WithOne()
                        .HasForeignKey("Medical.Models.Profile", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Medical.Models.Reply", b =>
                {
                    b.HasOne("Medical.Models.Comment", "parentComment")
                        .WithMany("replies")
                        .HasForeignKey("parentCommentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("parentComment");
                });

            modelBuilder.Entity("Medical.Models.Comment", b =>
                {
                    b.Navigation("commentLikes");

                    b.Navigation("replies");
                });

            modelBuilder.Entity("Medical.Models.Post", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("postLikes");
                });

            modelBuilder.Entity("Medical.Models.Profile", b =>
                {
                    b.Navigation("FriendsTo");

                    b.Navigation("ReceievedFriendRequests");

                    b.Navigation("SentFriendRequests");

                    b.Navigation("commentLikes");

                    b.Navigation("comments");

                    b.Navigation("postLikes");

                    b.Navigation("posts");
                });
#pragma warning restore 612, 618
        }
    }
}
