using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    // Variables
    public float runSpeed;                  // Speed in meter per second that the sheep will run
    public float gotHayDestroyDelay;        // Selay in seconds before the sheep gets destroyed after it got hit by hay
    private bool hitByHay;                  // Boolean that gets set to true once the sheep was hit by hay

    public float dropDestroyDelay;          // Time in seconds before the sheep gets destroyed when it's over the edge and starts dropping
    private Collider myCollider;            // Reference to the sheep's Collider component
    private Rigidbody myRigidbody;          // Reference to the sheep's Rigidbody

    private SheepSpawner sheepSpawner;      // Reference to the sheep spawner

    public float heartOffset;               // Offset in the Y axis where the heart will spawn
    public GameObject heartPrefab;          // Holds a reference to the Heart prefab just made


    // Start is called before the first frame update
    void Start()
    {
        // Assign the needed references
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);   // Makes the sheep run towards its forward vector (the local Z axis) at the speed set in the runSpeed variable
    }

    // HitByHay
    private void HitByHay()
    {
        //GameStateManager.Instance.SavedSheep();     // Tells the manager that a sheep was saved

        sheepSpawner.RemoveSheepFromList(gameObject);

        hitByHay = true;                            // Check if the method was already called
        runSpeed = 0;                               // Stop the sheep

        Destroy(gameObject, gotHayDestroyDelay);    // Destroy the sheep, also accepts the delay in seconds before the GameObject gets destroyed

        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);     // Create a new heart and position it above the sheep, with heartOffset added to the Y position

        // Animate the sheep
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();      // Add a TweenScale component to the GameObject this script is attached to and put a reference to it in a tweenScale variable
        tweenScale.targetScale = 0;                                         // Set the target scale of TweenScale to 0 so the sheep shrinks down all the way
        tweenScale.timeToReachTarget = gotHayDestroyDelay;                  // Set the time that TweenScale will take to the same time it takes to destroy the sheep

        SoundManager.Instance.PlaySheepHitClip();   // Play sound

        //
        GameStateManager.Instance.SavedSheep();     // Tells the manager that a sheep was saved
    }

    // OnTriggerEnter
    private void OnTriggerEnter(Collider other)     // This method gets called when a trigger enters this GameObject (or vice versa)
    {
        if (other.CompareTag("Hay") && !hitByHay)   // If the GameObject that hit this one has the Hay tag assigned and the sheep wasn't hit by hay already
        {
            Destroy(other.gameObject);              // Destroy the other GameObject (the hay bale)
            HitByHay();
        }
        else if (other.CompareTag("DropSheep"))     // If the sheep was hit by something other than a hay bale, it checks if the collider it hit has the DropSheep tag assigned
        {
            Drop();
        }

    }

    // Drop
    private void Drop()
    {
        GameStateManager.Instance.DroppedSheep();       // The manager gets notified that a sheep was dropped

        sheepSpawner.RemoveSheepFromList(gameObject);

        myRigidbody.isKinematic = false;                // Make the sheep's rigidbody non-kinematic so it gets affected by gravity
        myCollider.isTrigger = false;                   // Disable the trigger so the sheep becomes a solid object
        Destroy(gameObject, dropDestroyDelay);          // Destroy the sheep after the delay specified in dropDestroyDelay

        SoundManager.Instance.PlaySheepDroppedClip();   // Play sound
    }

    // SetSpawner
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

}
