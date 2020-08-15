// This code was adapted from the following source by VR with Andrew; https://www.youtube.com/watch?v=i0QIqHHpvKw&t=263s

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasPointer : MonoBehaviour
{
    // Default length, set as 3.0f as it was a length that wasn't too long
    public float defaultLength = 3.0f;

    // Assigns functionality to specific, overrideable components in the Unity Event
    public EventSystem eventSystem = null;
    // Module to assist with generic controller functions; dragging, pressing etc
    public StandaloneInputModule InputModule = null;

    // Takes two points in 3D space, and draws a line between the two
    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Uses the UpdateLength function to ensure the lineRenderer changes every frame
    private void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        // Two positional vectors for the lineRenderer to work
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, GetEnd());
    }

    private Vector3 GetEnd()
    {
        // This float checks for the Canvas' distance away from the pointer
        float distance = GetCanvasDistance();

        Vector3 endPosition = CalculateEnd(defaultLength);

        // if statement; if there is no object to hit, the distance will be 0
        if (distance != 0.0f)
        {
            endPosition = CalculateEnd(distance);
        }

        return endPosition;
    }

    private float GetCanvasDistance()
    {
        // Get data
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = InputModule.inputOverride.mousePosition;

        // Raycast using data
        List<RaycastResult> results = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);

        // Get closest
        RaycastResult closestResult = FindFirstRaycast(results);
        float distance = closestResult.distance;

        // Clamps the value; returns the given value if it is between the minimum and maximum range
        distance = Mathf.Clamp(distance, 0.0f, defaultLength);
        return distance;
    }

    // EventSystem.cs, a source code from Unity themselves
    // BaseInputModule.cs, a source code from Unity themselves
    private RaycastResult FindFirstRaycast(List<RaycastResult> results)
    {
        foreach (RaycastResult result in results)
        {
            // Go through each gameObject to detect if an object is being hit or not for every frame update
            if (!result.gameObject)
                continue;

            return result;
        }

        return new RaycastResult();
    }

    private Vector3 CalculateEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }

}
