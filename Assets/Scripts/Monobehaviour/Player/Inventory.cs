using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public const int numItemSlots = 6;
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    public void AddItem(Item itemToAdd)
    {
        for (var i = 0; i < numItemSlots; i++)
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
    }

    public void RemoveItem(Item itemToRemove)
    {
        for (var i = 0; i < numItemSlots; i++)
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
    }

    public void RemoveLast()
    {
        for (var i = numItemSlots - 1; i >= 0; i--)
            if (items[i] != null)
            {
                RemoveItem(items[i]);
                return;
            }
    }

    public bool ContainsItems()
    {
        return items.Any(x => x != null);
    }
}