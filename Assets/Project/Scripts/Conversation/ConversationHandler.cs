using UnityEngine.UI;
using Scripts.Player;
using UnityEngine;


namespace Scripts.Conversation
{
    public class ConversationHandler : MonoBehaviour
    {
        [Header("Start conversation presets")]
        [SerializeField] private ConversationPresetsStruct _conversationPresetsStruct;
        [Space(10)]

        [Header("Screen elements setup")]
        [SerializeField] private ScreenElementsStruct _screenElementsStruct;
        [Space(10)]

        [Header("Conversation prefabs")]
        [SerializeField] private ConversationPrefabsStruct _conversationPrefabsStruct;
        [Space(10)]

        [Header("Remark color settings")]
        [SerializeField] private RemarkColorStruct _remarkColorStruct;


        

        //Начало диалога (проверка необходимых условий перед его началом)
        public void StartConversation()
        {
            
        }


        //Попытка поймать ближайшую цель для диалога (в разумно заданных пределах)        
        private void GetNearestConversationTarget()
        {
            
        }


        //подготовка экрана диалога перед его началом (Развесить портреты)
        private void PrepareConversationScreen()
        {
            
        }


        //Открыть диалоговое окно (после подготовки)
        private void ShowConversationScreen(bool isActive)
        {
            if (isActive)
            {
                _screenElementsStruct.conversationScreen.gameObject.SetActive(true);
                return;
            }

            ClearContentContainer();
            _screenElementsStruct.conversationScreen.gameObject.SetActive(false);
        }


        //Добавить ремарку (после нажатия на кнопку)
        private void AddRemark()
        {
            
        }


        //Добавить имя говорящего
        private void AddName()
        {
            
        }


        //Добавить кнопку (опцию для продолжения диалога)
        private void AddButton()
        {
            
        }


        //Добавить реплику
        private void AddNode()
        {
            
        }


        //Очистить контейнер с контентом
        private void ClearContentContainer()
        {
            
        }


        //Очистить контейнер от кнопок с опциями (после прожатия опции)
        private void ClearAddedButtonsList()
        {
            
        }

    }


    [System.Serializable]
    public struct ConversationPresetsStruct
    {
        public PlayerHandler player;
        public float minimalConversationDistance;
    }


    [System.Serializable]
    public struct ScreenElementsStruct
    {
        public RectTransform conversationScreen;
        public Image leftImage;
        public Image rightImage;
        public RectTransform contentContainer;
    }


    [System.Serializable]
    public struct ConversationPrefabsStruct
    {
        public GameObject dialogueNode;
        public GameObject dialogueOption;
        public GameObject speakerName;
        public GameObject dialogueRemark;
    }


    [System.Serializable]
    public struct RemarkColorStruct
    {
        [ColorUsage(true)] public Color drunkRemarkColor;
        [ColorUsage(true)] public Color magicRemarkColor;
        [ColorUsage(true)] public Color loaigRemarkColor;
        [ColorUsage(true)] public Color healthRemarkColor;
        [ColorUsage(true)] public Color inventoryRemarkColor;
    }
}