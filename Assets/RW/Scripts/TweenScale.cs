using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    // Variable Declarations
    public float targetScale;           // Final scale applied on all axes
    public float timeToReachTarget;     // Time in seconds it will take to reach the target scale
    private float startScale;           // Scale of the GameObject at the moment this script is activated
    private float percentScaled;        // Percent between 0.0 and 1.0 that will be incremented and used in calculations to change the scale from the starting value to the target value


    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f)
        {
            percentScaled += Time.deltaTime / timeToReachTarget;                // Add the time between this frame and the previous one, divided by the amount of seconds needed to reach the final value
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled);   // Store the lerped value of the scale
            transform.localScale = new Vector3(scale, scale, scale);            // Get the scale value from the lerp and apply it to the transform on all axes
        }

    }
}
