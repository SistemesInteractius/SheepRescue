using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;    // Saves a reference of the script itself, which can be called from any other script

    [HideInInspector]
    public int sheepSaved;                      // Amount of sheep that were saved by giving them hay

    [HideInInspector]
    public int sheepDropped;                    // Number of sheep that fell down

    public int sheepDroppedBeforeGameOver;      // Amount of sheep that can be dropped before the game is over
    public SheepSpawner sheepSpawner;           // Reference to a Sheep Spawner component


    // Awake
    void Awake()
    {
        Instance = this;    // Caches the current script so it can be accessed from other scripts
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    // SavedSheep increments sheepSaved to keep score every time a sheep gets saved
    public void SavedSheep()
    {
        sheepSaved++;

        UIManager.Instance.UpdateSheepSaved();  // Updates the text that shows the amount of sheep saved
    }

    // GameOver
    private void GameOver()
    {
        sheepSpawner.canSpawn = false;      // Stop the sheep spawner spawning
        sheepSpawner.DestroyAllSheep();     // Destroy all sheep that are still running around

        UIManager.Instance.ShowGameOverWindow();    // The game over window gets shown once the game is over with this method call
    }

    // DroppedSheep
    public void DroppedSheep()
    {
        sheepDropped++;

        UIManager.Instance.UpdateSheepDropped();    // Calls the UI Manager to update the dropped sheep text

        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }

}
