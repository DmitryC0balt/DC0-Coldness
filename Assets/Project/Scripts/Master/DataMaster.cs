using UnityEngine;

namespace Scripts.Master
{
    public class DataMaster
    {
        public GameData gameData{get;}
        public SettingsData settingsData{get;}
        public SettingsData defaultSettingsData{get;}

        public DataMaster(DataStruct dataStruct)
        {
            gameData = dataStruct.gameData;
            settingsData = dataStruct.settingsData;
            defaultSettingsData = dataStruct.defaultSettingsData;
        }
    }


    public struct DataStruct
    {
        public GameData gameData;
        public SettingsData settingsData;
        public SettingsData defaultSettingsData;
    }
}