using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Variable Declarations
    public float timeToDestroy;     // Time in seconds before the GameObject this script is attached to is destroyed

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);     // Destroys the GameObject after the delay set in timeToDestroy
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
