using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace RMS
{
    public class DataPersistenceSystem : MonoBehaviour
    {
        private const string ConfigurationFilePath = "/Configuration.dat";
        private const string PlayerFilePath = "/Player.dat";

        public static ConfigurationModel configurationModel;

        public void Awake()
        {
            LoadConfiguration();
        }

        public static void SaveConfiguration()
        {
            SaveData(configurationModel, ConfigurationFilePath);
        }

        public static void LoadConfiguration()
        {
            object loadData = LoadData(ConfigurationFilePath);

            if (loadData != null)
                configurationModel = (ConfigurationModel)loadData;
            else
                configurationModel = new ConfigurationModel();
        }

        private static void SaveData(object data, string dataFilePath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + dataFilePath);
            bf.Serialize(file, data);
            file.Close();
        }

        private static object LoadData(string dataFilePath)
        {
            if (File.Exists(Application.persistentDataPath + dataFilePath))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                FileStream fileStream = File.Open(Application.persistentDataPath + dataFilePath, FileMode.Open);
                object data = bFormatter.Deserialize(fileStream);
                fileStream.Close();

                if (data != null)
                {
                    return data;
                }
            }

            return null;
        }
    }
}