using System.Collections.Generic;
using Scripts.MonoCash.Tier1;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Inventory
{
    public class InventoryHandler : MonoCashListener
    {
        private GameObject _currentTab;

        [Header("Ссылки на элементы инвентаря")]
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private GameObject _MoneyUI;
        [SerializeField] private GameObject BillPrefab;
        [SerializeField] private Transform _itemsGrid;
        [SerializeField] private GameObject _itemsSection;
        [SerializeField] private ItemSlot _itemSlotPrefab;
        [SerializeField] private GameObject _GunSlot;
        


        [Header("Ссылки на прочие элементы интерфейса")]
        [SerializeField] private Button _itemsButton;
        [SerializeField] private Button _recordsButton;
        [SerializeField] private SlotPopup _tooltip;
        [SerializeField] private SlotPopup _slotPopup;


        private Coroutine _moneyAnimation;

        private List<ItemSlot> _itemSlotList;

        private InventoryMaster _inventoryMaster;

        public override void OnInitialization()
        {
            //Не забыть сюда передать деньгу
            _inventoryMaster = new InventoryMaster(100);
        }


        public override void OnProcess()
        {
            
        }


    }
}