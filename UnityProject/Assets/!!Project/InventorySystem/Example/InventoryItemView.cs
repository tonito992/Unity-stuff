using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace itonigames.unitystuff.InventorySystem.Example
{
    public class InventoryItemView : MonoBehaviour
    {
        public static event Action<InventoryItemView> Drop;

        [SerializeField] private TMP_Text textName;
        [SerializeField] private TMP_Text textAmount;

        private InventoryItem inventoryItem;
        private Button dropButton;

        public InventoryItem Item => this.inventoryItem;

        public void Setup(InventoryItem item)
        {
            this.inventoryItem = item;
            this.textName.SetText(item.Name);
            this.textAmount.text = item.Stackable ? item.Amount.ToString() : "";
        }

        private void OnDrop()
        {
            Drop?.Invoke(this);
        }

        private void Awake()
        {
            this.dropButton = this.GetComponent<Button>();
            this.dropButton.onClick.AddListener(this.OnDrop);
        }
    }
}