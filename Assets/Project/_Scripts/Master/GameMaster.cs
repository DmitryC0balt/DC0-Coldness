using Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Audio;

namespace Scripts.Master
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private GameData _gameData;
        [SerializeField] private SettingsData _settingsData;
        [SerializeField] private SettingsData _defaultSettingsData;
        [Header("Datasets")]
        [SerializeField] private PlayerStatsDataset _playerStatsDataset;
        [SerializeField] private ConversationDataset _conversationDataset;


        public PlayerStatsDataset playerStatsDataset => _playerStatsDataset;
        public ConversationDataset conversationDataset => _conversationDataset;


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