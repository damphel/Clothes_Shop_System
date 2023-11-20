using Denis.Shop.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Denis.Customization
{
    public class CustomizationElement : MonoBehaviour
    {
        [SerializeField] Image iconImage;
        [SerializeField] Button elementButton;

        public Item customItem { get; set; }

        private void OnEnable()
        {
            elementButton.onClick.AddListener(RemoveCustomElement);
        }

        private void OnDisable()
        {
            elementButton.onClick.RemoveListener(RemoveCustomElement);
        }

        public void RemoveCustomElement()
        {
            if (customItem != null)
            {
                UIManager.instance.CustomizationController.RemoveCustomizationElement(customItem);
                UIManager.instance.InventoryController.RestoreItemToInventory(customItem);

                customItem = null;
                iconImage.enabled = false;
            }
        }

        public void SetElementByItem(Item item)
        {
            customItem = item;
            iconImage.enabled = true;
            iconImage.sprite = item.itemIcon;
        }
    }
}
