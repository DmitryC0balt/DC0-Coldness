using UnityEngine.UI;
using Scripts.Player;
using UnityEngine;
using Scripts.GUI;
using System.Collections.Generic;
using Scripts.MonoCash.Tier1;
using Scripts.NPC;


namespace Scripts.Conversation
{
    public class ConversationHandler : MonoCashListener
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


        private List<ConversationElement> _addedConversationElementList;
        private List<ConversationOption> _addedConversationOptionList;



        public override void OnInitialization()
        {
            _addedConversationElementList = new List<ConversationElement>();
            _addedConversationOptionList = new List<ConversationOption>();
        }


        //Начало диалога (проверка необходимых условий перед его началом)
        public void StartConversation()
        {
            
        }


        //Попытка поймать ближайшую цель для диалога (в разумно заданных пределах)        
        private NpcHandler GetNearestConversationTarget()
        {
            return null;
        }


        private void SetupLeftImage(Sprite imageSprite) => _screenElementsStruct.leftImage.sprite = imageSprite;

        private void SetupRightImage(Sprite imageSprite) => _screenElementsStruct.rightImage.sprite = imageSprite;


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


#region ADDING_ELEMENTS_REGION

        //Добавить ремарку (после нажатия на кнопку)
        private void AddRemark(string remarkText)
        {
            var remarkPrefab = _conversationPrefabsStruct.conversationRemark;
            var contentContainer = _screenElementsStruct.contentContainer;

            var addedRemark = Instantiate(remarkPrefab, contentContainer);
            addedRemark.OnShow(remarkText);
        }


        //Добавить имя говорящего
        private void HeaderName(string headerText)
        {
            var headerPrefab = _conversationPrefabsStruct.conversationHeader;
            var contentContainer = _screenElementsStruct.contentContainer;

            var addedHeader = Instantiate(headerPrefab, contentContainer);
            addedHeader.OnShow(headerText);
        }


        //Добавить кнопку (опцию для продолжения диалога)
        private void AddOption(string optionText)
        {
            var optionPrefab = _conversationPrefabsStruct.conversationOption;
            var contentContainer = _screenElementsStruct.contentContainer;

            var addedButton = Instantiate(optionPrefab, contentContainer);
            addedButton.OnShow(optionText);

            _addedConversationOptionList.Add(addedButton);
        }


        //Добавить реплику
        private void AddNode(string nodeText)
        {
            var nodePrefab = _conversationPrefabsStruct.conversationNode;
            var contentContainer = _screenElementsStruct.contentContainer;

            var addedNode = Instantiate(nodePrefab, contentContainer);
            addedNode.OnShow(nodeText);
        }

#endregion



#region CLEARING_ELEMENTS_REGION


        //Очистить контейнер с контентом
        private void ClearContentContainer()
        {
            foreach (var element in _addedConversationElementList)
            {
                
            }
        }


        //Очистить контейнер от кнопок с опциями (после прожатия опции)
        private void ClearAddedButtonsList()
        {
            foreach (var element in _addedConversationOptionList)
            {
                
            }
        }

#endregion



#region EVENTS_REGION

        

#endregion

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
        public ConversationScreen conversationScreen;
        public Image leftImage;
        public Image rightImage;
        public RectTransform contentContainer;
    }


    [System.Serializable]
    public struct ConversationPrefabsStruct
    {
        public ConversationNode conversationNode;
        public ConversationOption conversationOption;
        public ConversationHeader conversationHeader;
        public ConversationRemark conversationRemark;
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