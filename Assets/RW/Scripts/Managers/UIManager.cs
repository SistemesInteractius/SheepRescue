using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Variable Declarations
    public static UIManager Instance;   // Reference to this UI Manager

    public Text sheepSavedText;         // Cached reference to the Text component of DroppedSheepText
    public Text sheepDroppedText;       // Reference to the Text component of SavedSheepText
    public GameObject gameOverWindow;   // Reference to the Game Over Window


    // Awake
    void Awake()
    {
        Instance = this;    // Stores this script inside the Instance variable to allow easy access to other scripts
    }

    // UpdateSheepSaved
    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    // UpdateSheepDropped
    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    // ShowGameOverWindow
    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }


}
