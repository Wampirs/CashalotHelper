using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CashalotHelper.FileSystem
{
    internal class FileSystemInitializer
    {
        private readonly ILogger<FileSystemInitializer> _logger;

        public FileSystemInitializer(ILogger<FileSystemInitializer> logger)
        {
            _logger = logger;
        }

        public void Initialize()
        {
            EnsureCreated(FileSystem.MainDirectory);
            EnsureCreated(FileSystem.BackupsDirectory);
            EnsureCreated(FileSystem.BranchesDirectory);
        }

        private void EnsureCreated(string directory)
        {
            if (Directory.Exists(directory)) return;
            Directory.CreateDirectory(directory);
            _logger.LogInformation($"Створено директорію {directory}");
        }
    }
}
