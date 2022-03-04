Shader "Custom/leaves"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Cutoff("Cutoff",float)=0.5
        _Move("Move",Range(0,0.5))=0.1
        _Timeing("Timeing",Range(0,5)) =1
    }
    SubShader
    {
        Tags { "RenderType"="TransparentCutout" "Opaque"="AlphaTest"}

        CGPROGRAM
        #pragma surface surf Lambert alphatest:_Cutoff vertex:vert addshadow
        //#pragma target 3.0

        sampler2D _MainTex;
        float _Move;
        float _Timeing;

        void vert(inout appdata_full v)
        {
            v.vertex.y += sin(_Time.y* _Timeing)* _Move *v.color.r;
        }

        struct Input
        {
            float2 uv_MainTex;
            float4 color:COLOR;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Legacy Shaders/Transparent/Cutout/VertexLit"
}
