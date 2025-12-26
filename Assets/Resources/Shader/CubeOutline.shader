Shader "Custom/CubeOutline"
{Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1,1,1,1)
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth("Outline Width", Range(0, 0.5)) = 0.05
    }
    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque" 
            "Queue" = "Geometry" 
            "RenderPipeline" = "UniversalPipeline" 
        }

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv         : TEXCOORD0;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
                float4 _OutlineColor;
                float _OutlineWidth;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
               
               //get to UV Cord
                float2 uv = input.uv;

                //Calculate distance to the nearest edge 
                float minX = min(uv.x, 1.0 - uv.x);
                float minY = min(uv.y, 1.0 - uv.y);
                
                //Find the closest distance to ANY edge
                float closestEdge = min(minX, minY);

                //If closestEdge is smaller than width, we are in the outline
                float isOutline = step(closestEdge, _OutlineWidth);

                ///else No Outline
                return lerp(_BaseColor, _OutlineColor, isOutline);
            }
            ENDHLSL
        }
    }
}
