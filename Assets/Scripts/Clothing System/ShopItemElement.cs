using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Denis.Shop.Items
{
    public class ShopItemElement : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] TMP_Text nameTxt;
        [SerializeField] Image itemImage;
        [SerializeField] TMP_Text priceTxt;
        [SerializeField] Button buyBtn;
        [SerializeField] Button sellBtn;

        // Data
        private Item itemOption = null;

        private void OnEnable()
        {
            // Assign the methods of the buttons
            buyBtn.onClick.AddListener(DoBuyItem);
            sellBtn.onClick.AddListener(DoSellItem);
        }

        private void OnDisable()
        {
            // Remove the methods of the buttons
            buyBtn.onClick.RemoveListener(DoBuyItem);
            sellBtn.onClick.RemoveListener(DoSellItem);
        }

        public void SetUpItemData(Item thisItem)
        {
            itemOption = thisItem;

            nameTxt.text = thisItem.itemName;
            itemImage.sprite = thisItem.itemIcon;
            priceTxt.text = thisItem.itemPrice.ToString("N0");
        }

        public void DoBuyItem()
        {
            // Condition all if the player have or not money, this variable can be implemented in the PlayerModel
            Debug.Log("Buy");
            UIManager.instance.InventoryController.BuyItemToInventory(itemOption);
        }

        public void DoSellItem()
        {
            // Condition if the player have the item in the inventory
            Debug.Log("Sell");
            UIManager.instance.InventoryController.SellItemToInventory(itemOption);
        }
    }
}
