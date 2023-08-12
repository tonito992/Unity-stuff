using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace itonigames.unitystuff.InventorySystem
{
    public class Inventory
    {
        private int capacity;
        private List<InventoryItem> stacks;

        public List<InventoryItem> Stacks => this.stacks.ToList();

        public Inventory(int capacity)
        {
            this.capacity = capacity;
            this.stacks = new List<InventoryItem>();
        }

        public bool TryAdd(InventoryItem item, int amount)
        {
            if (this.stacks.Count > this.capacity) return false;

            if (this.stacks.All(x => x.Name != item.Name) || !item.Stackable)
            {
                this.stacks.Add(item);
                Debug.Log($"Add {item.Name} {item.Amount}");
                return true;
            }

            this.stacks.FirstOrDefault(x=> x.Name == item.Name)?.Add(amount);
            return true;
        }

        public void Take(InventoryItem item, int amount)
        {
            var stackItem = this.stacks.FirstOrDefault(x => x.Name == item.Name);
            stackItem?.Take(amount);
            if (stackItem.Amount <= 0)
            {
                this.stacks.Remove(stackItem);
            }
        }
    }
}