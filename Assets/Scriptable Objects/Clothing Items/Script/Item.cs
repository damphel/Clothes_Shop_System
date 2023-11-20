using UnityEngine;

namespace Denis.Shop.Items
{
    public enum ItemType { head, outfit }

    // This class can be used as a parent and be used for inheritance for future specific
    // types of items' scriptable objects

    [CreateAssetMenu(fileName = "New Item", menuName = "Clothing System/Shop/Item")]
    public class Item : ScriptableObject
    {
        public int itemId;
        public ItemType type;
        public string itemName;
        public Sprite itemIcon;
        public float itemPrice;
    }
}
