using CashalotHelper.Providers.FileSystem;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.IO;

namespace CashalotHelper.Services
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

            var file = ShellFile.FromFilePath(_fileToGetVer);
            String result = String.Empty;
            string[] ver = file.Properties.System.FileVersion.Value.Split('.');
            for (int i = 0; i < ver.Length - 1; i++)
            {
                result += ver[i];
                if (i != ver.Length - 2)
                {
                    result += ".";
                }
            }
            return result;
        }

        public bool IsAccessibly(string _pathToCheckAccess)
        {
            if (_pathToCheckAccess == null) throw new ArgumentNullException(nameof(_pathToCheckAccess));
            bool isFile = File.Exists(_pathToCheckAccess);
            bool result = true;
            if (isFile)
            {
                try
                {
                    using (FileStream fs = File.Open(_pathToCheckAccess, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) ;
                }
                catch (Exception) { result = false; }
                return result;
            }

            foreach (string file in Directory.GetFiles(_pathToCheckAccess))
            {
                IsAccessibly(file);
            }
            return result;
        }

        public bool IsExists(string _pathToEnsureExist)
        {
            if (_pathToEnsureExist == null) throw new ArgumentNullException(nameof(_pathToEnsureExist));
            bool result = false;
            if (File.Exists(_pathToEnsureExist) || Directory.Exists(_pathToEnsureExist)) result = true;
            return result;
        }

        public void CreateShortcut(string _targetFilePath, string _shortcutName)
        {
            IWshRuntimeLibrary.WshShell wshShell = new IWshRuntimeLibrary.WshShell();

            IWshRuntimeLibrary.IWshShortcut Shortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.
                CreateShortcut($"{FileSystem.BranchesDirectory}\\{_shortcutName}.lnk");

            Shortcut.TargetPath = _targetFilePath; //путь к целевому файлу

            Shortcut.Save();
        }




        ////Шлях до корневої папки бекап менеджера
        //public static readonly String backupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BackupManager";

        ///// <summary>
        ///// Вычитывает информацию о бекапе из его информационного файла
        ///// </summary>
        ///// <param name="backupXmlPath">Путь к Xml файлу с информацией о бекапе</param>
        ///// <returns>Возвращает XmlDocument содержащий сериализированный бекап</returns>
        //public static XmlDocument GetXmlFromFile(String backupXmlPath)
        //{
        //    XmlDocument resultXml = new XmlDocument();
        //    using (FileStream fileReader = new FileStream(backupXmlPath, FileMode.Open))
        //    {
        //        using (StreamReader streamReader = new StreamReader(fileReader))
        //        {
        //            String backupInfo = streamReader.ReadToEnd();
        //            try
        //            {
        //                resultXml.LoadXml(backupInfo);
        //            }
        //            catch (Exception)
        //            {
        //                throw new Exception($"{backupXmlPath} не було опрацьовано коректно");
        //            }
        //        }
        //    }
        //    return resultXml;
        //}

        ///// <summary>
        ///// Создает информационный файл содержащий сериализованный бекап 
        ///// </summary>
        ///// <param name="backup"> бекап для создания файла с информацией</param>
        //public static void SetBackupInfoFile(Backup backup)
        //{
        //    using (FileStream fs = new FileStream(backup.Path + ".xml", FileMode.OpenOrCreate))
        //    {
        //        using(StreamWriter sw = new StreamWriter(fs))
        //        {
        //            sw.WriteLine(Serializer.SerializaBackup(backup).OuterXml);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Визначає версію exe файлу
        ///// </summary>
        ///// <param name="fileToGetVersion">Путь к файлу</param>
        ///// <returns>Возвращает String с значением версии файла</returns>
        ///// 
        //public static String GetFileVersion(String fileToGetVersion)
        //{
        //    if (fileToGetVersion != null)
        //    {
        //        if (File.Exists(fileToGetVersion))
        //        {
        //            var file = ShellFile.FromFilePath(fileToGetVersion);
        //            String result = String.Empty;
        //            string[] ver = file.Properties.System.FileVersion.Value.Split('.');
        //            for (int i = 0; i < ver.Length-1; i++)
        //            {
        //                result += ver[i];
        //                if (i != ver.Length-2)
        //                {
        //                    result += ".";
        //                }
        //            }
        //            return result;
        //        }
        //        else
        //        {
        //            throw new Exception($"Шлях {fileToGetVersion} недосяжний або не існує");
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException(nameof(fileToGetVersion));
        //    }
        //}

        ///// <summary>
        ///// Удаляет файл
        ///// </summary>
        ///// <param name="fileToDel">Путь к файлу</param>
        //public static void DeleteFile(String fileToDel)
        //{
        //    if(AccessTest(fileToDel, "file"))
        //    {
        //        try
        //        { 
        //        File.Delete(fileToDel);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception($"Шлях {fileToDel} недосяжний або не існує");
        //    }
        //}

        ///// <summary>
        ///// Удаляет бекап с его инфо файлом
        ///// </summary>
        ///// <param name="backupToDel">Екземпляр бекапа</param>
        //public static void DeleteBackup(Backup backupToDel)
        //{
        //    if (backupToDel != null)
        //    {
        //        try 
        //        { 
        //            DeleteFile(backupToDel.Path);
        //            DeleteFile(backupToDel.Path + ".xml");
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.ToString());
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException();
        //    }
        //}


        ///// <summary>
        //    /// Удаляет все файлы в каталоге
        //    /// </summary>
        //    /// <param name="dirToClean">Путь к каталогу</param>
        //public static void CleanDirectory(String dirToClean)
        //{
        //    if (dirToClean != null)
        //    {
        //        if (AccessTest(dirToClean))
        //        {
        //            foreach (String file in Directory.GetFiles(dirToClean))
        //            {
        //                File.Delete(file);
        //            }
        //            foreach (String directory in Directory.GetDirectories(dirToClean))
        //            {
        //                Directory.Delete(directory, true);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception($"Шлях {dirToClean} недосяжний або не існує");
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException(nameof(dirToClean));
        //    }
        //}


        ///// <summary>
        ///// Подсчитывает число елементов в каталоге
        ///// </summary>
        ///// <param name="folderToCountFiles">Путь к каталогу</param>
        ///// <returns>Число элементов в папке</returns>
        //public static int GetFileNumber(String folderToCountFiles)
        //{
        //    if (folderToCountFiles != null)
        //    {
        //        int fileNumber = Directory.GetFiles(folderToCountFiles, "*", SearchOption.TopDirectoryOnly).Length;
        //            fileNumber += Directory.GetDirectories(folderToCountFiles, "*", SearchOption.TopDirectoryOnly).Length;
        //        return fileNumber;
        //    }
        //    throw new ArgumentNullException(nameof(folderToCountFiles));
        //}

        ///// <summary>
        //    /// Метод проверки наличия корневого каталога для бекап менеджера. Если каталога нет, то он будет создан.
        //    /// </summary>
        //public static void StartupTest()
        //{
        //    //if (!Directory.Exists(Settings.LocalBackupFolderPath))
        //    //{
        //    //    Directory.CreateDirectory(Settings.LocalBackupFolderPath);
        //    //}
        //    //if (!Directory.Exists(Settings.LocalBranchFolderPath))
        //    //{
        //    //    Directory.CreateDirectory(Settings.LocalBranchFolderPath);
        //    //}
        //}

        ////TODO: Написать автоопределение типа папка/файл
        ///// <summary>
        ///// Перевіряє чи не зайнято папку чи файл іншим процесом
        ///// </summary>
        ///// <param name="pathToTest"></param>
        ///// <param name="type"></param>
        ///// <returns>Можливість доступу до файлу або папки</returns>
        ///// <exception cref="Exception"></exception>
        ///// <exception cref="ArgumentNullException"></exception>
        //public static bool AccessTest(String pathToTest, string type="folder")
        //{
        //    bool testResult = true;
        //    if (pathToTest != null)
        //    {
        //        if (type.Equals("folder"))
        //        {
        //            if (!Directory.Exists(pathToTest))
        //            {
        //                testResult = false;
        //                throw new Exception($"Шлях до {pathToTest} недоступний або не існує");
        //            }
        //            else
        //            {
        //                foreach (String file in Directory.GetFiles(pathToTest))
        //                {
        //                    if (RestartManager.IsFileLocked(file))
        //                    {
        //                        testResult = false;
        //                    }
        //                }
        //            }
        //        }
        //        if (type.Equals("file"))
        //        {
        //            if (!File.Exists(pathToTest))
        //            {
        //                testResult = false;
        //                throw new Exception($"Шлях до {pathToTest} недоступний або не існує");
        //            }
        //            if (RestartManager.IsFileLocked(pathToTest))
        //            {
        //                testResult = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException(nameof(pathToTest));
        //    }
        //    return testResult;
        //}

        //public static List<String> GetListOfBackupPath()
        //{
        //    List<String> list = new List<String>();
        //    foreach (String backup in Directory.GetFiles(backupFolderPath, "*.zip", SearchOption.AllDirectories))
        //    {
        //        if (File.Exists(backup + ".xml"))
        //        {
        //            list.Add(backup);
        //        }
        //    }
        //    return list;
        //}

        //public static bool FileExists(String path)
        //{
        //    return File.Exists(path);
        //}

    }
}
