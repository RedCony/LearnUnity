Shader "Custom/Surface"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("BumpMap", 2D) = "Bump" {}
        _Occlusion("Occlusion", 2D) = "white" {}
        _Metallic("Metallic",Range(0,1))=0
        _Smoothness("Smoothness",Range(0,1))=0.5
        _Intencity("Intencity",float)=1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard 
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _Occlusion;
        float _Metallic;
        float _Smoothness;
        float _Intencity;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 occ = tex2D(_Occlusion,IN.uv_MainTex);
            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed3 normal= UnpackNormal(n);

            o.Normal = float3(normal.xy * _Intencity,normal.z);
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;
            o.Occlusion = occ.r;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
