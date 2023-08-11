using System.Collections.Generic;
using UnityEngine;

namespace itonigames.unitystuff.InventorySystem
{
    public class Inventory
    {
        private Dictionary<string, InventoryItem> stacks;

        public Inventory()
        {
            this.stacks = new Dictionary<string, InventoryItem>();
        }

        public void Add(InventoryItem item, int amount)
        {
            if (this.stacks.ContainsKey(item.Name))
            {
                this.stacks[item.Name].Add(amount);
            }
            else
            {
                this.stacks.Add(item.Name, item);
            }

            Debug.Log($"Add {amount}x{item.Name}");
            Debug.Log($"There are {this.stacks[item.Name].Amount} of {this.stacks[item.Name].Name} in inventory");
        }

        public void Take(InventoryItem item, int amount)
        {
            this.stacks[item.Name].Take(amount);
        }
    }
}