// This code was adapted from the following source by VR with Andrew; https://www.youtube.com/watch?v=rgTshoVCZVQ&t=435s

using System;
using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{
    // Default length, set as 3.0f as it was a length that wasn't too long
    public float defaultLength = 3.0f;

    // Takes two points in 3D space, and draws a line between the two
    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Uses the UpdateLength function to ensure the lineRenderer changes every frame
        UpdateLength();
    }

    private void UpdateLength()
    {
        // Two positional vectors for the lineRenderer to work
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    // Vector3 used for direction and magnitude, but no position
    private Vector3 CalculateEnd()
    {
        // Create two separate final points
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLength);

        // If something is hit, the ending hitpoint will be the object which is then stored
        if (hit.collider)
            endPosition = hit.point;

        // Otherwise, use our defaultLength

        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;

        // Create a ray stemming from our controller/hand
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }

    // Default length for if nothing is hit
    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
