// This code was adapted from the following source by BeepBoopIndie; https://www.youtube.com/watch?v=OMPV-duv25Q

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Distance : MonoBehaviour
{
    // Use GameObject so we can alter which objects to use within Unity
    public GameObject Object1;
    public GameObject Object2;
    public float distance_;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Tracks the distance between object 1 and object 2
        distance_ = Vector3.Distance(Object1.transform.position, Object2.transform.position);

        // if statement which tells us if the object is less than the given length, activate the postprocessing. Distance is altered to mimic putting drug to mouth
        if (distance_ < 0.25)
        {
            // Log update to verify if statement works
            Debug.Log("Drug has been taken");

            // Enable postprocessing effect
            GameObject.Find("CenterEyeAnchor").GetComponent<PostProcessLayer>().enabled = true;
        }
    }
}