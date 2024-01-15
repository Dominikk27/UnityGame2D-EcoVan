using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] npcPrefabs;
    public Transform spawnPointA;
    public Transform targetPosition;
    public Transform destroyPosition;
    public int MaxSpawnedNPC = 5;
    public bool canSpawn = true;
    public float spawnInterval = 5.0f;

    public List<GameObject> npcList = new List<GameObject>();
    public int currentCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnNPC", 0f, spawnInterval);
    }

    public void enableSpawn(bool setState)
    {
        //Debug.Log("SetValue to Spawn is:" + setState);
        canSpawn = setState;
    }

    void SpawnNPC()
    {  
        if (canSpawn == true && currentCount < MaxSpawnedNPC){
            GameObject newNPC;
            int randomIndex = Random.Range(0, npcPrefabs.Length);
            newNPC = Instantiate(npcPrefabs[randomIndex], spawnPointA.position, Quaternion.identity);

            NPC_Controller npcController = newNPC.GetComponent<NPC_Controller>();
            npcController.setTarget(targetPosition.position.x, destroyPosition.position.x);
            if (npcController == null)
            {
                npcController = newNPC.GetComponent<NPC_Controller>();
                npcController.setTarget(targetPosition.position.x, destroyPosition.position.x);
            }
            currentCount = currentCount + 1;
        }
        else{
            //Debug.Log("There is MAX NPC COUNT!");
            canSpawn = false;
        }
    }
}



/*
if (currentNPCcount <= MaxSpawnedNPC && canSpawn){
            GameObject newNPC;
            int randomIndex = Random.Range(0, npcPrefabs.Length);
            newNPC = Instantiate(npcPrefabs[randomIndex], spawnPointA.position, Quaternion.identity);

            NPC_Controller npcController = newNPC.GetComponent<NPC_Controller>();
            if (npcController == null)
            {
                npcController = newNPC.GetComponent<NPC_Controller>();
            }
            currentNPCcount += 1;
        }
        else{
            Debug.Log("Spawn System is Currently Disabled");
        }
*/