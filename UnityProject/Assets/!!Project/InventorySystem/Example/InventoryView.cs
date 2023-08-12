using System.Collections.Generic;
using UnityEngine;

namespace itonigames.unitystuff.InventorySystem.Example
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private InventoryItemView itemViewPrefab;

        private List<InventoryItemView> items = new();

        public void UpdateView(List<InventoryItem> inventoryItems)
        {
            foreach (var item in this.items)
            {
                Destroy(item.gameObject);
            }

            this.items.Clear();

            foreach (var item in inventoryItems)
            {
                var newItem = Instantiate(this.itemViewPrefab, this.container);
                newItem.gameObject.SetActive(true);
                newItem.Setup(item);
                this.items.Add(newItem);
            }
        }
    }
}