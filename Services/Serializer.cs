using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CashalotHelper.Models;

namespace CashalotHelper.Services
{
    public static class Serializer
    {
        public static XmlDocument SerializaBackup(Backup targetObject)
        {
            XmlDocument xmlBackupInfo = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Backup));
            using (MemoryStream memStream = new MemoryStream())
            {
                serializer.Serialize(memStream, targetObject);
                memStream.Position = 0;
                XmlReaderSettings settings = new XmlReaderSettings() ;
                settings.IgnoreWhitespace = true;
                using (var reader = XmlReader.Create(memStream, settings))
                {
                    xmlBackupInfo = new XmlDocument();
                    xmlBackupInfo.Load(reader);
                }
            }
            return xmlBackupInfo;
        }


        //TODO: Говнокод пофиксить
        public static Backup DeserializeBackup(String backupXmlPath)
        {
            Backup deserializedBackup;
            XmlDocument xml = FSControler.GetXmlFromFile(backupXmlPath);
            if (xml != new XmlDocument())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Backup));
                using (XmlReader reader = new XmlNodeReader(xml))
                {
                    deserializedBackup = (Backup)serializer.Deserialize(reader);
                }
            }
            else
            {
                deserializedBackup = null;
            }
                return deserializedBackup;
        }
    }
}
