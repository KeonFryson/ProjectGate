using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Transform playerPos;
    public Transform spawnPoint;
    public GameObject playerPrefab;

    void Start()
    {
        spawnPoint = this.transform;
         

        if(GameObject.FindWithTag("Player") != null)
        {
            playerPos = GameObject.FindWithTag("Player").transform;
            playerPos.position = spawnPoint.position;
            playerPos.rotation = spawnPoint.rotation;
        }
        else
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }

    }

    
}
