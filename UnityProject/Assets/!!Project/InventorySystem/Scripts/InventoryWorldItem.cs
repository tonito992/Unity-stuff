using UnityEngine;

namespace itonigames.unitystuff.InventorySystem
{
    public class InventoryWorldItem : MonoBehaviour
    {
        [SerializeField] private InventoryItem inventoryItem;
        public InventoryItem Item => this.inventoryItem;

        public void Setup(InventoryItem item)
        {
            this.inventoryItem = item;
        }

        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}