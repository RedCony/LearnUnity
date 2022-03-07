Shader "Custom/Refraction"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _RefStrength("Reflection Strength",Range(0,0.1))=0.05
    }
        SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue"= "Transparent"}
        Zwrite Off
        GrabPass{}

        CGPROGRAM
        #pragma surface surf _NoLight noambient alpha:fade
        //#pragma target 3.0

        sampler2D _GrabTexture;
        sampler2D _MainTex;
        float _RefStrength;

        struct Input
        {
            float4 color:COLOR;
            float4 screenPos;
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            float3 screenUV = IN.screenPos.rgb / IN.screenPos.a;
            fixed4 d = tex2D(_GrabTexture, screenUV.xy+(c.r* _RefStrength));
            o.Emission = d.rgb;
        }
        float4 Lighting_NoLight(SurfaceOutput s,float3 lightDir , float atten)
        {
            return float4(0, 0, 0, 1);
        }
        ENDCG
    }
    FallBack "Legacy Shaders/Transparent/VertexLit"
}
