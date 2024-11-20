using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBase.Context.Migrations
{
    public partial class init_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppImgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContextId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectUser_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Copon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CountUsed = table.Column<int>(type: "int", nullable: false),
                    Expirdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    limtDiscount = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoponUsed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoponId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoponUsed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOpinions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOpinions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeviceId_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceIds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryNotify",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryNotify", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryNotify_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeMessages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IntroContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntroSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePlayUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppleStoreUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroImg1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroImg2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutAppAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutAppEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescrioptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutDescrioptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutAppImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterDescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaceBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivacyPolicyAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivacyPolicyEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfUsersAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfUsersEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogExption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogExption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotifyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TextAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifyUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoponId = table.Column<int>(type: "int", nullable: false),
                    TypePay = table.Column<int>(type: "int", nullable: false),
                    Stutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViMaEntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MadaEntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveAccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestAccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLive = table.Column<bool>(type: "bit", nullable: false),
                    IsMada = table.Column<bool>(type: "bit", nullable: false),
                    LiveCheckoutUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestCheckoutUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RateProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateProvider_AspNetUsers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RateProvider_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondtionsArClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondtionsEnClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondtionsArProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondtionsEnProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsArClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsEnClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsArProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsEnProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNameSms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmsProvider = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFollowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFollowers_AspNetUsers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFollowers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderSeen = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverSeen = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedSender = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedReceiver = table.Column<bool>(type: "bit", nullable: false),
                    LastMessage = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TypeMessage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductOrService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TaxableAmount = table.Column<double>(type: "float", nullable: false),
                    TaxRate = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    SubTotalWithVat = table.Column<double>(type: "float", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderInfos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectUser_ApplicationDbUserId",
                table: "ConnectUser",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ApplicationDbUserId",
                table: "ContactUs",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceIds_UserId",
                table: "DeviceIds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryNotify_UserId",
                table: "HistoryNotify",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeMessages_UserId",
                table: "HomeMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OrderId",
                table: "Messages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyUsers_UserId",
                table: "NotifyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_OrderId",
                table: "OrderInfos",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProviderId",
                table: "Orders",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RateProvider_ProviderId",
                table: "RateProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_RateProvider_UserId",
                table: "RateProvider",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_ProviderId",
                table: "UserFollowers",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_UserId",
                table: "UserFollowers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.DropTable(
                name: "AppImgs");

            migrationBuilder.DropTable(
                name: "ConnectUser");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Copon");

            migrationBuilder.DropTable(
                name: "CoponUsed");

            migrationBuilder.DropTable(
                name: "CustomerOpinions");

            migrationBuilder.DropTable(
                name: "DeviceIds");

            migrationBuilder.DropTable(
                name: "HistoryNotify");

            migrationBuilder.DropTable(
                name: "HomeMessages");

            migrationBuilder.DropTable(
                name: "IntroContactUs");

            migrationBuilder.DropTable(
                name: "IntroSettings");

            migrationBuilder.DropTable(
                name: "LogExption");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NotifyUsers");

            migrationBuilder.DropTable(
                name: "OrderInfos");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "QuestionProvider");

            migrationBuilder.DropTable(
                name: "QuestionsClient");

            migrationBuilder.DropTable(
                name: "RateProvider");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SmsMessages");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "UserFollowers");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
