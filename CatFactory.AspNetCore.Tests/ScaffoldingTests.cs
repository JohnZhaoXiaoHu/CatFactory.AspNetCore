﻿using CatFactory.EntityFrameworkCore;
using CatFactory.SqlServer;
using Xunit;

namespace CatFactory.AspNetCore.Tests
{
    public class ScaffoldingTests
    {
        [Fact]
        public void TestScaffoldingWebApiFromOnlineStoreDatabase()
        {
            // Import database
            var database = SqlServerDatabaseFactory
                .Import("server=(local);database=OnlineStore;integrated security=yes;", "dbo.sysdiagrams");

            // Create instance of Entity Framework Core Project
            var entityFrameworkProject = new EntityFrameworkCoreProject
            {
                Name = "OnlineStore.Core",
                Database = database,
                OutputDirectory = "C:\\Temp\\CatFactory.AspNetCore\\OnlineStore.Core"
            };

            // Apply settings for project
            entityFrameworkProject.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
                settings.ConcurrencyToken = "Timestamp";
                settings.AuditEntity = new AuditEntity
                {
                    CreationUserColumnName = "CreationUser",
                    CreationDateTimeColumnName = "CreationDateTime",
                    LastUpdateUserColumnName = "LastUpdateUser",
                    LastUpdateDateTimeColumnName = "LastUpdateDateTime"
                };
            });

            entityFrameworkProject.Selection("Sales.OrderHeader", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            entityFrameworkProject.BuildFeatures();

            // Scaffolding =^^=
            entityFrameworkProject
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();

            var aspNetCoreProject = entityFrameworkProject
                .CreateAspNetCoreProject("OnlineStore.WebAPI", "C:\\Temp\\CatFactory.AspNetCore\\OnlineStore.WebAPI");

            aspNetCoreProject.GlobalSelection(settings => settings.ForceOverwrite = true);

            // Add event handlers to before and after of scaffold

            aspNetCoreProject.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            aspNetCoreProject.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            aspNetCoreProject.ScaffoldAspNetCore();
        }

        [Fact]
        public void TestScaffoldingWebApiFromNorthwindDatabase()
        {
            // Import database
            var database = SqlServerDatabaseFactory
                .Import("server=(local);database=Northwind;integrated security=yes;", "dbo.sysdiagrams");

            // Create instance of Entity Framework Core Project
            var entityFrameworkProject = new EntityFrameworkCoreProject
            {
                Name = "Northwind.Core",
                Database = database,
                OutputDirectory = "C:\\Temp\\CatFactory.AspNetCore\\Northwind.Core"
            };

            // Apply settings for project
            entityFrameworkProject.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
                settings.ConcurrencyToken = "Timestamp";
                settings.AuditEntity = new AuditEntity
                {
                    CreationUserColumnName = "CreationUser",
                    CreationDateTimeColumnName = "CreationDateTime",
                    LastUpdateUserColumnName = "LastUpdateUser",
                    LastUpdateDateTimeColumnName = "LastUpdateDateTime"
                };
            });

            entityFrameworkProject.Selection("dbo.Orders", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            entityFrameworkProject.BuildFeatures();

            // Scaffolding =^^=
            entityFrameworkProject
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();

            var aspNetCoreProject = entityFrameworkProject
                .CreateAspNetCoreProject("Northwind.WebAPI", "C:\\Temp\\CatFactory.AspNetCore\\Northwind.WebAPI");

            aspNetCoreProject.GlobalSelection(settings => settings.ForceOverwrite = true);

            // Add event handlers to before and after of scaffold

            aspNetCoreProject.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            aspNetCoreProject.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            aspNetCoreProject.ScaffoldAspNetCore();
        }
    }
}
