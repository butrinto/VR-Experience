# Virtual Reality Experience

[Installation](#Installation) | [What does it do?](#VR) | [How does it work?](#VR) |

Technologies: C#, Unity

VR-Experience is a C# Project in Unity, which explores the effectiveness of using Virtual Reality (VR) as a tool for education.

## <a name="Installation">Installation — How does it work?</a>

Clone the repository (either through command line or with GitHub Desktop https://desktop.github.com/). Open the project in Unity. Install GitHub for Unity if it is not already installed

_To view all coding/scripts implemented, please refer to the path:_
_VR-Experience > Assets > Scripts_

## <a name="VR">Virtual Reality — What does it do?</a>

The aim is to inform of dangers of drug/substance abuse with the use of an immersive environment which simulates the side effects of narcotics.

The project makes use of Unity and modern VR technology to develop and create avirtual environment and incorporates the use of C# to generate the VR Experience.

## <a name="VR">Virtual Reality — How does it work?</a>

Various objects were initialised to create this project. Listed below are a few snippets of the core design - including the full project breakdown.

### VR Pointer

The project incorporates the use of Unitys VR/AR plugins to create a moveable camera which mimics a 3D Cursor

``` 
using UnityEngine.EventSystems;

  public class VRInput : BaseInput
  {
    // Dummy Camera attached to the controller, to mimic a 3D Cursor
    
    public Camera eventCamera = null;
```

<p align="center">
  <img width="460" height="300" src=./Images/Picture1.png>
</p>

### Information Panel

A visual trigger was created, so the user is aware when an object has been clicked on

```
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
```

<p align="center">
  <img width="460" height="300" src=./Images/Picture3.png>
</p>


Next developed was an information panel. When the pointer intersected an object; an informative panel would be displayed - detailing the narcotic, its side effects and dangers.

```
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
```

### Post-Processing Effects: Side Effects

In this case - imitation alcohol, a distortion post process was created to mimic the feeling of dizziness.

```
public sealed class Drunk_PPP : PostProcessEffectSettings
{
  // Create two new floats to change the screens distortion
  [Range(0f, 1f), Tooltip("Drunk Distortion effect intensity")]
  public FloatParameter amplitude = new FloatParameter { value = 0.5f };

  [Range(0f, 100f), Tooltip("Drunk Distortion effect frequency")]
  public FloatParameter frequency = new FloatParameter { value = 0.5f };
}
```

<p align="center">
  <img width="460" height="300" src=./Images/Picture7.png>
</p>

## Full Project with studies

For the full report and breakdown of this project, please read the below.

[Virtual_Reality___Experience.pdf](https://github.com/butrinto/VR-Experience/files/10546471/Virtual_Reality___Experience.pdf)



