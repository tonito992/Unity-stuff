using itonigames.unitystuff.Utility;
using UnityEngine;

namespace itonigames.unitystuff.InventorySystem.Example
{
    public class InventoryDemo : MonoBehaviour
    {
        [SerializeField] private int inventoryCapacity;

        private Inventory inventory;
        private InputManager inputManager;

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
        }

        private void OnEnable()
        {
            this.inputManager.Enable();
        }

        private void OnDisable()
        {
            this.inputManager.Disable();
        }
    }
}
