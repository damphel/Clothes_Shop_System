using Denis.Player;
using Denis.Shop.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Denis.Inventory
{
    public class InventoryElement : MonoBehaviour
    {
        [SerializeField] Image elementIcon;
        [SerializeField] TMP_Text elementCount;
        [SerializeField] Color noItemIconColor;
        [SerializeField] Button elementButton;

        public Item inventoryItem { get; set; }
        public int itemCount { get; set; }

        private void OnEnable()
        {
            elementButton.onClick.AddListener( delegate { DoOnSetCustom(); });
        }

        private void OnDisable()
        {
            elementButton.onClick.RemoveListener(delegate { DoOnSetCustom(); });
        }

        private void Awake()
        {
            if (elementButton == null) elementButton = GetComponent<Button>();
        }

        public void DoOnSetCustom()
        {
            if (inventoryItem != null)
            {
                if (PlayerController.instance._PlayerModel.HeadClothes != null && inventoryItem.type == ItemType.head)
                {
                    UIManager.instance.InventoryController.RestoreItemToInventory(PlayerController.instance._PlayerModel.HeadClothes);
                    UIManager.instance.CustomizationController.RemoveCustomizationElement(PlayerController.instance._PlayerModel.HeadClothes);

                }
                else if (PlayerController.instance._PlayerModel.OutfitClothes != null && inventoryItem.type == ItemType.outfit)
                {
                    UIManager.instance.InventoryController.RestoreItemToInventory(PlayerController.instance._PlayerModel.OutfitClothes);
                    UIManager.instance.CustomizationController.RemoveCustomizationElement(PlayerController.instance._PlayerModel.OutfitClothes);
                }

                UIManager.instance.CustomizationController.SetCustomizationElement(inventoryItem);
                UIManager.instance.InventoryController.RemoveItemToInventory(inventoryItem);
            }
        }

        public void UpdateElementUI()
        { 
            if (itemCount <= 0 )
            {
                elementIcon.color = noItemIconColor; 
                elementCount.text = string.Empty;
            }
            else
            {
                elementIcon.color = Color.white;
                elementIcon.sprite = inventoryItem.itemIcon;
                elementCount.text = itemCount.ToString();
            }
        }
    }
}
