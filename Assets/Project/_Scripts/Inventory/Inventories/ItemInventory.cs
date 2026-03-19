using System;
using System.Collections.Generic;
using Scripts.ScriptableObjects;


namespace Scripts.Inventory
{
    public class ItemInventory
    {   
        private List<InventoryItem> _inventoryItemList;
        public IReadOnlyList<InventoryItem> inventoryItemList => _inventoryItemList;


        public event Action<InventoryItem, int> OnItemAdded;
        public event Action<InventoryItem> OnItemUsed;
        public event Action<int> OnItemRemoved;


        public ItemInventory(int capacity) => _inventoryItemList = new List<InventoryItem>(capacity);

        public bool TryAddItem(InventoryItem item)
        {
            if (_inventoryItemList.Count < _inventoryItemList.Capacity)
            {
                _inventoryItemList.Add(item);
                return true;
            }
            return false;
        }


        public void RemoveItem(int index)
        {
            _inventoryItemList[index] = null;
            OnItemRemoved?.Invoke(index);
        }

    }
}