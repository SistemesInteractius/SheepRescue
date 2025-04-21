using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    // Variables

    // Hay Machine
    public float movementSpeed;                 // This variable will allow you to specify the speed at which the machine can move
    public float horizontalBoundary = 22;       // This variable will be used to limit the movement on the X-axis

    // Hay Bale
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;

    // Color
    public Transform modelParent;

    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;


    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }

    // LoadModel replaces the default model with a new one depending on the machine color saved in the game settings
    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); // 1

        switch (GameSettings.hayMachineColor) // 2
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    // UpdateMovement moves the hay machine around using the player's horizontal input
    private void UpdateMovement()
    {
        // Get the raw input of the Horizontal axis using the Input class
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // If horizontalInput < 0 -> translate the machine to the left at a rate of its movementSpeed per second
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }

        // If horizontalInput > 0 -> move the machine to the right
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }

    // UpdateShooting
    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;                           // 1. Subtract the time between the previous frame and the current one from shootTimer (-1 every second)

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))     // 2. If the value of shootTimer is equal to or less than 0 and the space bar is pressed in
        {
            shootTimer = shootInterval;                         // 3. Reset the shoot timer
            ShootHay();                                         // 4. Shoot a bale of hay
        }
    }

    // ShootHay makes the hay machine shoot out the bales
    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);    // Instantiate method creates an instance of a given prefab or GameObject and places it in the scene

        SoundManager.Instance.PlayShootClip();                                      // Play sound
    }

}
