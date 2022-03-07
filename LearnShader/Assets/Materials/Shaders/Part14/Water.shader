Shader "Custom/Water"
{
    Properties
    {
        _BumpMap("NormalMap", 2D) = "bump" {}
        _CubeMap("CubeMap", Cube) = "white" {}
        _SPColor("Specular Color",color)=(1,1,1,1)
        _SPPower("Specular Power",Range(50,300))=150
        _SPMulti("Specular Multiply",Range(1,10))=3
        _WaveH("Wave Height",Range(0,0.5)) = 0.1
        _WaveL("Wave Length",Range(5,20)) = 12
        _WaveT("Wave Time",Range(0,10)) = 0.1
        _Refract("Refract Strength",Range(0,0.2))=0.1
    }
    SubShader
    {
        //Tags { "RenderType"= "Transparent" "Queue" = "Transparent" }
        Tags{"RenderType" = "Opaque"}

        GrabPass{}

        CGPROGRAM
        #pragma surface surf _WaterSpecular alpha:fade vertex:vert

        #pragma target 3.0

        sampler2D _BumpMap;
        samplerCUBE _CubeMap;
        sampler2D _GrabTexture;
        float4 _SPColor;
        float _SPPower;
        float _SPMulti;
        float _WaveH;
        float _WaveL;
        float _WaveT;
        float _Refract;

        void vert(inout appdata_full v)
        {
            float movement;
            movement = sin(abs((v.texcoord.x * 2 - 1) * _WaveL) + _Time.y* _WaveT) * _WaveH;
            movement += sin(abs((v.texcoord.y * 2 - 1) * _WaveL) + _Time.y* _WaveT) * _WaveH;
            v.vertex.y += movement / 2;
        }

        struct Input
        {
            float2 uv_BumpMap;
            float3 worldRefl;
            float3 viewDir;
            float4 screenPos;
            INTERNAL_DATA
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            //normal
            fixed4 n1 = tex2D(_BumpMap, IN.uv_BumpMap+_Time.x * 0.1);
            fixed4 n2 = tex2D(_BumpMap, IN.uv_BumpMap-_Time.x * 0.1);
            fixed3 normal1 = UnpackNormal(n1);
            fixed3 normal2 = UnpackNormal(n2);
            o.Normal = (normal1+ normal2)/2;

            //ref
            float3 worldRefl = WorldReflectionVector(IN, o.Normal);
            float4 refl = texCUBE(_CubeMap, worldRefl);

            //refraction
            float3 screenUV = IN.screenPos.rgb / IN.screenPos.a;
            float3 refraction = tex2D(_GrabTexture, (screenUV.xy+o.Normal.xy* _Refract));

            //rim
            float rim = saturate(dot(o.Normal, IN.viewDir));
            rim = pow(1 - rim, 3);


            o.Emission = refl*rim*2;
            //o.Alpha = saturate(rim+0.5);
            o.Alpha = 1;
        }
        float4 Lighting_WaterSpecular(SurfaceOutput s,float3 lightDir,float3 viewDir,float atten)
        {
            //spec
            float3 H = normalize(lightDir + viewDir);
            float spec = saturate(dot(H, s.Normal));
            spec = pow(spec, _SPPower);

            //final
            float4 final;
            final.rgb = spec * _SPColor * _SPMulti;
            final.a = s.Alpha;// +spec;

            return final;
        }
        ENDCG
    }
    FallBack "Legacy Shaders/Transparent/VertexLit"
}
