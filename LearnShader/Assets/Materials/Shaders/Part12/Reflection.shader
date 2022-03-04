Shader "Custom/Reflection"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap ("NormalMap", 2D) = "bump" {}
        _MaskMap ("MaskMap", 2D) = "white" {}
        _CubeMap ("CubeMap", Cube) = "white" {}
        _AlbedoIntencity ("Albedo Intencity",Range(0,1))=0.5
        _EmissionIntencity ("Emission Intencity",Range(0,1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
  
        CGPROGRAM
        
        #pragma surface surf Lambert noambient
 
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _MaskMap;
        samplerCUBE _CubeMap;
        float _AlbedoIntencity;
        float _EmissionIntencity;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_MaskMap;
            float3 worldRefl; INTERNAL_DATA
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 m = tex2D(_MaskMap, IN.uv_MaskMap);

            //normal
            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed3 normal = UnpackNormal(n);
            o.Normal = normal;

            //cubemap reflect
            float invetmr = 1 - m.r;
            float3 worldRefl = WorldReflectionVector(IN, o.Normal);
            float4 refl = texCUBE(_CubeMap, worldRefl);

            //final
            o.Albedo = c.rgb * _AlbedoIntencity*invetmr;
            o.Emission = refl.rgb* _EmissionIntencity*m.r;
           
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
