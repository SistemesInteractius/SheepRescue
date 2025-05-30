using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 movementSpeed;           // The speed in meters per second the attached GameObject will move in on the X, Y and Z axes
    public Space space;                     // The space the movement will take place in, either World or Self

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
