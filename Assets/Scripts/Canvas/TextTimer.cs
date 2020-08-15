// This code was adapted from the following source: https://answers.unity.com/questions/970467/how-to-make-disappear-a-gui-text-after-an-amount-o.html
using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class TextTimer : MonoBehaviour
{
    public float time = 20; //Seconds to read the text

    void Start()
    {
        Destroy(gameObject, time);
    }
}