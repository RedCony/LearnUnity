Shader "Custom/Alpha2Pass"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"= "Transparent" "Queue" = "Transparent" }

        Zwrite ON
        ColorMask 0

        CGPROGRAM
        #pragma surface surf _Nolight noambient noforwardadd nolightmap novertexlights noshadow

        #pragma target 3.0

        struct Input
        {
            float4 color:COLOR;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            
        }
        float4 Lighting_Nolight(SurfaceOutput s,float3 lightDir,float atten)
        {
            return float4(0, 0, 0, 0);
        }
        ENDCG

        Zwrite OFF

        CGPROGRAM
        #pragma surface surf Lambert alpha:fade

        //#pragma target 3.0
        sampler2D _MainTex;
        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = 0.5;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
