using System;
using Almostengr.PetFeeder.BackEnd.Constants;
using Almostengr.PetFeeder.BackEnd.Enums;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Repository;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almostengr.PetFeeder.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: nameof(PetFeederContext.SystemSettings),
                columns: new[] { nameof(SystemSetting.Name), nameof(SystemSetting.Value), nameof(SystemSetting.Created), nameof(SystemSetting.Modified) },
                values: new object[] { SettingName.FeedingMode, FeedingMode.Auto.ToString(), DateTime.Now, DateTime.Now });

            migrationBuilder.InsertData(
                table: nameof(PetFeederContext.SystemSettings),
                columns: new[] { nameof(SystemSetting.Name), nameof(SystemSetting.Value), nameof(SystemSetting.Created), nameof(SystemSetting.Modified) },
                values: new object[] { SettingName.WateringMode, WateringMode.Auto.ToString(), DateTime.Now, DateTime.Now });

            migrationBuilder.InsertData(
                table: nameof(PetFeederContext.Schedules),
                columns: new[] { nameof(Schedule.ScheduledTime), nameof(Schedule.FeedingAmount), nameof(Schedule.IsActive), nameof(Schedule.ScheduleType), nameof(Schedule.Created), nameof(Schedule.Modified) },
                values: new object[] { DateTime.Now, 2.0, true, (int)ScheduleType.Feeding, DateTime.Now, DateTime.Now });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: nameof(PetFeederContext.SystemSettings),
                keyColumn: nameof(SystemSetting.Name),
                keyValue: SettingName.FeedingMode);

            migrationBuilder.DeleteData(
                table: nameof(PetFeederContext.SystemSettings),
                keyColumn: nameof(SystemSetting.Name),
                keyValue: SettingName.WateringMode);
        }
    }
}
