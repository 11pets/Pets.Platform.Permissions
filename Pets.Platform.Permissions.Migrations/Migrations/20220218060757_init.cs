using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets.Platform.Permissions.Migrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "actioncategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actioncategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productfamilies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productfamilies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resources", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "slas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdentityGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "actions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    RequestType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApiPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Method = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Service = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_actions_actioncategories_ActionCategoryId",
                        column: x => x.ActionCategoryId,
                        principalTable: "actioncategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "uimodules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Component = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Variant = table.Column<int>(type: "int", nullable: false),
                    ParentModuleId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uimodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uimodules_actioncategories_ActionCategoryId",
                        column: x => x.ActionCategoryId,
                        principalTable: "actioncategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uimodules_uimodules_ParentModuleId",
                        column: x => x.ParentModuleId,
                        principalTable: "uimodules",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productfamilyroles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ProductFamilyId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productfamilyroles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productfamilyroles_productfamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "productfamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productfamilyroles_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roletoactioncategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roletoactioncategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roletoactioncategories_actioncategories_ActionCategoryId",
                        column: x => x.ActionCategoryId,
                        principalTable: "actioncategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roletoactioncategories_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductFamilySla",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductFamilyId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SLAId = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilySla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFamilySla_productfamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "productfamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductFamilySla_slas_SLAId",
                        column: x => x.SLAId,
                        principalTable: "slas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "slaresourcequotas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ResourceId = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SLAId = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slaresourcequotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_slaresourcequotas_resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_slaresourcequotas_slas_SLAId",
                        column: x => x.SLAId,
                        principalTable: "slas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "slasetupsteps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SetupStepName = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SLAId = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slasetupsteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_slasetupsteps_slas_SLAId",
                        column: x => x.SLAId,
                        principalTable: "slas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "slatoactioncategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SLAId = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slatoactioncategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_slatoactioncategories_actioncategories_ActionCategoryId",
                        column: x => x.ActionCategoryId,
                        principalTable: "actioncategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_slatoactioncategories_slas_SLAId",
                        column: x => x.SLAId,
                        principalTable: "slas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usersettings",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Values = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersettings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_usersettings_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "uielements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    UIModuleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uielements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uielements_actioncategories_ActionCategoryId",
                        column: x => x.ActionCategoryId,
                        principalTable: "actioncategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uielements_uimodules_UIModuleId",
                        column: x => x.UIModuleId,
                        principalTable: "uimodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "uimenus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconType = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ParentModuleId = table.Column<long>(type: "bigint", nullable: false),
                    UIModuleId = table.Column<long>(type: "bigint", nullable: true),
                    Label = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ordering = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uimenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uimenus_actioncategories_ActionCategoryId",
                        column: x => x.ActionCategoryId,
                        principalTable: "actioncategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uimenus_uimenus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "uimenus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_uimenus_uimodules_ParentModuleId",
                        column: x => x.ParentModuleId,
                        principalTable: "uimodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uimenus_uimodules_UIModuleId",
                        column: x => x.UIModuleId,
                        principalTable: "uimodules",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "uimoduletoactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UIModuleId = table.Column<long>(type: "bigint", nullable: false),
                    ActionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uimoduletoactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uimoduletoactions_actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uimoduletoactions_uimodules_UIModuleId",
                        column: x => x.UIModuleId,
                        principalTable: "uimodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectproductfamilies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductFamilyId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectproductfamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectproductfamilies_productfamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "productfamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_projectproductfamilies_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectresourcequotas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceId = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectresourcequotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectresourcequotas_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectresourcequotas_resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectsettings",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    Values = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectsettings", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_projectsettings_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectslas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SLAId = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectslas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectslas_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectslas_slas_SLAId",
                        column: x => x.SLAId,
                        principalTable: "slas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectusers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectusers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectusers_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectusers_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_projectusers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_actions_ActionCategoryId",
                table: "actions",
                column: "ActionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_productfamilyroles_ProductFamilyId",
                table: "productfamilyroles",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_productfamilyroles_RoleId",
                table: "productfamilyroles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFamilySla_ProductFamilyId",
                table: "ProductFamilySla",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFamilySla_SLAId",
                table: "ProductFamilySla",
                column: "SLAId");

            migrationBuilder.CreateIndex(
                name: "IX_projectproductfamilies_ProductFamilyId",
                table: "projectproductfamilies",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_projectproductfamilies_ProjectId",
                table: "projectproductfamilies",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectresourcequotas_ProjectId",
                table: "projectresourcequotas",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectresourcequotas_ResourceId",
                table: "projectresourcequotas",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_OwnerId",
                table: "projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_projectslas_ProjectId",
                table: "projectslas",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectslas_SLAId",
                table: "projectslas",
                column: "SLAId");

            migrationBuilder.CreateIndex(
                name: "IX_projectusers_ProjectId",
                table: "projectusers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectusers_RoleId",
                table: "projectusers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_projectusers_UserId",
                table: "projectusers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_roletoactioncategories_ActionCategoryId",
                table: "roletoactioncategories",
                column: "ActionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_roletoactioncategories_RoleId",
                table: "roletoactioncategories",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_slaresourcequotas_ResourceId",
                table: "slaresourcequotas",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_slaresourcequotas_SLAId",
                table: "slaresourcequotas",
                column: "SLAId");

            migrationBuilder.CreateIndex(
                name: "IX_slasetupsteps_SLAId_SetupStepName",
                table: "slasetupsteps",
                columns: new[] { "SLAId", "SetupStepName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_slatoactioncategories_ActionCategoryId",
                table: "slatoactioncategories",
                column: "ActionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_slatoactioncategories_SLAId",
                table: "slatoactioncategories",
                column: "SLAId");

            migrationBuilder.CreateIndex(
                name: "IX_uielements_ActionCategoryId",
                table: "uielements",
                column: "ActionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_uielements_UIModuleId",
                table: "uielements",
                column: "UIModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_uimenus_ActionCategoryId",
                table: "uimenus",
                column: "ActionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_uimenus_ParentId",
                table: "uimenus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_uimenus_ParentModuleId",
                table: "uimenus",
                column: "ParentModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_uimenus_UIModuleId",
                table: "uimenus",
                column: "UIModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_uimodules_ActionCategoryId",
                table: "uimodules",
                column: "ActionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_uimodules_ParentModuleId",
                table: "uimodules",
                column: "ParentModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_uimoduletoactions_ActionId",
                table: "uimoduletoactions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_uimoduletoactions_UIModuleId",
                table: "uimoduletoactions",
                column: "UIModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productfamilyroles");

            migrationBuilder.DropTable(
                name: "ProductFamilySla");

            migrationBuilder.DropTable(
                name: "projectproductfamilies");

            migrationBuilder.DropTable(
                name: "projectresourcequotas");

            migrationBuilder.DropTable(
                name: "projectsettings");

            migrationBuilder.DropTable(
                name: "projectslas");

            migrationBuilder.DropTable(
                name: "projectusers");

            migrationBuilder.DropTable(
                name: "roletoactioncategories");

            migrationBuilder.DropTable(
                name: "slaresourcequotas");

            migrationBuilder.DropTable(
                name: "slasetupsteps");

            migrationBuilder.DropTable(
                name: "slatoactioncategories");

            migrationBuilder.DropTable(
                name: "uielements");

            migrationBuilder.DropTable(
                name: "uimenus");

            migrationBuilder.DropTable(
                name: "uimoduletoactions");

            migrationBuilder.DropTable(
                name: "usersettings");

            migrationBuilder.DropTable(
                name: "productfamilies");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "slas");

            migrationBuilder.DropTable(
                name: "actions");

            migrationBuilder.DropTable(
                name: "uimodules");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "actioncategories");
        }
    }
}
