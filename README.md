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
  <img width="460" height="300" src="image.png">
</p>


