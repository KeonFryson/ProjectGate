using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventroy : MonoBehaviour
{

    public List<InventroyItem> inventory;
    private Dictionary<int, List<InventroyItem>> itemDictionary;


    private void Awake()
    {
        inventory = new List<InventroyItem>();
        itemDictionary = new Dictionary<int, List<InventroyItem>>();
    }


    public void Add(Item item)
    {
        if (itemDictionary.TryGetValue(item.itemId, out List<InventroyItem> itemStacks))
        {
            // Try to add to an existing stack that isn't full
            InventroyItem stackWithSpace = itemStacks.FirstOrDefault(stack =>
                item.maxStackSize > 1 && stack.stackSize < item.maxStackSize);

            if (stackWithSpace != null)
            {
                stackWithSpace.AddToStack();
                Debug.Log("Added to existing stack: " + item.itemName + " New stack size: " + stackWithSpace.stackSize);
            }
            else
            {
                // Create new stack/entry
                InventroyItem newInventroyItem = new InventroyItem(item);
                inventory.Add(newInventroyItem);
                itemStacks.Add(newInventroyItem);
                Debug.Log("Created new stack for: " + item.itemName);
            }
        }
        else
        {
            // First instance of this item type
            InventroyItem newInventroyItem = new InventroyItem(item);
            inventory.Add(newInventroyItem);
            itemDictionary.Add(item.itemId, new List<InventroyItem> { newInventroyItem });
            Debug.Log("Added new item to inventory: " + item.itemName);
        }
    }

    public void Remove(Item item)
    {
        if (itemDictionary.TryGetValue(item.itemId, out List<InventroyItem> itemStacks) && itemStacks.Count > 0)
        {
            // Remove from the first available stack
            InventroyItem inventroyItem = itemStacks[0];
            inventroyItem.RemoveFromStack();

            if (inventroyItem.stackSize <= 0)
            {
                inventory.Remove(inventroyItem);
                itemStacks.Remove(inventroyItem);

                // Clean up dictionary entry if no stacks remain
                if (itemStacks.Count == 0)
                {
                    itemDictionary.Remove(item.itemId);
                }
            }
            Debug.Log("Removed item from inventory: " + item.itemName + " New stack size: " + inventroyItem.stackSize);
        }
    }
}
