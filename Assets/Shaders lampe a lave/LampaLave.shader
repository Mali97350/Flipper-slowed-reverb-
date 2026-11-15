Shader "Custom/LavaLamp"
{
    Properties
    {
        _Threshold ("Threshold", Float) = 1.0
    }
    SubShader
    {
       Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" } 
        Pass
        {
            Cull Off
            ZWrite Off
            ZTest Always

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float _Threshold;
            float4 _Blobs[32];
            float4 _Colors[32];
            float _Count;
            float _Aspect;

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                float field = 0;
                float3 col = 0;

                for (int i = 0; i < 32; i++)
                {
                    if (i >= _Count) break;

                    float2 diff = IN.uv - _Blobs[i].xy;
                    diff.x *= _Aspect;
                    float distSq = dot(diff, diff);

                    float f = (_Blobs[i].z * _Blobs[i].z) / (distSq + 0.0001);
                    field += f;
                    col += _Colors[i].rgb * f;
                }

                float3 color = col / max(field, 0.0001);
                float liquid = smoothstep(_Threshold, _Threshold + 0.3, field);

                return half4(color * liquid, 1);
            }
            ENDHLSL
        }
    }
}