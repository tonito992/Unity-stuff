using System;
using itonigames.unitystuff.Utility;
using UnityEngine;

namespace itonigames.unitystuff.InventorySystem.Example
{
    public class InventoryDemo : MonoBehaviour
    {
        private Inventory inventory;
        private InputManager inputManager;

        private void Awake()
        {
            this.inventory = new Inventory();
            this.inputManager = new InputManager();
        }

        private void Update()
        {
            if (this.inputManager.Mouse.LeftClick.WasPressedThisFrame())
            {
                RaycastUtil.Raycast(out InventoryWorldItem item);
                if (item != null)
                {
                    this.inventory.Add(item.Item, item.Item.Amount);
                    item.Collect();
                }
            }
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
