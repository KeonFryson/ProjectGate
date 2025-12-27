using UnityEngine;


[System.Serializable]

public class InventroyItem  
{
    public Item item;
    public int stackSize;

    public InventroyItem(Item item)
    {
        this.item = item;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }


}
