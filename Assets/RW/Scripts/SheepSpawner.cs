using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    // Variables
    public bool canSpawn = true;                                            // As long as this stays true, the script will keep spawning sheep

    public GameObject sheepPrefab;                                          // Reference to a the Sheep prefab
    public List<Transform> sheepSpawnPositions = new List<Transform>();     // Positions from where the sheep will be spawned
    public float timeBetweenSpawns;                                         // Time in seconds between the spawning of sheep

    private List<GameObject> sheepList = new List<GameObject>();            // List of all the sheep alive in the scene

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // SpawnSheep
    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;  // Get the position of one of the spawn point transforms randomly
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);        // Create a new sheep and add it to the scene at the random position chosen in the previous line and save it in a temporary sheep variable
        sheepList.Add(sheep);                                                                               // Add a reference to the sheep that was just created to the list of sheep
        sheep.GetComponent<Sheep>().SetSpawner(this);
    }

    // SpawnRoutine
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnSheep();                                           // Spawn a new sheep
            yield return new WaitForSeconds(timeBetweenSpawns);     // Pause the execution of this coroutine for the amount of seconds specified in timeBetweenSpawns (WaitUntilSeconds) using a yield instruction
        }
    }

    // RemoveSheepFromList
    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    // DestroyAllSheep
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }

        sheepList.Clear();
    }

}
