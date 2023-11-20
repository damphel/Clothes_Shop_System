using Denis.Shop.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Denis.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] List<InventoryElement> inventoryElements = new List<InventoryElement>();


        public void BuyItemToInventory(Item item)
        {
            RestoreItemToInventory(item);
        }

        public void SellItemToInventory(Item item)
        {
            RemoveItemToInventory(item);
        }

        public void RemoveItemToInventory(Item item)
        {
            foreach (InventoryElement element in inventoryElements)
            {
                if (element.inventoryItem != null && element.inventoryItem.itemId == item.itemId)
                {
                    if (element.itemCount > 1)
                    {
                        element.itemCount--;
                        element.UpdateElementUI();

                        return;
                    }
                    else
                    {
                        element.itemCount = 0;
                        element.inventoryItem = null;
                        element.UpdateElementUI();
                    }
                }
            }
        }

        public void RestoreItemToInventory(Item item)
        {
            foreach (InventoryElement element in inventoryElements)
            {
                if (element.inventoryItem != null)
                {
                    if (element.inventoryItem.itemId == item.itemId)
                    {
                        element.itemCount++;
                        element.UpdateElementUI();

                        return;
                    }
                }
                else
                {
                    element.inventoryItem = item;
                    element.itemCount++;
                    element.UpdateElementUI();

                    return;
                }

            }
        }
    }
}
