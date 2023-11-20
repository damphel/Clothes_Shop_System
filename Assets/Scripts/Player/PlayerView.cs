using Denis.Shop.Items;
using UnityEngine;

namespace Denis.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] SpriteRenderer bodyRenderer;
        [SerializeField] SpriteRenderer outfitRenderer;
        [SerializeField] SpriteRenderer headRenderer;

        public void SetPlayerSpritesByItem(Item item)
        {
            switch (item.type)
            {
                case ItemType.head:
                    // Here we can make more complex thing like replacing the sprite sheet for animation purporses
                    headRenderer.sprite = item.itemIcon;
                    break;
                case ItemType.outfit:
                    // Here we can make more complex thing like replacing the sprite sheet for animation purporses
                    outfitRenderer.sprite = item.itemIcon;
                    break;
            }
        }

        public void RemovePlayerSpritesByItem(Item item)
        {
            switch (item.type)
            {
                case ItemType.head:
                    headRenderer.sprite = null;
                    break;
                case ItemType.outfit:
                    outfitRenderer.sprite = null;
                    break;
            }
        }
    }
}
