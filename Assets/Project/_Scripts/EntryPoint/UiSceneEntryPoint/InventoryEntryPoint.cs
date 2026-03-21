using Scripts.Inventory;
using UnityEngine;


namespace Scripts.EntryPoint
{
    [RequireComponent(typeof(InventoryHandler))]
    public class InventoryEntryPoint : SceneEntryPoint
    {
        private InventoryHandler _inventoryHandler;

        public override void OnSceneEnter()
        {
            _inventoryHandler ??= GetComponent<InventoryHandler>();
        }

        public override void OnSceneExit()
        {
            
        }
    }
}