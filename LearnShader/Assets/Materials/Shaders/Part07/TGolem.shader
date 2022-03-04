Shader "Custom/TGolem"
{
    Properties
    {
       
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("BumpMap", 2D) = "Bump" {}
        _Occlusion("Occlusion", 2D) = "white" {}
        _Metallic("Metallic",Range(0,1)) = 0
        _MetallicIntencity("MetallicIntencity",Range(0,1)) = 0
        _Smoothness("Smoothness",Range(0,1)) = 0.5
        _SmoothnessIntencity("SmoothnessIntencity",Range(0,1)) = 0.5
        _Intencity("Intencity",float) = 1
       
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
   
        CGPROGRAM
 
        #pragma surface surf Standard 

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _BumpMap;
        sampler2D _Occlusion;
        float _Metallic;
        float _MetallicIntencity;
        float _Smoothness;
        float _SmoothnessIntencity;
        float _Intencity;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
            float2 uv_BumpMap;
            float4 color:COLOR;
        };

      

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 d = tex2D(_MainTex2, IN.uv_MainTex2);
            fixed4 occ = tex2D(_Occlusion, IN.uv_MainTex);
            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed3 normal = UnpackNormal(n);

            o.Normal = float3(normal.xy * _Intencity, normal.z);
            o.Albedo =lerp(c.rgb,d.rgb,IN.color.r);
            o.Metallic = (IN.color.r * _MetallicIntencity * 0.5) + _Metallic;
            o.Smoothness =(IN.color.r* _SmoothnessIntencity*0.5) + _Smoothness;
            o.Occlusion = occ.r;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
