﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.DataAccessLayer
{
    public class DatabaseInitializer : ISeeder
    {
        private readonly SchoolBookContext _ctx;
        private readonly IWebHostEnvironment _webHost;
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly IRepositories _repositories;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public DatabaseInitializer(
            SchoolBookContext ctx,
            IWebHostEnvironment webHost,
            ILogger<DatabaseInitializer> logger,
            IRepositories repositories,
            RoleManager<IdentityRole> roleManager,
            IAccountService accountService,
            IConfiguration configuration
            )
        {
            _ctx = ctx;
            _webHost = webHost;
            _logger = logger;
            _repositories = repositories;
            _roleManager = roleManager;
            _accountService = accountService;
            _configuration = configuration;
        }

        public void Seed()
        {
            SeedRoles().Wait();
            SeedUserAdmin().Wait();
            SeedGrades();
            SeedSchool();
            SeedClass();
            SeedSchoolUsers();
            _repositories.SaveChanges();
        }

        private void SeedSchoolUsers()
        {
            var student = new Student
            {
                FirstName = "Sladi",
                SecondName = "Sladkov",
                LastName = "Sladkov",
                Pin = "0510043827",
                Address = "Някъде от София",
                Town = "София",
                StartYear = 2018,
                School = _ctx.Schools.FirstOrDefault(),
                Class = _ctx.Classes.FirstOrDefault()
            };

            _ctx.Students.Add(student);
            _ctx.SaveChanges();
        }

        private async Task SeedRoles()
        {
            _logger.LogInformation("Start Seeding Roles...");

            var roleNames = Enum.GetNames(typeof(RoleTypes));

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            _logger.LogInformation("End Seeding Roles...");
        }

        private async Task SeedUserAdmin()
        {
            _logger.LogInformation("Start Seeding Admin...");

            var userSettingsSection = _configuration.GetSection("UserSettings");

            var adminModel = new RegisterInputModel
            {
                Email = userSettingsSection["Email"],
                FirstName = userSettingsSection["FirstName"],
                SecondName = userSettingsSection["SecondName"],
                LastName = userSettingsSection["LastName"],
                Password = userSettingsSection["Password"]
            };

            await _accountService.SeedAdmin(adminModel);
            _logger.LogInformation("End Seeding Admin...");
        }

        private void SeedGrades()
        {
            if (_ctx.Grades.FirstOrDefault() != null)
            {
                return;
            }

            _logger.LogInformation("Grades definition filepath ");

            var filepath = Path.Combine(_webHost.ContentRootPath,
                "DataAccessLayer/grades-bg.json");
            var gradesJson = File.ReadAllText(filepath);

            var grades =
                JsonConvert.DeserializeObject<ICollection<Grade>>(gradesJson);

            foreach (var grade in grades)
            {
                _repositories.Grades.Create(grade);
            }

            _logger.LogInformation("End Seeding Grades...");
        }

        private void SeedSchool()
        {
            if (_ctx.Schools.FirstOrDefault() != null)
            {
                return;
            }

            var defaultSchool = new School
            {
                Name = "Test School",
                Number = 0,
                Address = "Somewhere in Sofia"
            };
            _ctx.Schools.Add(defaultSchool);
            _ctx.SaveChanges();
        }

        private void SeedClass()
        {
            if (_ctx.Classes.FirstOrDefault() != null)
            {
                return;
            }

            var defaultClass = new Class
            {
                StartYear = 2019,
                Grade = 1,
                GradeLetter = 'A',
            };
            _ctx.Classes.Add(defaultClass);
            _ctx.SaveChanges();
        }

    }
}