// This code was adapted from the following sources: https://github.com/Unity-Technologies/PostProcessing/wiki/Writing-Custom-Effects & https://www.youtube.com/watch?v=AcCDqH8LA9M&t=

Shader "Custom/Drunk_PPP"
{
    HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
    float _Amplitude;
    float _Frequency;

    // Float2 stores the x and y of each pixel
    float2 distortion;

    float4 _Speed;
    float4 _Size;

    // Fragment shader loops over every picture, using x, y, z and w
    float4 Frag(VaryingsDefault i) : SV_Target
    {
        // Float2 stores the x and y of each pixel
        float2 uv = i.texcoord;
        
        // Different graphs types used to create a more unique pixel movement
        distortion.x = (sin((_Speed.x * _Time.y) + (uv.x * _Size.x) * _Frequency)) * _Amplitude;
        distortion.y = (cos((_Speed.y * _Time.y) + (uv.y * _Size.y) * _Frequency)) * _Amplitude;
        
        float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + distortion);

        //float luminance = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));
        //color.rgb = lerp(color.rgb, luminance.xxx, _Blend.xxx);
        return color;
    }

        ENDHLSL

        SubShader
    {
        Cull Off ZWrite Off ZTest Always

            Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}