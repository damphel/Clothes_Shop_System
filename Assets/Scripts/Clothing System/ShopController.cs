using Denis.Shop.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Denis.Shop
{
    public class ShopController : MonoBehaviour
    {
        [Header("Shop Setup")]
        [SerializeField] List<Item> itemOptions = new List<Item>();
        [SerializeField] GameObject shopItemPrefab;
        [SerializeField] RectTransform shopContent;

        public void OpenShop()
        { 
            if (shopContent.childCount <= 0 || shopContent.childCount < itemOptions.Count)
            {
                foreach (Item _item in itemOptions)
                {
                    ShopItemElement element = Instantiate(shopItemPrefab, Vector3.zero, Quaternion.identity, shopContent).GetComponent<ShopItemElement>();

                    element.SetUpItemData(_item);
                }
            }
        }
    }
}
