using UnityEngine;

namespace itonigames.unitystuff.InventorySystem
{
    public class InventoryWorldItem : MonoBehaviour
    {
        [SerializeField] private InventoryItem inventoryItem;
        public InventoryItem Item => this.inventoryItem;

        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}