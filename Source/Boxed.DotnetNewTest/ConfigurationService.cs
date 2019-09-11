namespace Boxed.DotnetNewTest
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The configuration service.
    /// </summary>
    public static class ConfigurationService
    {
        /// <summary>
        /// Gets the temporary directory path.
        /// </summary>
        /// <returns>The temporary directory path.</returns>
        public static string GetTempDirectoryPath()
        {
            // Don't want to overwork my SSD drive, so use the D drive where available.
            var drivePath = DriveInfo
                .GetDrives()
                .Where(x => x.DriveType == DriveType.Fixed)
                .OrderByDescending(x => string.Equals(x.Name, @"D:\", StringComparison.Ordinal))
                .FirstOrDefault()
                ?.Name;
            if (drivePath == null)
            {
                return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            }

            return Path.Combine(drivePath, "Temp", Guid.NewGuid().ToString());
        }
    }
}
