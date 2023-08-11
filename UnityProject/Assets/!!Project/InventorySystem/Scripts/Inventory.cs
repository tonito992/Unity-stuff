using System.Collections.Generic;

namespace itonigames.unitystuff.InventorySystem
{
    public class Inventory
    {
        private int capacity;
        private Dictionary<string, InventoryItem> stacks;

        public Inventory(int capacity)
        {
            this.capacity = capacity;
            this.stacks = new Dictionary<string, InventoryItem>();
        }

        public bool TryAdd(InventoryItem item, int amount)
        {
            if (this.stacks.Count > this.capacity) return false;

            if (!this.stacks.ContainsKey(item.Name) || !item.Stackable)
            {
                this.stacks.Add(item.Name, item);
                return true;
            }

            this.stacks[item.Name].Add(amount);
            return true;
        }

        public void Take(InventoryItem item, int amount)
        {
            this.stacks[item.Name].Take(amount);
        }
    }
}