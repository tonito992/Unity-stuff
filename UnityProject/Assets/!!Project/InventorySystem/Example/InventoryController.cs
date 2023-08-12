using System.Collections.Generic;
using System.Linq;
using itonigames.unitystuff.Utility;
using UnityEngine;

namespace itonigames.unitystuff.InventorySystem.Example
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private int inventoryCapacity;
        [SerializeField] private List<InventoryWorldItem> itemPrefabs;

        [SerializeField] private InventoryView view;

        private Inventory inventory;
        private InputManager inputManager;

        public void DropItem(InventoryItemView item)
        {
            this.inventory.Take(item.Item, item.Item.Amount);
            this.view.UpdateView(this.inventory.Stacks);
            var worldItem = this.itemPrefabs.FirstOrDefault(x => x.Item.Name == item.Item.Name);
            var newItem = Instantiate(worldItem, Vector3.zero + Vector3.up * 5, Quaternion.identity);
            newItem.gameObject.SetActive(true);
        }

        private void Awake()
        {
            this.inventory = new Inventory(this.inventoryCapacity);
            this.inputManager = new InputManager();
        }

        private void Update()
        {
            this.InputUpdate();
        }

        private void InputUpdate()
        {
            if (!this.inputManager.Mouse.LeftClick.WasPressedThisFrame()) return;

            RaycastUtil.Raycast(out InventoryWorldItem item);
            if (item == null) return;

            if (!this.inventory.TryAdd(item.Item, item.Item.Amount)) return;

            item.Collect();
            this.view.UpdateView(this.inventory.Stacks);
        }

        private void OnEnable()
        {
            this.inputManager.Enable();
            InventoryItemView.Drop += this.DropItem;
        }

        private void OnDisable()
        {
            this.inputManager.Disable();
            InventoryItemView.Drop -= this.DropItem;
        }
    }
}
