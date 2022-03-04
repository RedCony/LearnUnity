Shader "Custom/CustomLight"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("NormalMap", 2D) = "bump" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf _Test 
        //#pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed3 normal = UnpackNormal(n);

            o.Albedo = c.rgb;
            o.Normal = float3(normal.x, normal.y, normal.z);
            o.Alpha = c.a;
        }
        float4 Lighting_Test (SurfaceOutput s ,float lightDir,float atten)
        {
            float ndotl = dot(s.Normal, lightDir)* 0.5 + 0.5;
            float powNdotl = pow(ndotl, 3);
            float4 final;
            final.rgb = powNdotl * s.Albedo * _LightColor0.rgb * atten;
            final.a = s.Alpha;
            return final;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
