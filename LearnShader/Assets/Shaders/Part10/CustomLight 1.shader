Shader "Custom/CustomLight1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("NormalMap", 2D) = "bump" {}
        _GlossTex("Gloss Tex",2D) = "white"{}
        _SpecCol("Specular Color",Color) = (1,1,1,1)
        _SpecPow("Specular Power",Range(10,200)) = 100
        _SpecCol2("Specular Color2",Color) = (1,1,1,1)
        _SpecPow2("Specular Power2",Range(10,200)) = 50
        _RimCol("Rim Color",Color) = (1,1,1,1)
        _RimPow("Rim Power",Range(1,20)) = 6
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf _Test 
        //#pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _GlossTex;
        float4 _SpecCol;
        float _SpecPow;
        float4 _SpecCol2;
        float _SpecPow2;
        float4 _RimCol;
        float _RimPow;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_GlossTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed4 m = tex2D(_GlossTex, IN.uv_GlossTex);
            fixed3 normal = UnpackNormal(n);

            o.Albedo = c.rgb;
            o.Normal = float3(normal.x, normal.y, normal.z);
            o.Gloss = m.a;
            o.Alpha = c.a;
        }
        float4 Lighting_Test (SurfaceOutput s ,float lightDir,float3 viewDir,float atten)
        {
            
            float3 DiffColor;
            float ndotl =saturate(dot(s.Normal, lightDir));
            DiffColor = ndotl * s.Albedo * _LightColor0.rgb * atten;

            float3 SpecColor;
            float H = normalize(lightDir + viewDir);
            float spec = saturate(dot(H, s.Normal));
            spec = pow(spec, _SpecPow);
            SpecColor = spec * _SpecCol.rgb*s.Gloss;

            float3 rimColor;
            float rim = abs(dot(viewDir, s.Normal));
            float invrim = 1 - rim;
            rimColor = pow(invrim, _RimPow) * _RimCol.rgb;

            float3 SpecColor2;
            SpecColor2 = pow(rim, _SpecPow2) * _SpecCol2.rgb * s.Gloss;

            float4 final;
            final.rgb = DiffColor.rgb+ SpecColor.rgb+rimColor.rgb+ SpecColor2.rgb;
            final.a = s.Alpha;
            return final;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
