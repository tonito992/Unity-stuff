using UnityEngine;

namespace itonigames.unitystuff.InventorySystem
{
    [System.Serializable]
    public class InventoryItem
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int amount;
        [SerializeField]
        private bool stackable;

        public string Name => this.name;
        public int Amount => this.amount;
        public bool Stackable => this.stackable;

        public InventoryItem(string name, int amount, bool stackable)
        {
            this.name = name;
            this.amount = amount;
            this.stackable = stackable;
        }

        public void Add(int value)
        {
            this.amount += value;
        }

        public void Take(int value)
        {
            this.amount -= value;
        }
    }
}