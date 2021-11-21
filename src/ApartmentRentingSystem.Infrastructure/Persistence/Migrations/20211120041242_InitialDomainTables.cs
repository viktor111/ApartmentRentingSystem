using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentRentingSystem.Infrastructure.Persistence.Migrations
{
    public partial class InitialDomainTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber_CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    PhoneNumber_Number = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentAds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SquareMeters = table.Column<int>(nullable: false),
                    Options_HasFurniture = table.Column<bool>(nullable: true),
                    Options_HasParking = table.Column<bool>(nullable: true),
                    Options_HasGarden = table.Column<bool>(nullable: true),
                    Options_HasLift = table.Column<bool>(nullable: true),
                    Options_HasAirConditioner = table.Column<bool>(nullable: true),
                    Options_HasTv = table.Column<bool>(nullable: true),
                    Options_HasInternet = table.Column<bool>(nullable: true),
                    Options_HasPhone = table.Column<bool>(nullable: true),
                    Options_HasWashingMachine = table.Column<bool>(nullable: true),
                    Options_HasDishwasher = table.Column<bool>(nullable: true),
                    Options_HasRefrigerator = table.Column<bool>(nullable: true),
                    Options_HasMicrowave = table.Column<bool>(nullable: true),
                    Options_HasOven = table.Column<bool>(nullable: true),
                    Options_HasCoffeeMachine = table.Column<bool>(nullable: true),
                    Rooms_NumberOfRooms = table.Column<int>(maxLength: 10, nullable: true),
                    Rooms_NumberOfBathrooms = table.Column<int>(maxLength: 10, nullable: true),
                    Rooms_NumberOfBedrooms = table.Column<int>(maxLength: 10, nullable: true),
                    Rooms_NumberOfBalconies = table.Column<int>(maxLength: 10, nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    LandlordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentAds_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAds_LandlordId",
                table: "ApartmentAds",
                column: "LandlordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentAds");

            migrationBuilder.DropTable(
                name: "Landlords");
        }
    }
}
