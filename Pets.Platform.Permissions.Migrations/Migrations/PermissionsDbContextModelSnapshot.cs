﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pets.Platform.Permissions.EFCore.Persistence;

#nullable disable

namespace Pets.Platform.Permissions.Migrations.Migrations
{
    [DbContext(typeof(PermissionsDbContext))]
    partial class PermissionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.Action", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ActionCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("ApiPath")
                        .HasColumnType("longtext");

                    b.Property<string>("Method")
                        .HasColumnType("longtext");

                    b.Property<string>("RequestType")
                        .HasColumnType("longtext");

                    b.Property<string>("Service")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ActionCategoryId");

                    b.ToTable("actions", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ActionCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("actioncategories", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProductFamily", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("productfamilies", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProductFamilyRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProductFamilyId")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductFamilyId");

                    b.HasIndex("RoleId");

                    b.ToTable("productfamilyroles", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProductFamilySla", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProductFamilyId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SLAId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProductFamilyId");

                    b.HasIndex("SLAId");

                    b.ToTable("ProductFamilySla");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("_ownerId")
                        .HasColumnType("bigint")
                        .HasColumnName("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("_ownerId");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectProductFamily", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ProductFamilyId")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductFamilyId");

                    b.HasIndex("ProjectId");

                    b.ToTable("projectproductfamilies", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectResourceQuota", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("ResourceId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ResourceId");

                    b.ToTable("projectresourcequotas", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectSLA", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("SLAId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SLAId");

                    b.ToTable("projectslas", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("projectusers", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.Resource", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("resources", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.RoleToActionCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ActionCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ActionCategoryId");

                    b.HasIndex("RoleId");

                    b.ToTable("roletoactioncategories", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLA", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("slas", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLAResourceQuota", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ResourceId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SLAId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("SLAId");

                    b.ToTable("slaresourcequotas", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLASetupStep", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("SLAId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SetupStepName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SLAId", "SetupStepName")
                        .IsUnique();

                    b.ToTable("slasetupsteps", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLAToActionCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ActionCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("SLAId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ActionCategoryId");

                    b.HasIndex("SLAId");

                    b.ToTable("slatoactioncategories", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIElement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ActionCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<long>("UIModuleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ActionCategoryId");

                    b.HasIndex("UIModuleId");

                    b.ToTable("uielements", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ActionCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.Property<int>("IconType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Label")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Ordering")
                        .HasColumnType("int");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParentModuleId")
                        .HasColumnType("bigint");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<long?>("UIModuleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ActionCategoryId");

                    b.HasIndex("ParentId");

                    b.HasIndex("ParentModuleId");

                    b.HasIndex("UIModuleId");

                    b.ToTable("uimenus", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIModule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ActionCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Component")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<long?>("ParentModuleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Variant")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActionCategoryId");

                    b.HasIndex("ParentModuleId");

                    b.ToTable("uimodules", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIModuleToAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ActionId")
                        .HasColumnType("bigint");

                    b.Property<long>("UIModuleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("UIModuleId");

                    b.ToTable("uimoduletoactions", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UserAggregate.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<Guid>("IdentityGuid")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.Action", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ActionCategory", "ActionCategory")
                        .WithMany("Actions")
                        .HasForeignKey("ActionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionCategory");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProductFamilyRole", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ProductFamily", "ProductFamily")
                        .WithMany("AllowedRoles")
                        .HasForeignKey("ProductFamilyId");

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.Role", "Role")
                        .WithMany("ProductFamilyRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductFamily");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProductFamilySla", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ProductFamily", "ProductFamily")
                        .WithMany("AllowedSlas")
                        .HasForeignKey("ProductFamilyId");

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLA", "SLA")
                        .WithMany()
                        .HasForeignKey("SLAId");

                    b.Navigation("ProductFamily");

                    b.Navigation("SLA");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Project", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UserAggregate.User", null)
                        .WithMany("OwnedProjects")
                        .HasForeignKey("_ownerId");

                    b.OwnsOne("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectSettings", "ProjectSettings", b1 =>
                        {
                            b1.Property<long>("ProjectId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Values")
                                .HasColumnType("longtext");

                            b1.HasKey("ProjectId");

                            b1.ToTable("projectsettings", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("ProjectSettings");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectProductFamily", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ProductFamily", null)
                        .WithMany("Projects")
                        .HasForeignKey("ProductFamilyId");

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Project", null)
                        .WithMany("ProductFamilyAssignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectResourceQuota", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Project", null)
                        .WithMany("ProjectResourceQuotas")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.Resource", null)
                        .WithMany("ProjectResourceQuotas")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectSLA", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Project", null)
                        .WithMany("SLAs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLA", null)
                        .WithMany()
                        .HasForeignKey("SLAId");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.ProjectUser", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Project", null)
                        .WithMany("Participants")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.Role", null)
                        .WithMany("ProjectAssignments")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UserAggregate.User", null)
                        .WithMany("ParticipatingProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.RoleToActionCategory", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ActionCategory", "ActionCategory")
                        .WithMany("RoleToActions")
                        .HasForeignKey("ActionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.Role", "Role")
                        .WithMany("RoleToActionCategories")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionCategory");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLAResourceQuota", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.Resource", null)
                        .WithMany("SLAResourceQuotas")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLA", null)
                        .WithMany("ResourceQuotas")
                        .HasForeignKey("SLAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLASetupStep", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLA", null)
                        .WithMany("SetupSteps")
                        .HasForeignKey("SLAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLAToActionCategory", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ActionCategory", null)
                        .WithMany("SLAtoActionCategories")
                        .HasForeignKey("ActionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLA", null)
                        .WithMany("ActionCategories")
                        .HasForeignKey("SLAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIElement", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ActionCategory", "ActionCategory")
                        .WithMany("UIElements")
                        .HasForeignKey("ActionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UIModule", "UIModule")
                        .WithMany("UIElements")
                        .HasForeignKey("UIModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionCategory");

                    b.Navigation("UIModule");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIMenu", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ActionCategory", null)
                        .WithMany("UIMenus")
                        .HasForeignKey("ActionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UIMenu", "Parent")
                        .WithMany("MenuItems")
                        .HasForeignKey("ParentId");

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UIModule", "ParentModule")
                        .WithMany("UIMenus")
                        .HasForeignKey("ParentModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UIModule", "UIModule")
                        .WithMany("AssignedToMenus")
                        .HasForeignKey("UIModuleId");

                    b.Navigation("Parent");

                    b.Navigation("ParentModule");

                    b.Navigation("UIModule");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIModule", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.ActionCategory", "ActionCategory")
                        .WithMany("UIModules")
                        .HasForeignKey("ActionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UIModule", "ParentModule")
                        .WithMany("ChildModules")
                        .HasForeignKey("ParentModuleId");

                    b.Navigation("ActionCategory");

                    b.Navigation("ParentModule");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIModuleToAction", b =>
                {
                    b.HasOne("Pets.Platform.Permissions.Core.Domain.Action", "Action")
                        .WithMany("UIModuleToActions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pets.Platform.Permissions.Core.Domain.UIModule", "UIModule")
                        .WithMany("Actions")
                        .HasForeignKey("UIModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("UIModule");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UserAggregate.User", b =>
                {
                    b.OwnsOne("Pets.Platform.Permissions.Core.Domain.UserAggregate.UserSettings", "UserSettings", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Values")
                                .HasColumnType("longtext");

                            b1.HasKey("UserId");

                            b1.ToTable("usersettings", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("UserSettings");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.Action", b =>
                {
                    b.Navigation("UIModuleToActions");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ActionCategory", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("RoleToActions");

                    b.Navigation("SLAtoActionCategories");

                    b.Navigation("UIElements");

                    b.Navigation("UIMenus");

                    b.Navigation("UIModules");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProductFamily", b =>
                {
                    b.Navigation("AllowedRoles");

                    b.Navigation("AllowedSlas");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Project", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("ProductFamilyAssignments");

                    b.Navigation("ProjectResourceQuotas");

                    b.Navigation("SLAs");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.Resource", b =>
                {
                    b.Navigation("ProjectResourceQuotas");

                    b.Navigation("SLAResourceQuotas");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.Role", b =>
                {
                    b.Navigation("ProductFamilyRoles");

                    b.Navigation("ProjectAssignments");

                    b.Navigation("RoleToActionCategories");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.SLAAggregate.SLA", b =>
                {
                    b.Navigation("ActionCategories");

                    b.Navigation("ResourceQuotas");

                    b.Navigation("SetupSteps");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIMenu", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UIModule", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("AssignedToMenus");

                    b.Navigation("ChildModules");

                    b.Navigation("UIElements");

                    b.Navigation("UIMenus");
                });

            modelBuilder.Entity("Pets.Platform.Permissions.Core.Domain.UserAggregate.User", b =>
                {
                    b.Navigation("OwnedProjects");

                    b.Navigation("ParticipatingProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
