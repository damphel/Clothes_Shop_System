using Denis.Shop.Items;
using UnityEngine;

namespace Denis.Player
{
    public class PlayerModel : MonoBehaviour
    {
        public Item HeadClothes { get; set; }
        public Item OutfitClothes { get; set;}


        public void SetPlayerClothesByItem(Item item)
        {
            switch (item.type)
            {
                case ItemType.head:
                    HeadClothes = item;
                    break;
                case ItemType.outfit:
                    // Here we can make more complex thing like replacing the sprite sheet for animation purporses
                    OutfitClothes = item;
                    break;
            }
        }

        public void RemovePlayerClothesByItem(Item item)
        {
            switch (item.type)
            {
                case ItemType.head:
                    HeadClothes = null;
                    break;
                case ItemType.outfit:
                    OutfitClothes = null;
                    break;
            }
        }
    }
}