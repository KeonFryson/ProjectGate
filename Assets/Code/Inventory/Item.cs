using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item", order = 0)]
public class Item : ScriptableObject
{

    [Tooltip("Name of the item")]
    public string itemName;


    [Tooltip("Unique id")]
    public int itemId;

    [Tooltip("2D icon/sprite for inventory slot.")]
    public Sprite icon;

    [Tooltip("3D model prefab that will be instantiated")]
    public GameObject modelPrefab;

    [Tooltip("Stack size for this item (1 = non-stackable).")]
    public int maxStackSize = 1;


}
