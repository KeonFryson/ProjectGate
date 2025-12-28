using UnityEngine;

public class ItemPickup : MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Item item;
    private Inventroy Inventroy;

    private void Awake()
    {
        Inventroy = FindFirstObjectByType<Inventroy>();
    }

    private void OnTriggerEnter(Collider other)
    {


        
        Inventroy.Add(item);

        Destroy(gameObject);
        Debug.Log("Picked up: " + item.itemName);
    }
}
