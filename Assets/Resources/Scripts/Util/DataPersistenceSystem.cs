using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace RMS
{
    public class DataPersistenceSystem
    {
        private const string ConfigurationFilePath = "/Configuration.dat";
        private const string PlayerFilePath = "/Player.dat";

        public static ConfigurationModel configurationModel;
        public static PlayerModel playerModel;

        public void Awake()
        {
            LoadConfiguration();
        }

        public static void SaveConfiguration()
        {
            SaveData(configurationModel, ConfigurationFilePath);
        }

        public static void SavePlayer()
        {
            SaveData(playerModel, PlayerFilePath);
        }

        public static void SaveGame()
        {
            SaveConfiguration();
            SavePlayer();
        }

        public static void LoadConfiguration()
        {
            object loadData = LoadData(ConfigurationFilePath);

            if (loadData != null)
                configurationModel = (ConfigurationModel)loadData;
            else
                configurationModel = new ConfigurationModel();
        }

        public static void LoadPlayer()
        {
            object loadData = LoadData(PlayerFilePath);

            if(loadData != null)
                playerModel = (PlayerModel)loadData;
            else
                playerModel = new PlayerModel();
        }

        public static void LoadGame()
        {
            LoadConfiguration();
            LoadPlayer();

            configurationModel.Log();
            playerModel.Log();
        }

        public static bool HasSaveFile()
        {
            return File.Exists(Application.persistentDataPath + PlayerFilePath);
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