// This code was adapted from the following source on stackoverflow; https://stackoverflow.com/questions/53566557/unity-3d-vr-hide-and-show-model-on-controller-button-click

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will allow us to hide the pointer when they are not in use
public class Active : MonoBehaviour
{
    // Initialise the hide/show with a button press
    public OVRInput.Button menu = OVRInput.Button.PrimaryHandTrigger;
    private bool activity;

    // Set the two pointer we want to disable/enable, these can be changed in Unity's inspector
    public GameObject ObjectToHide; 
    public GameObject ObjectToHide2;

    void Start()
    {
        activity = false;
    }

    void Update()
    {
        ObjectToHide.SetActive(activity);   

        // Here disables the first object
        
        if (OVRInput.Get(menu))
            // If button is pressed, activate the pointer
        {
            activity = true;
        }
        else
        {
            // Else, deactivate it

            activity = false;
        }

        ObjectToHide2.SetActive(activity);   
        
        //Here disables the second object in a similar fashion

        if (OVRInput.Get(menu))
            // If button is pressed, activate the pointer
        {
            activity = true;
        }
        else
        {
            // Else, deactivate it

            activity = false;
        }
    }
}
