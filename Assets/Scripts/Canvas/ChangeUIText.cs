using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIText : MonoBehaviour
{
    public Text uiText;
    public string setText;

    void Start()
    {
        uiText.text = "";
    }

    void Update()
    {
        uiText.text = setText;
    }

}
