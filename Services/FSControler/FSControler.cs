using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace CashalotHelper.Services.FsControler
{
    public class FSControler : IFSControler
    {
        public void CleanDirectory(string _dirToClean)
        {
            if (_dirToClean == null) throw new ArgumentNullException(nameof(_dirToClean));
            if (!IsAccessibly(_dirToClean)) throw new Exception($"Папка {_dirToClean} недосяжна або використовується іншою програмою");
            foreach (String file in Directory.GetFiles(_dirToClean))
            {
                DeleteFile(file);
            }
            foreach (String directory in Directory.GetDirectories(_dirToClean))
            {
                Directory.Delete(directory, true);
            }
        }

        public void DeleteFile(string _fileToDelete)
        {
            if (_fileToDelete == null) throw new ArgumentNullException(nameof(_fileToDelete));
            if (!IsAccessibly(_fileToDelete)) throw new Exception($"Файл {_fileToDelete} недосяжний або використовуэться ыншою програмою");
                try
                {
                    File.Delete(_fileToDelete);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Помилка при видаленні {_fileToDelete}", ex);
                }
        }

        public int GetFileNumber(string _dirToCountFiles)
        {
            if (_dirToCountFiles == null) throw new ArgumentNullException(nameof(_dirToCountFiles));
            if (!Directory.Exists(_dirToCountFiles)) throw new Exception($"Папка {_dirToCountFiles} недосяжна");

            int fileNumber = Directory.GetFiles(_dirToCountFiles, "*", SearchOption.TopDirectoryOnly).Length;
            fileNumber += Directory.GetDirectories(_dirToCountFiles, "*", SearchOption.TopDirectoryOnly).Length;
            return fileNumber;
        }

        public string GetFileVersion(string _fileToGetVer)
        {
            if (_fileToGetVer == null) throw new ArgumentNullException(nameof(_fileToGetVer));
            if (!File.Exists(_fileToGetVer)) throw new Exception($"Файл {_fileToGetVer} недосяжний");
            var fileVersion = FileVersionInfo.GetVersionInfo(_fileToGetVer);
            return fileVersion.ProductVersion;
        }

        public bool IsAccessibly(string _pathToCheckAccess)
        {
            if (_pathToCheckAccess ==null) throw new ArgumentNullException(nameof(_pathToCheckAccess));
            bool isFile = File.Exists(_pathToCheckAccess);
            if (isFile)
            {
                return TempMoveCheck(_pathToCheckAccess);
            }
            foreach (string file in Directory.GetFiles(_pathToCheckAccess))
            {
                if(!IsAccessibly(file)) return false;     
            }
            return true;
        }

        public bool IsExists(string _pathToEnsureExist)
        {
            if (_pathToEnsureExist == null) throw new ArgumentNullException(nameof(_pathToEnsureExist));
            bool result = false;
            if (File.Exists(_pathToEnsureExist)|| Directory.Exists(_pathToEnsureExist)) result= true;
            return result;
        }


        private bool TempMoveCheck(string filePath)
        {
            string tempPath = filePath + ".tmp";
            try
            {
                File.Move(filePath, tempPath);
                File.Move(tempPath, filePath);
                return true;
            }
            catch 
            {
                return false;
            }
        }
              

    }
}
