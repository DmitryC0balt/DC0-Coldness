using System;
using UnityEngine;

namespace Scripts.Inventory
{
    public class InventoryMaster
    {
        private int _money;

        public event Action<int> OnMoneyChanged;


        public ItemInventory ItemsInventory { get; private set; }
        public ItemInventory HolsterInventory { get; private set; }
        public RecordInventory RecordsInventory { get; private set; }
        public ArgumentInventory ArgumentsInventory { get; private set; }
        public EvidenceInventory EvidenceInventory { get; private set; }
        public QuestInventory QuestInventory { get; private set; }


        public int money
        {
            get => _money;
            set
            {
                _money = Mathf.Max(0, value);
                OnMoneyChanged?.Invoke(_money);
            }
        }

        public InventoryMaster(int moneyValue)
        {
            _money = moneyValue;
            Initialization();
        }


        private void Initialization()
        {
            ItemsInventory = new ItemInventory(25);
            HolsterInventory = new ItemInventory(1);
            RecordsInventory = new RecordInventory();
            ArgumentsInventory = new ArgumentInventory();
            EvidenceInventory = new EvidenceInventory();
            QuestInventory = new QuestInventory();
        }

    }

}