using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;
    public GameObject Plane;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
    }

    // Follows the target position like with a spring
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }
            
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        if (!float.IsNaN(transform.position.x) && !float.IsNaN(transform.position.y) && !float.IsNaN(transform.position.z))
        {
            if (!float.IsNaN(startMarker.position.x) && !float.IsNaN(startMarker.position.y) && !float.IsNaN(startMarker.position.z))
            {
                if (!float.IsNaN(endMarker.position.x) && !float.IsNaN(endMarker.position.y) && !float.IsNaN(endMarker.position.z))
                {
                    if (fracJourney > 0)
                    {
                        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
                    }
                }
            }
        }
    }
}
