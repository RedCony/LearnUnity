Shader "Custom/toon2"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _OutlineTex("outlint texture", 2D) = "white"{}
        _BumpMap("NormalMap", 2D) = "bump" {}
        _LineLength("LineLength",Range(0,1)) = 0.005
        _LineCol("Line Color",Color) = (1,1,1,1)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            Cull Front

            CGPROGRAM

            #pragma surface surf _Nolight vertex:vert noshadow noambient


            //#pragma target 3.0
           
            sampler2D _OutlineTex;
            float _LineLength;
            float4 _LineCol;
        
        void vert(inout appdata_full v)
        {
            
            v.vertex.xyz = v.vertex.xyz + (v.normal.xyz * _LineLength);
        }

        struct Input
        {
            float2 uv_OutlineTex;
            float4 color:COLOR;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_OutlineTex, IN.uv_OutlineTex);
            o.Emission = c.rgb + abs(sin(_Time.y));
            o.Alpha = c.a;
        }
        float4 Lighting_Nolight(SurfaceOutput s,float3 lightDir,float atten)
        {
            float4 final;
            final.rgb = s.Emission * _LineCol;
            final.a = s.Alpha;
            return final;

        }
        ENDCG

        Cull Back
        CGPROGRAM
        #pragma surface surf _Toon 
        
        sampler2D _MainTex;
        sampler2D _BumpMap;
       

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float4 color:COLOR;
        };
        void surf(Input IN, inout SurfaceOutput o)
        {

            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed3 normal = UnpackNormal(n);

            o.Albedo = c.rgb;
            o.Normal = normal.rgb;
            o.Alpha = c.a;
        }
        float4 Lighting_Toon(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            float ndot1 = dot(s.Normal, lightDir) * 0.5 + 0.5;
            
            if (ndot1 > 0.7) { ndot1 = 1; }
            else if (ndot1 > 0.4) { ndot1 = 0.3; }
            else { ndot1 = 0; }
            /*
            ndot1 = ndot1 * 5;
            ndot1 = ceil(ndot1) / 5;
            */
            float4 final;
            final.rgb = s.Albedo * ndot1 * _LightColor0.rgb;
            final.a = s.Alpha;
            return final;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
