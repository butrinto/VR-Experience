// This code was adapted from the following sources: https://github.com/Unity-Technologies/PostProcessing/wiki/Writing-Custom-Effects & https://www.youtube.com/watch?v=AcCDqH8LA9M&t=

using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(Drunk_PPPRenderer), PostProcessEvent.AfterStack, "Custom/Drunk_PPP")]
public sealed class Drunk_PPP : PostProcessEffectSettings
{
    // Create two new floats to change the screens distortion
    [Range(0f, 1f), Tooltip("Drunk Distortion effect intensity")]
    public FloatParameter amplitude = new FloatParameter { value = 0.5f };

    [Range(0f, 100f), Tooltip("Drunk Distortion effect frequency")]
    public FloatParameter frequency = new FloatParameter { value = 0.5f };

    // Create two new vectors to control the speed and size of the distortion
    [Tooltip("Speed of the Distortion only x and y used")]
    public Vector4Parameter speed = new Vector4Parameter { value = new Vector4(1, 1, 0, 0)};

    [Tooltip("Size of the Distortion only x and y used")]
    public Vector4Parameter size = new Vector4Parameter { value = new Vector4(1, 1, 0, 0) };
}

public sealed class Drunk_PPPRenderer : PostProcessEffectRenderer<Drunk_PPP>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/Drunk_PPP"));
        // Set float parameters
        sheet.properties.SetFloat("_Amplitude", settings.amplitude);
        sheet.properties.SetFloat("_Frequency", settings.frequency);

        // Set vector parameters
        sheet.properties.SetVector("_Speed", settings.speed);
        sheet.properties.SetVector("_Size", settings.size);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
