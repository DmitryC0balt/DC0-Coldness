using Scripts.Loading;
using UnityEngine;
using UnityEngine.Audio;

namespace Scripts.Master
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private GameData _gameData;
        [SerializeField] private SettingsData _settingsData;
        [SerializeField] private SettingsData _defaultSettingsData;


        public DataStruct GetDataStruct()
        {
            var dataStruct = new DataStruct
            {
                gameData = _gameData,
                settingsData = _settingsData,
                defaultSettingsData = _defaultSettingsData
            };

            return dataStruct;
        }
    }
}