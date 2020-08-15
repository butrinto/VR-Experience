// This code was adapted from the following source by Jayanam; https://www.youtube.com/watch?time_continue=91&v=LziIlLB2Kt4&feature=emb_title
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    // Initialises the GameObject, to assign a Panel in Unity's inspector
    public GameObject Panel;

    public void OpenPanel()
    {
        // Check if Panel is assigned, null
        if (Panel != null)
        {
            // Toggles the active state
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!true);
        }
    }
}
