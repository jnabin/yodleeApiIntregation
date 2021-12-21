using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace YodleeIntegration.Infrastructure.Migrations
{
    public partial class AllEntitiesclassesComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeRequestLog",
                table: "YodleeRequestLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeConfigurations",
                table: "YodleeConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeAuthTokens",
                table: "YodleeAuthTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeApiKeys",
                table: "YodleeApiKeys");

            migrationBuilder.RenameTable(
                name: "YodleeRequestLog",
                newName: "YodleeWrapperIntegrationRequestLog");

            migrationBuilder.RenameTable(
                name: "YodleeConfigurations",
                newName: "YodleeWrapperIntegrationConfigurations");

            migrationBuilder.RenameTable(
                name: "YodleeAuthTokens",
                newName: "YodleeWrapperIntegrationAuthTokens");

            migrationBuilder.RenameTable(
                name: "YodleeApiKeys",
                newName: "YodleeWrapperIntegrationApiKeys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeWrapperIntegrationRequestLog",
                table: "YodleeWrapperIntegrationRequestLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeWrapperIntegrationConfigurations",
                table: "YodleeWrapperIntegrationConfigurations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeWrapperIntegrationAuthTokens",
                table: "YodleeWrapperIntegrationAuthTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeWrapperIntegrationApiKeys",
                table: "YodleeWrapperIntegrationApiKeys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AddManualResponseAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    YodleeAddManualResponseAccountId = table.Column<int>(type: "integer", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddManualResponseAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetClassificationLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassificationType = table.Column<string>(type: "text", nullable: true),
                    ClassificationValue = table.Column<List<string>>(type: "text[]", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetClassificationLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullAccountNumberFields = table.Column<List<string>>(type: "text[]", nullable: true),
                    NumberOfTransactionDays = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullAccountNumberFields = table.Column<List<string>>(type: "text[]", nullable: true),
                    NumberOfTransactionDays = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<int>(type: "integer", nullable: false),
                    Longitude = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataExtractUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataExtractUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromDate = table.Column<string>(type: "text", nullable: true),
                    UserCount = table.Column<int>(type: "integer", nullable: false),
                    ToDate = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Security = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: true),
                    Simple = table.Column<string>(type: "text", nullable: true),
                    Consumer = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FullAccountNumberLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentAccountNumber = table.Column<string>(type: "text", nullable: true),
                    UnmaskedAccountNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullAccountNumberLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YoldeeHistoricalAccountId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Middle = table.Column<string>(type: "text", nullable: true),
                    Last = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    First = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationEvent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CallBackUrl = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateFormat = table.Column<string>(type: "text", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Locale = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Principals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProviderAccountPreference",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDataExtractsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LinkedProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    IsAutoRefreshEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAccountPreference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageISOCode = table.Column<string>(type: "text", nullable: true),
                    Favicon = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<List<string>>(type: "text[]", nullable: true),
                    CountryISOCode = table.Column<string>(type: "text", nullable: true),
                    IsAddedByUser = table.Column<string>(type: "text", nullable: true),
                    PRIORITY = table.Column<string>(type: "text", nullable: true),
                    AssociatedProviderIds = table.Column<List<int>>(type: "integer[]", nullable: true),
                    PrimaryLanguageISOCode = table.Column<string>(type: "text", nullable: true),
                    Help = table.Column<string>(type: "text", nullable: true),
                    BaseUrl = table.Column<string>(type: "text", nullable: true),
                    IsConsentRequired = table.Column<bool>(type: "boolean", nullable: false),
                    LoginUrl = table.Column<string>(type: "text", nullable: true),
                    IsAutoRefreshEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    YodleeProviderId = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<string>(type: "text", nullable: true),
                    AuthParameter = table.Column<List<string>>(type: "text[]", nullable: true),
                    AuthType = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicKeys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunningBalances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningBalances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssueTypeMultiplier = table.Column<int>(type: "integer", nullable: false),
                    StateTaxable = table.Column<bool>(type: "boolean", nullable: false),
                    CallDate = table.Column<string>(type: "text", nullable: true),
                    CdscFundFlag = table.Column<bool>(type: "boolean", nullable: false),
                    Cusip = table.Column<string>(type: "text", nullable: true),
                    FederalTaxable = table.Column<bool>(type: "boolean", nullable: false),
                    SAndPRating = table.Column<string>(type: "text", nullable: true),
                    ShareClass = table.Column<string>(type: "text", nullable: true),
                    IsEnvestnetDummySecurity = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MinimumPurchase = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    FirstCouponDate = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    AccrualMethod = table.Column<string>(type: "text", nullable: true),
                    IncomeCurrency = table.Column<string>(type: "text", nullable: true),
                    MaturityDate = table.Column<string>(type: "text", nullable: true),
                    CallPrice = table.Column<int>(type: "integer", nullable: false),
                    YodleeSecurityId = table.Column<int>(type: "integer", nullable: false),
                    IssueDate = table.Column<string>(type: "text", nullable: true),
                    Sector = table.Column<string>(type: "text", nullable: true),
                    AgencyFactor = table.Column<int>(type: "integer", nullable: false),
                    InterestRate = table.Column<int>(type: "integer", nullable: false),
                    LastModifiedDate = table.Column<string>(type: "text", nullable: true),
                    GicsSector = table.Column<string>(type: "text", nullable: true),
                    ClosedFlag = table.Column<bool>(type: "boolean", nullable: false),
                    Sedol = table.Column<string>(type: "text", nullable: true),
                    SubSector = table.Column<string>(type: "text", nullable: true),
                    LastCouponDate = table.Column<string>(type: "text", nullable: true),
                    IsSyntheticSecurity = table.Column<bool>(type: "boolean", nullable: false),
                    TradeCurrencyCode = table.Column<string>(type: "text", nullable: true),
                    IsDummySecurity = table.Column<bool>(type: "boolean", nullable: false),
                    MoodyRating = table.Column<string>(type: "text", nullable: true),
                    Style = table.Column<string>(type: "text", nullable: true),
                    FirmEligible = table.Column<string>(type: "text", nullable: true),
                    FundFamily = table.Column<string>(type: "text", nullable: true),
                    Isin = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Totals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Totals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HighLevelCategoryName = table.Column<string>(type: "text", nullable: true),
                    DefaultHighLevelCategoryName = table.Column<string>(type: "text", nullable: true),
                    HighLevelCategoryId = table.Column<int>(type: "integer", nullable: false),
                    YodleeTransactionCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    DefaultCategoryName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategorizationRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserDefinedRuleId = table.Column<int>(type: "integer", nullable: false),
                    CategoryLevelId = table.Column<int>(type: "integer", nullable: false),
                    TransactionCategorizationId = table.Column<int>(type: "integer", nullable: false),
                    MemId = table.Column<int>(type: "integer", nullable: false),
                    RulePriority = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategorizationRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsLinks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Transactions = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdateProviderAccountDataSets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateProviderAccountDataSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdateProviderAccountFields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: true),
                    YodleeUpdateProviderAccountFieldsId = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateProviderAccountFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileDetailProviderAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YodleeUserProfileDetailProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileDetailProviderAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerifyAccountDTOs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyAccountDTOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerifyAccountTransactionCriterias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Keyword = table.Column<string>(type: "text", nullable: true),
                    DateVariance = table.Column<string>(type: "text", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifyAccountTransactionCriterias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YodleeAccessTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppId = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeAccessTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerAttributes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BANKId = table.Column<long>(type: "bigint", nullable: true),
                    LOANId = table.Column<long>(type: "bigint", nullable: true),
                    CREDITCARDId = table.Column<long>(type: "bigint", nullable: true),
                    INVESTMENTId = table.Column<long>(type: "bigint", nullable: true),
                    INSURANCEId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContainerAttributes_Banks_BANKId",
                        column: x => x.BANKId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerAttributes_CardDetails_CREDITCARDId",
                        column: x => x.CREDITCARDId,
                        principalTable: "CardDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerAttributes_CardDetails_INSURANCEId",
                        column: x => x.INSURANCEId,
                        principalTable: "CardDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerAttributes_CardDetails_INVESTMENTId",
                        column: x => x.INVESTMENTId,
                        principalTable: "CardDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContainerAttributes_CardDetails_LOANId",
                        column: x => x.LOANId,
                        principalTable: "CardDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDatas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDatas_DataExtractUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataExtractUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataExtractUserDatas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalTransactionsCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    DataId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataExtractUserDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataExtractUserDatas_DataExtractUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DataExtractUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractUserDatas_Datas_DataId",
                        column: x => x.DataId,
                        principalTable: "Datas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dataId = table.Column<long>(type: "bigint", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Datas_dataId",
                        column: x => x.dataId,
                        principalTable: "Datas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreferencesId = table.Column<long>(type: "bigint", nullable: true),
                    OauthMigrationStatus = table.Column<string>(type: "text", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    ConsentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<string>(type: "text", nullable: true),
                    AggregationSource = table.Column<string>(type: "text", nullable: true),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    RequestId = table.Column<string>(type: "text", nullable: true),
                    YodleeProviderAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderAccounts_ProviderAccountPreference_PreferencesId",
                        column: x => x.PreferencesId,
                        principalTable: "ProviderAccountPreference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Capabilities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Container = table.Column<List<string>>(type: "text[]", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProviderId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capabilities_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvidersDatasets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProviderId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersDatasets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidersDatasets_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RuleClauses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Field = table.Column<string>(type: "text", nullable: true),
                    Operation = table.Column<string>(type: "text", nullable: true),
                    RuleId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleClauses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleClauses_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountBalances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    TotalBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    CurrentBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    RefreshStatus = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    AvailableBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderId = table.Column<string>(type: "text", nullable: true),
                    ProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    Container = table.Column<string>(type: "text", nullable: true),
                    CashId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderName = table.Column<string>(type: "text", nullable: true),
                    FailedReason = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBalances_RunningBalances_AvailableBalanceId",
                        column: x => x.AvailableBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountBalances_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountBalances_RunningBalances_CashId",
                        column: x => x.CashId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountBalances_RunningBalances_CurrentBalanceId",
                        column: x => x.CurrentBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountBalances_RunningBalances_TotalBalanceId",
                        column: x => x.TotalBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalBalanceAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: true),
                    IsAsset = table.Column<bool>(type: "boolean", nullable: false),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AsOfDate = table.Column<string>(type: "text", nullable: true),
                    DataSourceType = table.Column<string>(type: "text", nullable: true),
                    HistoricalAccountId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalBalanceAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalBalanceAccounts_HistoricalAccounts_HistoricalAcco~",
                        column: x => x.HistoricalAccountId,
                        principalTable: "HistoricalAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalBalanceAccounts_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoldingsSummarys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassificationType = table.Column<string>(type: "text", nullable: true),
                    ClassificationValue = table.Column<string>(type: "text", nullable: true),
                    ValueId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingsSummarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldingsSummarys_RunningBalances_ValueId",
                        column: x => x.ValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanPayoffDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PayByDate = table.Column<string>(type: "text", nullable: true),
                    PayoffAmountId = table.Column<long>(type: "bigint", nullable: true),
                    OutstandingBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPayoffDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanPayoffDetails_RunningBalances_OutstandingBalanceId",
                        column: x => x.OutstandingBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanPayoffDetails_RunningBalances_PayoffAmountId",
                        column: x => x.PayoffAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Networths",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    LiabilityId = table.Column<long>(type: "bigint", nullable: true),
                    NetworthId = table.Column<long>(type: "bigint", nullable: true),
                    AssetId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Networths_RunningBalances_AssetId",
                        column: x => x.AssetId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Networths_RunningBalances_LiabilityId",
                        column: x => x.LiabilityId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Networths_RunningBalances_NetworthId",
                        column: x => x.NetworthId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeStatements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Apr = table.Column<long>(type: "bigint", nullable: false),
                    CashApr = table.Column<long>(type: "bigint", nullable: false),
                    BillingPeriodStart = table.Column<string>(type: "text", nullable: true),
                    DueDate = table.Column<string>(type: "text", nullable: true),
                    InterestAmountId = table.Column<long>(type: "bigint", nullable: true),
                    StatementDate = table.Column<string>(type: "text", nullable: true),
                    CashAdvanceId = table.Column<long>(type: "bigint", nullable: true),
                    BillingPeriodEnd = table.Column<string>(type: "text", nullable: true),
                    PrincipalAmountId = table.Column<long>(type: "bigint", nullable: true),
                    LoanBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AmountDueId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    IsLatest = table.Column<bool>(type: "boolean", nullable: false),
                    MinimumPaymentId = table.Column<long>(type: "bigint", nullable: true),
                    LastPaymentDate = table.Column<string>(type: "text", nullable: true),
                    LastPaymentAmountId = table.Column<long>(type: "bigint", nullable: true),
                    NewChargesId = table.Column<long>(type: "bigint", nullable: true),
                    YodleeStatementId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_AmountDueId",
                        column: x => x.AmountDueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_CashAdvanceId",
                        column: x => x.CashAdvanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_InterestAmountId",
                        column: x => x.InterestAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_LastPaymentAmountId",
                        column: x => x.LastPaymentAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_LoanBalanceId",
                        column: x => x.LoanBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_MinimumPaymentId",
                        column: x => x.MinimumPaymentId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_NewChargesId",
                        column: x => x.NewChargesId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeStatements_RunningBalances_PrincipalAmountId",
                        column: x => x.PrincipalAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeVerifiedAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    VerificationStatus = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    CurrentBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    DisplayedName = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    AvailableBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    FullAccountNumberListId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderId = table.Column<string>(type: "text", nullable: true),
                    ProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    CONTAINER = table.Column<string>(type: "text", nullable: true),
                    IsSelected = table.Column<bool>(type: "boolean", nullable: false),
                    CashId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderName = table.Column<string>(type: "text", nullable: true),
                    FailedReason = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeVerifiedAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeVerifiedAccount_FullAccountNumberLists_FullAccountNum~",
                        column: x => x.FullAccountNumberListId,
                        principalTable: "FullAccountNumberLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeVerifiedAccount_RunningBalances_AvailableBalanceId",
                        column: x => x.AvailableBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeVerifiedAccount_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeVerifiedAccount_RunningBalances_CashId",
                        column: x => x.CashId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeVerifiedAccount_RunningBalances_CurrentBalanceId",
                        column: x => x.CurrentBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecurityHoldings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SecurityId = table.Column<long>(type: "bigint", nullable: true),
                    YodleeSecurityHoldingId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityHoldings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityHoldings_Security_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Security",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockExchangeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    ExchangeCode = table.Column<string>(type: "text", nullable: true),
                    SecurityId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchangeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockExchangeDetails_Security_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Security",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderCounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderCounts_Totals_TotalId",
                        column: x => x.TotalId,
                        principalTable: "Totals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DetailCategoryId = table.Column<int>(type: "integer", nullable: false),
                    TransactionCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailCategories_TransactionCategories_TransactionCategoryId",
                        column: x => x.TransactionCategoryId,
                        principalTable: "TransactionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeRuleClaus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Field = table.Column<string>(type: "text", nullable: true),
                    UserDefinedRuleId = table.Column<int>(type: "integer", nullable: false),
                    FieldValue = table.Column<string>(type: "text", nullable: true),
                    Operation = table.Column<string>(type: "text", nullable: true),
                    RuleClauseId = table.Column<int>(type: "integer", nullable: false),
                    TransactionCategorizationRuleId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeRuleClaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeRuleClaus_TransactionCategorizationRules_TransactionC~",
                        column: x => x.TransactionCategorizationRuleId,
                        principalTable: "TransactionCategorizationRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsSummarys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryType = table.Column<string>(type: "text", nullable: true),
                    CreditTotalId = table.Column<long>(type: "bigint", nullable: true),
                    LinksId = table.Column<long>(type: "bigint", nullable: true),
                    DebitTotalId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsSummarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionsSummarys_RunningBalances_CreditTotalId",
                        column: x => x.CreditTotalId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionsSummarys_RunningBalances_DebitTotalId",
                        column: x => x.DebitTotalId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionsSummarys_TransactionsLinks_LinksId",
                        column: x => x.LinksId,
                        principalTable: "TransactionsLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    NameId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderAccountProfileId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Names_NameId",
                        column: x => x.NameId,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_UserProfileDetailProviderAccounts_ProviderAccountP~",
                        column: x => x.ProviderAccountProfileId,
                        principalTable: "UserProfileDetailProviderAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCriterias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Matched = table.Column<string>(type: "text", nullable: true),
                    Keyword = table.Column<string>(type: "text", nullable: true),
                    DateVariance = table.Column<string>(type: "text", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    VerifyAccountDTOId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionCriterias_VerifyAccountDTOs_VerifyAccountDTOId",
                        column: x => x.VerifyAccountDTOId,
                        principalTable: "VerifyAccountDTOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Container = table.Column<string>(type: "text", nullable: true),
                    ProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    AccountStatus = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    AggregationSource = table.Column<string>(type: "text", nullable: true),
                    IsAsset = table.Column<bool>(type: "boolean", nullable: false),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    YodleeAccountId = table.Column<int>(type: "integer", nullable: false),
                    IncludeInNetWorth = table.Column<bool>(type: "boolean", nullable: false),
                    ProviderId = table.Column<string>(type: "text", nullable: true),
                    ProviderName = table.Column<string>(type: "text", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    DisplayedName = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AvailableBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    DueDate = table.Column<string>(type: "text", nullable: true),
                    InterestRateType = table.Column<string>(type: "text", nullable: true),
                    LastPaymentDate = table.Column<string>(type: "text", nullable: true),
                    MaturityDate = table.Column<string>(type: "text", nullable: true),
                    OriginalLoanAmountId = table.Column<long>(type: "bigint", nullable: true),
                    PrincipalBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    OriginationDate = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    CashId = table.Column<long>(type: "bigint", nullable: true),
                    MarginBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    LastEmployeeContributionAmountId = table.Column<long>(type: "bigint", nullable: true),
                    LastEmployeeContributionDate = table.Column<string>(type: "text", nullable: true),
                    CashApr = table.Column<double>(type: "double precision", nullable: true),
                    AvailableCashId = table.Column<long>(type: "bigint", nullable: true),
                    AvailableCreditId = table.Column<long>(type: "bigint", nullable: true),
                    LastPaymentAmountId = table.Column<long>(type: "bigint", nullable: true),
                    RunningBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    TotalCashLimitId = table.Column<long>(type: "bigint", nullable: true),
                    TotalCreditLineId = table.Column<long>(type: "bigint", nullable: true),
                    AmountDueId = table.Column<long>(type: "bigint", nullable: true),
                    MinimumAmountDueId = table.Column<long>(type: "bigint", nullable: true),
                    AnnualPercentageYield = table.Column<double>(type: "double precision", nullable: true),
                    InterestRate = table.Column<double>(type: "double precision", nullable: true),
                    Apr = table.Column<double>(type: "double precision", nullable: true),
                    VerifyAccountDTOId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_AmountDueId",
                        column: x => x.AmountDueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_AvailableBalanceId",
                        column: x => x.AvailableBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_AvailableCashId",
                        column: x => x.AvailableCashId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_AvailableCreditId",
                        column: x => x.AvailableCreditId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_CashId",
                        column: x => x.CashId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_CurrentBalanceId",
                        column: x => x.CurrentBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_LastEmployeeContributionAmou~",
                        column: x => x.LastEmployeeContributionAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_LastPaymentAmountId",
                        column: x => x.LastPaymentAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_MarginBalanceId",
                        column: x => x.MarginBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_MinimumAmountDueId",
                        column: x => x.MinimumAmountDueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_OriginalLoanAmountId",
                        column: x => x.OriginalLoanAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_PrincipalBalanceId",
                        column: x => x.PrincipalBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_RunningBalanceId",
                        column: x => x.RunningBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_TotalCashLimitId",
                        column: x => x.TotalCashLimitId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_RunningBalances_TotalCreditLineId",
                        column: x => x.TotalCreditLineId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAccounts_VerifyAccountDTOs_VerifyAccountDTOId",
                        column: x => x.VerifyAccountDTOId,
                        principalTable: "VerifyAccountDTOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpdateProviderAccountAttributes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Container = table.Column<List<string>>(type: "text[]", nullable: true),
                    ContainerAttributesId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UpdateProviderAccountDataSetId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateProviderAccountAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpdateProviderAccountAttributes_ContainerAttributes_Contain~",
                        column: x => x.ContainerAttributesId,
                        principalTable: "ContainerAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpdateProviderAccountAttributes_UpdateProviderAccountDataSe~",
                        column: x => x.UpdateProviderAccountDataSetId,
                        principalTable: "UpdateProviderAccountDataSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MethodType = table.Column<string>(type: "text", nullable: true),
                    Rel = table.Column<string>(type: "text", nullable: true),
                    Href = table.Column<string>(type: "text", nullable: true),
                    UserDataId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_UserDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UserDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataExtractProviderAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DestinationProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    OauthMigrationStatus = table.Column<string>(type: "text", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<string>(type: "text", nullable: true),
                    AggregationSource = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    RequestId = table.Column<string>(type: "text", nullable: true),
                    SourceProviderAccountIds = table.Column<List<int>>(type: "integer[]", nullable: true),
                    YodleeDataExtractsProviderAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DataExtractUserDataId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataExtractProviderAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataExtractProviderAccounts_DataExtractUserDatas_DataExtrac~",
                        column: x => x.DataExtractUserDataId,
                        principalTable: "DataExtractUserDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginForms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MfaInfoTitle = table.Column<string>(type: "text", nullable: true),
                    Help = table.Column<string>(type: "text", nullable: true),
                    ForgetPasswordURL = table.Column<string>(type: "text", nullable: true),
                    FormType = table.Column<string>(type: "text", nullable: true),
                    MfaInfoText = table.Column<string>(type: "text", nullable: true),
                    LoginHelp = table.Column<string>(type: "text", nullable: true),
                    MfaTimeout = table.Column<int>(type: "integer", nullable: false),
                    YodleeLoginFormId = table.Column<int>(type: "integer", nullable: false),
                    ProviderAccountId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginForms_ProviderAccounts_ProviderAccountId",
                        column: x => x.ProviderAccountId,
                        principalTable: "ProviderAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoginForms_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Container = table.Column<List<string>>(type: "text[]", nullable: true),
                    FromDate = table.Column<string>(type: "text", nullable: true),
                    ToFinYear = table.Column<string>(type: "text", nullable: true),
                    FromFinYear = table.Column<string>(type: "text", nullable: true),
                    ContainerAttributesId = table.Column<long>(type: "bigint", nullable: true),
                    ToDate = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProvidersDatasetId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_ContainerAttributes_ContainerAttributesId",
                        column: x => x.ContainerAttributesId,
                        principalTable: "ContainerAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attributes_ProvidersDatasets_ProvidersDatasetId",
                        column: x => x.ProvidersDatasetId,
                        principalTable: "ProvidersDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holdings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    ExercisedQuantity = table.Column<int>(type: "integer", nullable: false),
                    CusipNumber = table.Column<string>(type: "text", nullable: true),
                    VestedQuantity = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UnvestedValueId = table.Column<long>(type: "bigint", nullable: true),
                    SecurityStyle = table.Column<string>(type: "text", nullable: true),
                    VestedValueId = table.Column<long>(type: "bigint", nullable: true),
                    OptionType = table.Column<string>(type: "text", nullable: true),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    MatchStatus = table.Column<string>(type: "text", nullable: true),
                    HoldingType = table.Column<string>(type: "text", nullable: true),
                    MaturityDate = table.Column<string>(type: "text", nullable: true),
                    PriceId = table.Column<long>(type: "bigint", nullable: true),
                    Term = table.Column<string>(type: "text", nullable: true),
                    ContractQuantity = table.Column<int>(type: "integer", nullable: false),
                    YodleeHoldingId = table.Column<int>(type: "integer", nullable: false),
                    IsShort = table.Column<bool>(type: "boolean", nullable: false),
                    ValueId = table.Column<long>(type: "bigint", nullable: true),
                    ExpirationDate = table.Column<string>(type: "text", nullable: true),
                    InterestRate = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    AccruedInterestId = table.Column<long>(type: "bigint", nullable: true),
                    GrantDate = table.Column<string>(type: "text", nullable: true),
                    Sedol = table.Column<string>(type: "text", nullable: true),
                    VestedSharesExercisable = table.Column<int>(type: "integer", nullable: false),
                    SpreadId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    EnrichedDescription = table.Column<string>(type: "text", nullable: true),
                    CouponRate = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<string>(type: "text", nullable: true),
                    AccruedIncomeId = table.Column<long>(type: "bigint", nullable: true),
                    SecurityType = table.Column<string>(type: "text", nullable: true),
                    ProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    UnvestedQuantity = table.Column<int>(type: "integer", nullable: false),
                    CostBasisId = table.Column<long>(type: "bigint", nullable: true),
                    VestingDate = table.Column<string>(type: "text", nullable: true),
                    Isin = table.Column<string>(type: "text", nullable: true),
                    StrikePriceId = table.Column<long>(type: "bigint", nullable: true),
                    DataExtractUserDataId = table.Column<long>(type: "bigint", nullable: true),
                    HoldingsSummaryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holdings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holdings_DataExtractUserDatas_DataExtractUserDataId",
                        column: x => x.DataExtractUserDataId,
                        principalTable: "DataExtractUserDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_HoldingsSummarys_HoldingsSummaryId",
                        column: x => x.HoldingsSummaryId,
                        principalTable: "HoldingsSummarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_AccruedIncomeId",
                        column: x => x.AccruedIncomeId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_AccruedInterestId",
                        column: x => x.AccruedInterestId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_CostBasisId",
                        column: x => x.CostBasisId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_PriceId",
                        column: x => x.PriceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_SpreadId",
                        column: x => x.SpreadId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_StrikePriceId",
                        column: x => x.StrikePriceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_UnvestedValueId",
                        column: x => x.UnvestedValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_ValueId",
                        column: x => x.ValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holdings_RunningBalances_VestedValueId",
                        column: x => x.VestedValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoldingsAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YodleeDerivedHoldingsAccountId = table.Column<long>(type: "bigint", nullable: false),
                    ValueId = table.Column<long>(type: "bigint", nullable: true),
                    HoldingsSummaryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldingsAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldingsAccounts_HoldingsSummarys_HoldingsSummaryId",
                        column: x => x.HoldingsSummaryId,
                        principalTable: "HoldingsSummarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoldingsAccounts_RunningBalances_ValueId",
                        column: x => x.ValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalBalances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    IsAsset = table.Column<bool>(type: "boolean", nullable: false),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AsOfDate = table.Column<string>(type: "text", nullable: true),
                    DataSourceType = table.Column<string>(type: "text", nullable: true),
                    NetworthDetailId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalBalances_Networths_NetworthDetailId",
                        column: x => x.NetworthDetailId,
                        principalTable: "Networths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalBalances_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Ownership = table.Column<string>(type: "text", nullable: true),
                    NameId = table.Column<long>(type: "bigint", nullable: true),
                    VerifiedAccountId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holders_Names_NameId",
                        column: x => x.NameId,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holders_YodleeVerifiedAccount_VerifiedAccountId",
                        column: x => x.VerifiedAccountId,
                        principalTable: "YodleeVerifiedAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Summarys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreditTotalId = table.Column<long>(type: "bigint", nullable: true),
                    LinksId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryName = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    DebitTotalId = table.Column<long>(type: "bigint", nullable: true),
                    TransactionsSummaryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Summarys_RunningBalances_CreditTotalId",
                        column: x => x.CreditTotalId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Summarys_RunningBalances_DebitTotalId",
                        column: x => x.DebitTotalId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Summarys_TransactionsLinks_LinksId",
                        column: x => x.LinksId,
                        principalTable: "TransactionsLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Summarys_TransactionsSummarys_TransactionsSummaryId",
                        column: x => x.TransactionsSummaryId,
                        principalTable: "TransactionsSummarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Zip = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Address3 = table.Column<string>(type: "text", nullable: true),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    SourceType = table.Column<string>(type: "text", nullable: true),
                    Address1 = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ProfileId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ProfileId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ProfileId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AdditionalStatus = table.Column<string>(type: "text", nullable: true),
                    UpdateEligibility = table.Column<string>(type: "text", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdateAttempt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NextUpdateScheduled = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderAccountId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSets_ProviderAccounts_ProviderAccountId",
                        column: x => x.ProviderAccountId,
                        principalTable: "ProviderAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSets_YodleeAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "YodleeAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FieldRowChoice = table.Column<string>(type: "text", nullable: true),
                    Form = table.Column<string>(type: "text", nullable: true),
                    YodleeRowId = table.Column<string>(type: "text", nullable: true),
                    Label = table.Column<string>(type: "text", nullable: true),
                    LoginFormId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rows_LoginForms_LoginFormId",
                        column: x => x.LoginFormId,
                        principalTable: "LoginForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetClassifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Allocation = table.Column<int>(type: "integer", nullable: false),
                    ClassificationType = table.Column<string>(type: "text", nullable: true),
                    ClassificationValue = table.Column<string>(type: "text", nullable: true),
                    HoldingId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetClassifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetClassifications_Holdings_HoldingId",
                        column: x => x.HoldingId,
                        principalTable: "Holdings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    HolderId = table.Column<long>(type: "bigint", nullable: true),
                    ProfileId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifiers_Holders_HolderId",
                        column: x => x.HolderId,
                        principalTable: "Holders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Identifiers_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SummaryDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: true),
                    CreditTotalId = table.Column<long>(type: "bigint", nullable: true),
                    DebitTotalId = table.Column<long>(type: "bigint", nullable: true),
                    SummaryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryDetails_RunningBalances_CreditTotalId",
                        column: x => x.CreditTotalId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SummaryDetails_RunningBalances_DebitTotalId",
                        column: x => x.DebitTotalId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SummaryDetails_Summarys_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddManualAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncludeInNetWorth = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: false),
                    AccountType = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<string>(type: "text", nullable: true),
                    Memo = table.Column<string>(type: "text", nullable: true),
                    HomeValueId = table.Column<long>(type: "bigint", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    AmountDueId = table.Column<long>(type: "bigint", nullable: true),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    ValuationType = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddManualAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddManualAccounts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddManualAccounts_RunningBalances_AmountDueId",
                        column: x => x.AmountDueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddManualAccounts_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddManualAccounts_RunningBalances_HomeValueId",
                        column: x => x.HomeValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataExtractAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AvailableCashId = table.Column<long>(type: "bigint", nullable: true),
                    IncludeInNetWorth = table.Column<bool>(type: "boolean", nullable: false),
                    MoneyMarketBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    EnrollmentDate = table.Column<string>(type: "text", nullable: true),
                    EstimatedDate = table.Column<string>(type: "text", nullable: true),
                    Memo = table.Column<string>(type: "text", nullable: true),
                    Guarantor = table.Column<string>(type: "text", nullable: true),
                    InterestPaidLastYearId = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    HomeInsuranceType = table.Column<string>(type: "text", nullable: true),
                    YodleeDataExtractsAccountId = table.Column<long>(type: "bigint", nullable: false),
                    CashId = table.Column<long>(type: "bigint", nullable: true),
                    TotalCreditLineId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderName = table.Column<string>(type: "text", nullable: true),
                    ValuationType = table.Column<string>(type: "text", nullable: true),
                    MarginBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    Apr = table.Column<int>(type: "integer", nullable: false),
                    AvailableCreditId = table.Column<long>(type: "bigint", nullable: true),
                    CurrentBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false),
                    EscrowBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    NextLevel = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    LoanPayoffAmountId = table.Column<long>(type: "bigint", nullable: true),
                    InterestRateType = table.Column<string>(type: "text", nullable: true),
                    LoanPayByDate = table.Column<string>(type: "text", nullable: true),
                    FaceAmountId = table.Column<long>(type: "bigint", nullable: true),
                    PolicyFromDate = table.Column<string>(type: "text", nullable: true),
                    PremiumPaymentTerm = table.Column<string>(type: "text", nullable: true),
                    PolicyTerm = table.Column<string>(type: "text", nullable: true),
                    RepaymentPlanType = table.Column<string>(type: "text", nullable: true),
                    AvailableBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountStatus = table.Column<string>(type: "text", nullable: true),
                    LifeInsuranceType = table.Column<string>(type: "text", nullable: true),
                    PremiumId = table.Column<long>(type: "bigint", nullable: true),
                    AggregationSource = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    OverDraftLimitId = table.Column<long>(type: "bigint", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    Term = table.Column<string>(type: "text", nullable: true),
                    InterestRate = table.Column<int>(type: "integer", nullable: false),
                    DeathBenefitId = table.Column<long>(type: "bigint", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    CashValueId = table.Column<long>(type: "bigint", nullable: true),
                    _401kLoanId = table.Column<long>(type: "bigint", nullable: true),
                    HomeValueId = table.Column<long>(type: "bigint", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<string>(type: "text", nullable: true),
                    InterestPaidYTDId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    Collateral = table.Column<string>(type: "text", nullable: true),
                    RunningBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    SourceId = table.Column<string>(type: "text", nullable: true),
                    DueDate = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    MaturityAmountId = table.Column<long>(type: "bigint", nullable: true),
                    AssociatedProviderAccountId = table.Column<List<int>>(type: "integer[]", nullable: true),
                    IsAsset = table.Column<bool>(type: "boolean", nullable: false),
                    PrincipalBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    TotalCashLimitId = table.Column<long>(type: "bigint", nullable: true),
                    MaturityDate = table.Column<string>(type: "text", nullable: true),
                    MinimumAmountDueId = table.Column<long>(type: "bigint", nullable: true),
                    AnnualPercentageYield = table.Column<int>(type: "integer", nullable: false),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    OriginationDate = table.Column<string>(type: "text", nullable: true),
                    TotalVestedBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    SourceAccountStatus = table.Column<string>(type: "text", nullable: true),
                    DerivedApr = table.Column<int>(type: "integer", nullable: false),
                    PolicyEffectiveDate = table.Column<string>(type: "text", nullable: true),
                    TotalUnvestedBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AnnuityBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    TotalCreditLimitId = table.Column<long>(type: "bigint", nullable: true),
                    PolicyStatus = table.Column<string>(type: "text", nullable: true),
                    ShortBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    Lender = table.Column<string>(type: "text", nullable: true),
                    LastEmployeeContributionAmountId = table.Column<long>(type: "bigint", nullable: true),
                    ProviderId = table.Column<string>(type: "text", nullable: true),
                    LastPaymentDate = table.Column<string>(type: "text", nullable: true),
                    PrimaryRewardUnit = table.Column<string>(type: "text", nullable: true),
                    LastPaymentAmountId = table.Column<long>(type: "bigint", nullable: true),
                    RemainingBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    UserClassification = table.Column<string>(type: "text", nullable: true),
                    ExpirationDate = table.Column<string>(type: "text", nullable: true),
                    CashApr = table.Column<int>(type: "integer", nullable: false),
                    OauthMigrationStatus = table.Column<string>(type: "text", nullable: true),
                    DisplayedName = table.Column<string>(type: "text", nullable: true),
                    SourceProviderAccountId = table.Column<int>(type: "integer", nullable: false),
                    AmountDueId = table.Column<long>(type: "bigint", nullable: true),
                    CurrentLevel = table.Column<string>(type: "text", nullable: true),
                    OriginalLoanAmountId = table.Column<long>(type: "bigint", nullable: true),
                    PolicyToDate = table.Column<string>(type: "text", nullable: true),
                    LoanPayoffDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    Container = table.Column<string>(type: "text", nullable: true),
                    LastEmployeeContributionDate = table.Column<string>(type: "text", nullable: true),
                    LastPaymentId = table.Column<long>(type: "bigint", nullable: true),
                    RecurringPaymentId = table.Column<long>(type: "bigint", nullable: true),
                    DataExtractUserDataId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataExtractAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_DataExtractUserDatas_DataExtractUserDat~",
                        column: x => x.DataExtractUserDataId,
                        principalTable: "DataExtractUserDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_LoanPayoffDetails_LoanPayoffDetailsId",
                        column: x => x.LoanPayoffDetailsId,
                        principalTable: "LoanPayoffDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances__401kLoanId",
                        column: x => x._401kLoanId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_AmountDueId",
                        column: x => x.AmountDueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_AnnuityBalanceId",
                        column: x => x.AnnuityBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_AvailableBalanceId",
                        column: x => x.AvailableBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_AvailableCashId",
                        column: x => x.AvailableCashId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_AvailableCreditId",
                        column: x => x.AvailableCreditId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_CashId",
                        column: x => x.CashId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_CashValueId",
                        column: x => x.CashValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_CurrentBalanceId",
                        column: x => x.CurrentBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_DeathBenefitId",
                        column: x => x.DeathBenefitId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_EscrowBalanceId",
                        column: x => x.EscrowBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_FaceAmountId",
                        column: x => x.FaceAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_HomeValueId",
                        column: x => x.HomeValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_InterestPaidLastYearId",
                        column: x => x.InterestPaidLastYearId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_InterestPaidYTDId",
                        column: x => x.InterestPaidYTDId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_LastEmployeeContributio~",
                        column: x => x.LastEmployeeContributionAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_LastPaymentAmountId",
                        column: x => x.LastPaymentAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_LastPaymentId",
                        column: x => x.LastPaymentId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_LoanPayoffAmountId",
                        column: x => x.LoanPayoffAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_MarginBalanceId",
                        column: x => x.MarginBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_MaturityAmountId",
                        column: x => x.MaturityAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_MinimumAmountDueId",
                        column: x => x.MinimumAmountDueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_MoneyMarketBalanceId",
                        column: x => x.MoneyMarketBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_OriginalLoanAmountId",
                        column: x => x.OriginalLoanAmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_OverDraftLimitId",
                        column: x => x.OverDraftLimitId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_PremiumId",
                        column: x => x.PremiumId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_PrincipalBalanceId",
                        column: x => x.PrincipalBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_RecurringPaymentId",
                        column: x => x.RecurringPaymentId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_RemainingBalanceId",
                        column: x => x.RemainingBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_RunningBalanceId",
                        column: x => x.RunningBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_ShortBalanceId",
                        column: x => x.ShortBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_TotalCashLimitId",
                        column: x => x.TotalCashLimitId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLimitId",
                        column: x => x.TotalCreditLimitId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_TotalCreditLineId",
                        column: x => x.TotalCreditLineId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_TotalUnvestedBalanceId",
                        column: x => x.TotalUnvestedBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractAccounts_RunningBalances_TotalVestedBalanceId",
                        column: x => x.TotalVestedBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Website = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryLabel = table.Column<List<string>>(type: "text[]", nullable: true),
                    CoordinatesId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    YodleeMerchantId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merchants_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merchants_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpdateAccountDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Container = table.Column<string>(type: "text", nullable: true),
                    IncludeInNetWorth = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    DueDate = table.Column<string>(type: "text", nullable: true),
                    Memo = table.Column<string>(type: "text", nullable: true),
                    HomeValueId = table.Column<long>(type: "bigint", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    AccountStatus = table.Column<string>(type: "text", nullable: true),
                    AmountDueId = table.Column<long>(type: "bigint", nullable: true),
                    BalanceId = table.Column<long>(type: "bigint", nullable: true),
                    Is_E_billEnrolled = table.Column<string>(type: "text", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateAccountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpdateAccountDetails_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpdateAccountDetails_RunningBalances_AmountDueId",
                        column: x => x.AmountDueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpdateAccountDetails_RunningBalances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpdateAccountDetails_RunningBalances_HomeValueId",
                        column: x => x.HomeValueId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreferencesId = table.Column<long>(type: "bigint", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    LoginName = table.Column<string>(type: "text", nullable: true),
                    NameId = table.Column<long>(type: "bigint", nullable: true),
                    RoleType = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    SegmentName = table.Column<string>(type: "text", nullable: true),
                    YodleeUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeUser_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeUser_Names_NameId",
                        column: x => x.NameId,
                        principalTable: "Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeUser_Preferences_PreferencesId",
                        column: x => x.PreferencesId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    MinLength = table.Column<int>(type: "integer", nullable: false),
                    ValueEditable = table.Column<bool>(type: "boolean", nullable: false),
                    IsOptional = table.Column<bool>(type: "boolean", nullable: false),
                    Suffix = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    IsValueProvided = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    YodleeFieldId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    MaxLength = table.Column<int>(type: "integer", nullable: false),
                    RowId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Rows_RowId",
                        column: x => x.RowId,
                        principalTable: "Rows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankTransferCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YodleeBankTransferCodeId = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    DataExtractAccountId = table.Column<long>(type: "bigint", nullable: true),
                    VerifiedAccountId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransferCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransferCodes_DataExtractAccounts_DataExtractAccountId",
                        column: x => x.DataExtractAccountId,
                        principalTable: "DataExtractAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankTransferCodes_YodleeAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "YodleeAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankTransferCodes_YodleeVerifiedAccount_VerifiedAccountId",
                        column: x => x.VerifiedAccountId,
                        principalTable: "YodleeVerifiedAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanType = table.Column<string>(type: "text", nullable: true),
                    EndDate = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<string>(type: "text", nullable: true),
                    DataExtractAccountId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coverages_DataExtractAccounts_DataExtractAccountId",
                        column: x => x.DataExtractAccountId,
                        principalTable: "DataExtractAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataExtractDatasets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    UpdateEligibility = table.Column<string>(type: "text", nullable: true),
                    AdditionalStatus = table.Column<string>(type: "text", nullable: true),
                    NextUpdateScheduled = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastUpdateAttempt = table.Column<string>(type: "text", nullable: true),
                    DataExtractAccountId = table.Column<long>(type: "bigint", nullable: true),
                    DataExtractProviderAccountId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataExtractDatasets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataExtractDatasets_DataExtractAccounts_DataExtractAccountId",
                        column: x => x.DataExtractAccountId,
                        principalTable: "DataExtractAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataExtractDatasets_DataExtractProviderAccounts_DataExtract~",
                        column: x => x.DataExtractProviderAccountId,
                        principalTable: "DataExtractProviderAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RewardBalances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpiryDate = table.Column<string>(type: "text", nullable: true),
                    BalanceToReward = table.Column<string>(type: "text", nullable: true),
                    BalanceType = table.Column<string>(type: "text", nullable: true),
                    Balance = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BalanceToLevel = table.Column<string>(type: "text", nullable: true),
                    Units = table.Column<string>(type: "text", nullable: true),
                    DataExtractAccountId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardBalances_DataExtractAccounts_DataExtractAccountId",
                        column: x => x.DataExtractAccountId,
                        principalTable: "DataExtractAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: true),
                    SourceId = table.Column<string>(type: "text", nullable: true),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    CusIpNumber = table.Column<string>(type: "text", nullable: true),
                    HighLevelCategoryId = table.Column<int>(type: "integer", nullable: false),
                    DetailCategoryId = table.Column<int>(type: "integer", nullable: false),
                    DescriptionId = table.Column<long>(type: "bigint", nullable: true),
                    Memo = table.Column<string>(type: "text", nullable: true),
                    SettleDate = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    BaseType = table.Column<string>(type: "text", nullable: true),
                    CategorySource = table.Column<string>(type: "text", nullable: true),
                    PrincipalId = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdated = table.Column<string>(type: "text", nullable: true),
                    InterestId = table.Column<long>(type: "bigint", nullable: true),
                    PriceId = table.Column<long>(type: "bigint", nullable: true),
                    CommissionId = table.Column<long>(type: "bigint", nullable: true),
                    YodleeTransactionId = table.Column<long>(type: "bigint", nullable: false),
                    AmountId = table.Column<long>(type: "bigint", nullable: true),
                    CheckNumber = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Valoren = table.Column<string>(type: "text", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false),
                    MerchantId = table.Column<long>(type: "bigint", nullable: true),
                    SeDol = table.Column<string>(type: "text", nullable: true),
                    TransactionDate = table.Column<string>(type: "text", nullable: true),
                    CategoryType = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<string>(type: "text", nullable: true),
                    SourceType = table.Column<string>(type: "text", nullable: true),
                    Container = table.Column<string>(type: "text", nullable: true),
                    PostDate = table.Column<string>(type: "text", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "integer", nullable: false),
                    SubType = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    RunningBalanceId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    HoldingDescription = table.Column<string>(type: "text", nullable: true),
                    Isin = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DataExtractUserDataId = table.Column<long>(type: "bigint", nullable: true),
                    TransactionCriteriaId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_DataExtractUserDatas_DataExtractUserData~",
                        column: x => x.DataExtractUserDataId,
                        principalTable: "DataExtractUserDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_Descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_Principals_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_RunningBalances_AmountId",
                        column: x => x.AmountId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_RunningBalances_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_RunningBalances_InterestId",
                        column: x => x.InterestId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_RunningBalances_PriceId",
                        column: x => x.PriceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_RunningBalances_RunningBalanceId",
                        column: x => x.RunningBalanceId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeTransactions_TransactionCriterias_TransactionCriteria~",
                        column: x => x.TransactionCriteriaId,
                        principalTable: "TransactionCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeVerificationAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    IdType = table.Column<string>(type: "text", nullable: true),
                    BankTransferCodeId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeVerificationAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeVerificationAccount_BankTransferCodes_BankTransferCod~",
                        column: x => x.BankTransferCodeId,
                        principalTable: "BankTransferCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeAmounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coverId = table.Column<long>(type: "bigint", nullable: true),
                    UnitType = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    LimitType = table.Column<string>(type: "text", nullable: true),
                    MetId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    CoverageId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeAmounts_Coverages_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "Coverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAmounts_RunningBalances_coverId",
                        column: x => x.coverId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YodleeAmounts_RunningBalances_MetId",
                        column: x => x.MetId,
                        principalTable: "RunningBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeIntermediary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IntermediaryValue = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeIntermediary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeIntermediary_YodleeTransactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "YodleeTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YodleeVerification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    VerificationStatus = table.Column<string>(type: "text", nullable: true),
                    ProviderAccountId = table.Column<long>(type: "bigint", nullable: false),
                    VerificationType = table.Column<string>(type: "text", nullable: true),
                    RemainingAttempts = table.Column<int>(type: "integer", nullable: false),
                    VerificationDate = table.Column<string>(type: "text", nullable: true),
                    YodleeVerificationId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YodleeVerification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YodleeVerification_YodleeVerificationAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "YodleeVerificationAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalances_AvailableBalanceId",
                table: "AccountBalances",
                column: "AvailableBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalances_BalanceId",
                table: "AccountBalances",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalances_CashId",
                table: "AccountBalances",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalances_CurrentBalanceId",
                table: "AccountBalances",
                column: "CurrentBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalances_TotalBalanceId",
                table: "AccountBalances",
                column: "TotalBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AddManualAccounts_AddressId",
                table: "AddManualAccounts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddManualAccounts_AmountDueId",
                table: "AddManualAccounts",
                column: "AmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_AddManualAccounts_BalanceId",
                table: "AddManualAccounts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AddManualAccounts_HomeValueId",
                table: "AddManualAccounts",
                column: "HomeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProfileId",
                table: "Addresses",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetClassifications_HoldingId",
                table: "AssetClassifications",
                column: "HoldingId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_ContainerAttributesId",
                table: "Attributes",
                column: "ContainerAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_ProvidersDatasetId",
                table: "Attributes",
                column: "ProvidersDatasetId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransferCodes_AccountId",
                table: "BankTransferCodes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransferCodes_DataExtractAccountId",
                table: "BankTransferCodes",
                column: "DataExtractAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransferCodes_VerifiedAccountId",
                table: "BankTransferCodes",
                column: "VerifiedAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_ProviderId",
                table: "Capabilities",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerAttributes_BANKId",
                table: "ContainerAttributes",
                column: "BANKId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerAttributes_CREDITCARDId",
                table: "ContainerAttributes",
                column: "CREDITCARDId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerAttributes_INSURANCEId",
                table: "ContainerAttributes",
                column: "INSURANCEId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerAttributes_INVESTMENTId",
                table: "ContainerAttributes",
                column: "INVESTMENTId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerAttributes_LOANId",
                table: "ContainerAttributes",
                column: "LOANId");

            migrationBuilder.CreateIndex(
                name: "IX_Coverages_DataExtractAccountId",
                table: "Coverages",
                column: "DataExtractAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts__401kLoanId",
                table: "DataExtractAccounts",
                column: "_401kLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_AddressId",
                table: "DataExtractAccounts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_AmountDueId",
                table: "DataExtractAccounts",
                column: "AmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_AnnuityBalanceId",
                table: "DataExtractAccounts",
                column: "AnnuityBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_AvailableBalanceId",
                table: "DataExtractAccounts",
                column: "AvailableBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_AvailableCashId",
                table: "DataExtractAccounts",
                column: "AvailableCashId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_AvailableCreditId",
                table: "DataExtractAccounts",
                column: "AvailableCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_BalanceId",
                table: "DataExtractAccounts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_CashId",
                table: "DataExtractAccounts",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_CashValueId",
                table: "DataExtractAccounts",
                column: "CashValueId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_CurrentBalanceId",
                table: "DataExtractAccounts",
                column: "CurrentBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_DataExtractUserDataId",
                table: "DataExtractAccounts",
                column: "DataExtractUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_DeathBenefitId",
                table: "DataExtractAccounts",
                column: "DeathBenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_EscrowBalanceId",
                table: "DataExtractAccounts",
                column: "EscrowBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_FaceAmountId",
                table: "DataExtractAccounts",
                column: "FaceAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_HomeValueId",
                table: "DataExtractAccounts",
                column: "HomeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_InterestPaidLastYearId",
                table: "DataExtractAccounts",
                column: "InterestPaidLastYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_InterestPaidYTDId",
                table: "DataExtractAccounts",
                column: "InterestPaidYTDId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_LastEmployeeContributionAmountId",
                table: "DataExtractAccounts",
                column: "LastEmployeeContributionAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_LastPaymentAmountId",
                table: "DataExtractAccounts",
                column: "LastPaymentAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_LastPaymentId",
                table: "DataExtractAccounts",
                column: "LastPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_LoanPayoffAmountId",
                table: "DataExtractAccounts",
                column: "LoanPayoffAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_LoanPayoffDetailsId",
                table: "DataExtractAccounts",
                column: "LoanPayoffDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_MarginBalanceId",
                table: "DataExtractAccounts",
                column: "MarginBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_MaturityAmountId",
                table: "DataExtractAccounts",
                column: "MaturityAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_MinimumAmountDueId",
                table: "DataExtractAccounts",
                column: "MinimumAmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_MoneyMarketBalanceId",
                table: "DataExtractAccounts",
                column: "MoneyMarketBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_OriginalLoanAmountId",
                table: "DataExtractAccounts",
                column: "OriginalLoanAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_OverDraftLimitId",
                table: "DataExtractAccounts",
                column: "OverDraftLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_PremiumId",
                table: "DataExtractAccounts",
                column: "PremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_PrincipalBalanceId",
                table: "DataExtractAccounts",
                column: "PrincipalBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_RecurringPaymentId",
                table: "DataExtractAccounts",
                column: "RecurringPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_RemainingBalanceId",
                table: "DataExtractAccounts",
                column: "RemainingBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_RunningBalanceId",
                table: "DataExtractAccounts",
                column: "RunningBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_ShortBalanceId",
                table: "DataExtractAccounts",
                column: "ShortBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_TotalCashLimitId",
                table: "DataExtractAccounts",
                column: "TotalCashLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_TotalCreditLimitId",
                table: "DataExtractAccounts",
                column: "TotalCreditLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_TotalCreditLineId",
                table: "DataExtractAccounts",
                column: "TotalCreditLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_TotalUnvestedBalanceId",
                table: "DataExtractAccounts",
                column: "TotalUnvestedBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractAccounts_TotalVestedBalanceId",
                table: "DataExtractAccounts",
                column: "TotalVestedBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractDatasets_DataExtractAccountId",
                table: "DataExtractDatasets",
                column: "DataExtractAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractDatasets_DataExtractProviderAccountId",
                table: "DataExtractDatasets",
                column: "DataExtractProviderAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractProviderAccounts_DataExtractUserDataId",
                table: "DataExtractProviderAccounts",
                column: "DataExtractUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractUserDatas_DataId",
                table: "DataExtractUserDatas",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExtractUserDatas_UserId",
                table: "DataExtractUserDatas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_AccountId",
                table: "DataSets",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_ProviderAccountId",
                table: "DataSets",
                column: "ProviderAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCategories_TransactionCategoryId",
                table: "DetailCategories",
                column: "TransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ProfileId",
                table: "Emails",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_dataId",
                table: "Events",
                column: "dataId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_RowId",
                table: "Fields",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalBalanceAccounts_BalanceId",
                table: "HistoricalBalanceAccounts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalBalanceAccounts_HistoricalAccountId",
                table: "HistoricalBalanceAccounts",
                column: "HistoricalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalBalances_BalanceId",
                table: "HistoricalBalances",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalBalances_NetworthDetailId",
                table: "HistoricalBalances",
                column: "NetworthDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Holders_NameId",
                table: "Holders",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Holders_VerifiedAccountId",
                table: "Holders",
                column: "VerifiedAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_AccruedIncomeId",
                table: "Holdings",
                column: "AccruedIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_AccruedInterestId",
                table: "Holdings",
                column: "AccruedInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_CostBasisId",
                table: "Holdings",
                column: "CostBasisId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_DataExtractUserDataId",
                table: "Holdings",
                column: "DataExtractUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_HoldingsSummaryId",
                table: "Holdings",
                column: "HoldingsSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_PriceId",
                table: "Holdings",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_SpreadId",
                table: "Holdings",
                column: "SpreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_StrikePriceId",
                table: "Holdings",
                column: "StrikePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_UnvestedValueId",
                table: "Holdings",
                column: "UnvestedValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_ValueId",
                table: "Holdings",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Holdings_VestedValueId",
                table: "Holdings",
                column: "VestedValueId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingsAccounts_HoldingsSummaryId",
                table: "HoldingsAccounts",
                column: "HoldingsSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingsAccounts_ValueId",
                table: "HoldingsAccounts",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingsSummarys_ValueId",
                table: "HoldingsSummarys",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_HolderId",
                table: "Identifiers",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_ProfileId",
                table: "Identifiers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserDataId",
                table: "Links",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayoffDetails_OutstandingBalanceId",
                table: "LoanPayoffDetails",
                column: "OutstandingBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayoffDetails_PayoffAmountId",
                table: "LoanPayoffDetails",
                column: "PayoffAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginForms_ProviderAccountId",
                table: "LoginForms",
                column: "ProviderAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginForms_ProviderId",
                table: "LoginForms",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_AddressId",
                table: "Merchants",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_ContactId",
                table: "Merchants",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CoordinatesId",
                table: "Merchants",
                column: "CoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Networths_AssetId",
                table: "Networths",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Networths_LiabilityId",
                table: "Networths",
                column: "LiabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Networths_NetworthId",
                table: "Networths",
                column: "NetworthId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ProfileId",
                table: "PhoneNumbers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_NameId",
                table: "Profiles",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProviderAccountProfileId",
                table: "Profiles",
                column: "ProviderAccountProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAccounts_PreferencesId",
                table: "ProviderAccounts",
                column: "PreferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderCounts_TotalId",
                table: "ProviderCounts",
                column: "TotalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersDatasets_ProviderId",
                table: "ProvidersDatasets",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardBalances_DataExtractAccountId",
                table: "RewardBalances",
                column: "DataExtractAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Rows_LoginFormId",
                table: "Rows",
                column: "LoginFormId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleClauses_RuleId",
                table: "RuleClauses",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityHoldings_SecurityId",
                table: "SecurityHoldings",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_StockExchangeDetails_SecurityId",
                table: "StockExchangeDetails",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryDetails_CreditTotalId",
                table: "SummaryDetails",
                column: "CreditTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryDetails_DebitTotalId",
                table: "SummaryDetails",
                column: "DebitTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryDetails_SummaryId",
                table: "SummaryDetails",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Summarys_CreditTotalId",
                table: "Summarys",
                column: "CreditTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_Summarys_DebitTotalId",
                table: "Summarys",
                column: "DebitTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_Summarys_LinksId",
                table: "Summarys",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_Summarys_TransactionsSummaryId",
                table: "Summarys",
                column: "TransactionsSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCriterias_VerifyAccountDTOId",
                table: "TransactionCriterias",
                column: "VerifyAccountDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsSummarys_CreditTotalId",
                table: "TransactionsSummarys",
                column: "CreditTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsSummarys_DebitTotalId",
                table: "TransactionsSummarys",
                column: "DebitTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsSummarys_LinksId",
                table: "TransactionsSummarys",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateAccountDetails_AddressId",
                table: "UpdateAccountDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateAccountDetails_AmountDueId",
                table: "UpdateAccountDetails",
                column: "AmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateAccountDetails_BalanceId",
                table: "UpdateAccountDetails",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateAccountDetails_HomeValueId",
                table: "UpdateAccountDetails",
                column: "HomeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateProviderAccountAttributes_ContainerAttributesId",
                table: "UpdateProviderAccountAttributes",
                column: "ContainerAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateProviderAccountAttributes_UpdateProviderAccountDataSe~",
                table: "UpdateProviderAccountAttributes",
                column: "UpdateProviderAccountDataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDatas_UserId",
                table: "UserDatas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_AmountDueId",
                table: "YodleeAccounts",
                column: "AmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_AvailableBalanceId",
                table: "YodleeAccounts",
                column: "AvailableBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_AvailableCashId",
                table: "YodleeAccounts",
                column: "AvailableCashId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_AvailableCreditId",
                table: "YodleeAccounts",
                column: "AvailableCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_BalanceId",
                table: "YodleeAccounts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_CashId",
                table: "YodleeAccounts",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_CurrentBalanceId",
                table: "YodleeAccounts",
                column: "CurrentBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_LastEmployeeContributionAmountId",
                table: "YodleeAccounts",
                column: "LastEmployeeContributionAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_LastPaymentAmountId",
                table: "YodleeAccounts",
                column: "LastPaymentAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_MarginBalanceId",
                table: "YodleeAccounts",
                column: "MarginBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_MinimumAmountDueId",
                table: "YodleeAccounts",
                column: "MinimumAmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_OriginalLoanAmountId",
                table: "YodleeAccounts",
                column: "OriginalLoanAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_PrincipalBalanceId",
                table: "YodleeAccounts",
                column: "PrincipalBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_RunningBalanceId",
                table: "YodleeAccounts",
                column: "RunningBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_TotalCashLimitId",
                table: "YodleeAccounts",
                column: "TotalCashLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_TotalCreditLineId",
                table: "YodleeAccounts",
                column: "TotalCreditLineId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAccounts_VerifyAccountDTOId",
                table: "YodleeAccounts",
                column: "VerifyAccountDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAmounts_CoverageId",
                table: "YodleeAmounts",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAmounts_coverId",
                table: "YodleeAmounts",
                column: "coverId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeAmounts_MetId",
                table: "YodleeAmounts",
                column: "MetId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeIntermediary_TransactionId",
                table: "YodleeIntermediary",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeRuleClaus_TransactionCategorizationRuleId",
                table: "YodleeRuleClaus",
                column: "TransactionCategorizationRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_AmountDueId",
                table: "YodleeStatements",
                column: "AmountDueId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_CashAdvanceId",
                table: "YodleeStatements",
                column: "CashAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_InterestAmountId",
                table: "YodleeStatements",
                column: "InterestAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_LastPaymentAmountId",
                table: "YodleeStatements",
                column: "LastPaymentAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_LoanBalanceId",
                table: "YodleeStatements",
                column: "LoanBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_MinimumPaymentId",
                table: "YodleeStatements",
                column: "MinimumPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_NewChargesId",
                table: "YodleeStatements",
                column: "NewChargesId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeStatements_PrincipalAmountId",
                table: "YodleeStatements",
                column: "PrincipalAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_AmountId",
                table: "YodleeTransactions",
                column: "AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_CommissionId",
                table: "YodleeTransactions",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_DataExtractUserDataId",
                table: "YodleeTransactions",
                column: "DataExtractUserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_DescriptionId",
                table: "YodleeTransactions",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_InterestId",
                table: "YodleeTransactions",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_MerchantId",
                table: "YodleeTransactions",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_PriceId",
                table: "YodleeTransactions",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_PrincipalId",
                table: "YodleeTransactions",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_RunningBalanceId",
                table: "YodleeTransactions",
                column: "RunningBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeTransactions_TransactionCriteriaId",
                table: "YodleeTransactions",
                column: "TransactionCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeUser_AddressId",
                table: "YodleeUser",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeUser_NameId",
                table: "YodleeUser",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeUser_PreferencesId",
                table: "YodleeUser",
                column: "PreferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeVerification_AccountId",
                table: "YodleeVerification",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeVerificationAccount_BankTransferCodeId",
                table: "YodleeVerificationAccount",
                column: "BankTransferCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeVerifiedAccount_AvailableBalanceId",
                table: "YodleeVerifiedAccount",
                column: "AvailableBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeVerifiedAccount_BalanceId",
                table: "YodleeVerifiedAccount",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeVerifiedAccount_CashId",
                table: "YodleeVerifiedAccount",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeVerifiedAccount_CurrentBalanceId",
                table: "YodleeVerifiedAccount",
                column: "CurrentBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_YodleeVerifiedAccount_FullAccountNumberListId",
                table: "YodleeVerifiedAccount",
                column: "FullAccountNumberListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBalances");

            migrationBuilder.DropTable(
                name: "AddManualAccounts");

            migrationBuilder.DropTable(
                name: "AddManualResponseAccounts");

            migrationBuilder.DropTable(
                name: "AssetClassificationLists");

            migrationBuilder.DropTable(
                name: "AssetClassifications");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Capabilities");

            migrationBuilder.DropTable(
                name: "DataExtractDatasets");

            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.DropTable(
                name: "DetailCategories");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "HistoricalBalanceAccounts");

            migrationBuilder.DropTable(
                name: "HistoricalBalances");

            migrationBuilder.DropTable(
                name: "HoldingsAccounts");

            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "NotificationEvent");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "ProviderCounts");

            migrationBuilder.DropTable(
                name: "PublicKeys");

            migrationBuilder.DropTable(
                name: "RewardBalances");

            migrationBuilder.DropTable(
                name: "RuleClauses");

            migrationBuilder.DropTable(
                name: "SecurityHoldings");

            migrationBuilder.DropTable(
                name: "StockExchangeDetails");

            migrationBuilder.DropTable(
                name: "SummaryDetails");

            migrationBuilder.DropTable(
                name: "UpdateAccountDetails");

            migrationBuilder.DropTable(
                name: "UpdateProviderAccountAttributes");

            migrationBuilder.DropTable(
                name: "UpdateProviderAccountFields");

            migrationBuilder.DropTable(
                name: "VerifyAccountTransactionCriterias");

            migrationBuilder.DropTable(
                name: "YodleeAccessTokens");

            migrationBuilder.DropTable(
                name: "YodleeAmounts");

            migrationBuilder.DropTable(
                name: "YodleeIntermediary");

            migrationBuilder.DropTable(
                name: "YodleeRuleClaus");

            migrationBuilder.DropTable(
                name: "YodleeStatements");

            migrationBuilder.DropTable(
                name: "YodleeUser");

            migrationBuilder.DropTable(
                name: "YodleeVerification");

            migrationBuilder.DropTable(
                name: "Holdings");

            migrationBuilder.DropTable(
                name: "ProvidersDatasets");

            migrationBuilder.DropTable(
                name: "DataExtractProviderAccounts");

            migrationBuilder.DropTable(
                name: "TransactionCategories");

            migrationBuilder.DropTable(
                name: "Rows");

            migrationBuilder.DropTable(
                name: "HistoricalAccounts");

            migrationBuilder.DropTable(
                name: "Networths");

            migrationBuilder.DropTable(
                name: "Holders");

            migrationBuilder.DropTable(
                name: "UserDatas");

            migrationBuilder.DropTable(
                name: "Totals");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Security");

            migrationBuilder.DropTable(
                name: "Summarys");

            migrationBuilder.DropTable(
                name: "ContainerAttributes");

            migrationBuilder.DropTable(
                name: "UpdateProviderAccountDataSets");

            migrationBuilder.DropTable(
                name: "Coverages");

            migrationBuilder.DropTable(
                name: "YodleeTransactions");

            migrationBuilder.DropTable(
                name: "TransactionCategorizationRules");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "YodleeVerificationAccount");

            migrationBuilder.DropTable(
                name: "HoldingsSummarys");

            migrationBuilder.DropTable(
                name: "LoginForms");

            migrationBuilder.DropTable(
                name: "TransactionsSummarys");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Principals");

            migrationBuilder.DropTable(
                name: "TransactionCriterias");

            migrationBuilder.DropTable(
                name: "BankTransferCodes");

            migrationBuilder.DropTable(
                name: "ProviderAccounts");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "TransactionsLinks");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "DataExtractAccounts");

            migrationBuilder.DropTable(
                name: "YodleeAccounts");

            migrationBuilder.DropTable(
                name: "YodleeVerifiedAccount");

            migrationBuilder.DropTable(
                name: "ProviderAccountPreference");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "DataExtractUserDatas");

            migrationBuilder.DropTable(
                name: "LoanPayoffDetails");

            migrationBuilder.DropTable(
                name: "VerifyAccountDTOs");

            migrationBuilder.DropTable(
                name: "FullAccountNumberLists");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "DataExtractUsers");

            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "RunningBalances");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "UserProfileDetailProviderAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeWrapperIntegrationRequestLog",
                table: "YodleeWrapperIntegrationRequestLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeWrapperIntegrationConfigurations",
                table: "YodleeWrapperIntegrationConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeWrapperIntegrationAuthTokens",
                table: "YodleeWrapperIntegrationAuthTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YodleeWrapperIntegrationApiKeys",
                table: "YodleeWrapperIntegrationApiKeys");

            migrationBuilder.RenameTable(
                name: "YodleeWrapperIntegrationRequestLog",
                newName: "YodleeRequestLog");

            migrationBuilder.RenameTable(
                name: "YodleeWrapperIntegrationConfigurations",
                newName: "YodleeConfigurations");

            migrationBuilder.RenameTable(
                name: "YodleeWrapperIntegrationAuthTokens",
                newName: "YodleeAuthTokens");

            migrationBuilder.RenameTable(
                name: "YodleeWrapperIntegrationApiKeys",
                newName: "YodleeApiKeys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeRequestLog",
                table: "YodleeRequestLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeConfigurations",
                table: "YodleeConfigurations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeAuthTokens",
                table: "YodleeAuthTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YodleeApiKeys",
                table: "YodleeApiKeys",
                column: "Id");
        }
    }
}
