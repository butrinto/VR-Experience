// This code was adapted from the following source by VR with Andrew; https://www.youtube.com/watch?v=rgTshoVCZVQ&t=435s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRInput : BaseInput
{   
    // Dummy Camera attached to the controller, to mimic a 3D Cursor
    public Camera eventCamera = null;
    
    // OVR Inputs for button
    public OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;
    // OVR Input to check which controller to use; set to all to choose in unity
    public OVRInput.Controller controller = OVRInput.Controller.All;
  

    protected override void Awake()
    {
        // Script inherits from BaseInput
        GetComponent<BaseInputModule>().inputOverride = this;
    }

    public override bool GetMouseButton(int button)
    {
        // Gets the value of whatever button you have on your controller
        return OVRInput.Get(clickButton, controller);
    }

    public override bool GetMouseButtonDown(int button)
    {
        // Gets the value of whatever button you have pressed
        return OVRInput.GetDown(clickButton, controller);
    }

    public override bool GetMouseButtonUp(int button)
    {
        // Gets the value of whatever button you have recently lifted
        return OVRInput.GetUp(clickButton, controller);
    }

    // This creates the position of the pointer
    public override Vector2 mousePosition
    {
        get
        {
            // This ensures the cursor comes from the center of the controller, /2 on both axis
            return new Vector2(eventCamera.pixelWidth / 2, eventCamera.pixelHeight / 2);
        }
    }

}
