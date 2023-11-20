using Denis.Player;
using Denis.Shop.Items;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Denis.Customization
{
    public class CustomizationController : MonoBehaviour
    {
        [Header("Dummy")]
        [SerializeField] Image bodyImage;
        [SerializeField] Image outfitImage;
        [SerializeField] Image headImage;

        [Header("Customization")]
        [SerializeField] CustomizationElement headCloth;
        [SerializeField] CustomizationElement outfitCloth;

        public Item HeadItem { get; set; }
        public Item OutfitItem { get; set; }

        public void SetCustomizationElement(Item item)
        {
            switch (item.type)
            {
                case ItemType.head:
                    HeadItem = item;

                    headImage.enabled = true;
                    headImage.sprite = item.itemIcon;

                    headCloth.SetElementByItem(item);

                    PlayerController.instance.SetPlayerCustomClothes(item);
                    break;
                case ItemType.outfit:
                    OutfitItem = item;

                    outfitImage.enabled = true;
                    outfitImage.sprite = item.itemIcon;

                    outfitCloth.SetElementByItem(item);

                    PlayerController.instance.SetPlayerCustomClothes(item);
                    break;
            }
        }

        public void RemoveCustomizationElement(Item item)
        {
            switch (item.type)
            {
                case ItemType.head:
                    HeadItem = null;
                    headImage.enabled = false;

                    PlayerController.instance.RemovePlayerCustomClother(item);
                    break;
                case ItemType.outfit:
                    OutfitItem = null;
                    outfitImage.enabled = false;

                    PlayerController.instance.RemovePlayerCustomClother(item);
                    break;
            }
        }
    }
}
