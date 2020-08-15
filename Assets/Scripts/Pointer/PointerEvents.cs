// This code was adapted from the following source by VR with Andrew; https://github.com/C-Through/VR-SimplePointer/blob/master/Assets/_SimplePointer/Scripts/PointerEvents.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    // Initialise basic colours for the different modes an object will enter
    // All default to white, however can all be changed in Unity's Inspector mode with the Color. colour wheel
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;
    [SerializeField] private Color downColor = Color.white;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();

    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Changes object colour when pointer hovers over object
        meshRenderer.material.color = enterColor;
        print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Changes object colour when pointer stops hovering over object
        // We will set this to 100% Opacity, as we do not want a colour
        meshRenderer.material.color = normalColor;
        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Colour changes when object is pressed
        meshRenderer.material.color = downColor;
        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Changes object colour when pointer hovers over object after click
        meshRenderer.material.color = enterColor;
        print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Function will allow us to call a method later
        OnClick.Invoke();
        print("Click");
    }
}