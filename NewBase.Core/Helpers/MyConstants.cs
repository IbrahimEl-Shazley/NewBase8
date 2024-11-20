﻿using NewBase.Core.Models;
using NewBase.Core.ExtensionsMethods;
using System.IO;

namespace NewBase.Core.Helpers
{
    public static class MyConstants
    {
        #region project roots
        public static string Project => "NewBase";
        public static string Controller => $"{Project}.API.Controllers";
        public static string SchemaEntities => $"{Project}.Data.Entities.Schema";
        #endregion


        #region JSON 
        public static string PermissionCheckerPath => Path.Combine(Hosting.WebRootPath, "Json", "permission-checker.json").ToUniformedPath();
        public static string HardDeletePath => Path.Combine(Hosting.WebRootPath, "Json", "allowed-hard-delete.json").ToUniformedPath();
        #endregion


        #region Localization
        public static string GeneralLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "general-localization.json").ToUniformedPath();
        public static string ReportslLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "reports-localization.json").ToUniformedPath();
        public static string ValidationLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "fluent-validation-localization.json").ToUniformedPath();
        #endregion


        #region Seed
        public static string SeedRoot => Path.Combine(Hosting.WebRootPath, "Seed").ToUniformedPath();
        #endregion


        #region SqlSeed
        public static string SqlSeedRoot => Path.Combine(Hosting.WebRootPath, "SqlSeed").ToUniformedPath();
        public static string BrandTypeSqlSeed => Path.Combine(SqlSeedRoot, "LOOKUP.BrandType.Table.sql").ToUniformedPath();
        #endregion
    }
}