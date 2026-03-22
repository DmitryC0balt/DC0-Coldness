using Scripts.ScriptableObjects;

namespace Scripts.Master
{
    public class DataMaster
    {
        public GameData gameData{get;}
        
        public SettingsData settingsData{get;}
        public SettingsData defaultSettingsData{get;}


        public bool isGamePaused{ get; private set;}
        public bool hasSideScenes{ get; private set;}


        public DataMaster(DataStruct dataStruct)
        {
            gameData = dataStruct.gameData;
            settingsData = dataStruct.settingsData;
            defaultSettingsData = dataStruct.defaultSettingsData;

            isGamePaused = false;
            hasSideScenes = false;
        }


        public void SetPause(bool isPaused)
        {
            
        }

    }


    public struct DataStruct
    {
        public GameData gameData;
        public SettingsData settingsData;
        public SettingsData defaultSettingsData;
    }
}