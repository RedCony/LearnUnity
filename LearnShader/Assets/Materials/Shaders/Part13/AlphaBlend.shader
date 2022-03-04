Shader "Custom/AlphaBlend"
{
    Properties
    {
        _Color("Main Color",Color)=(1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Cutoff("Alpha cutoff",Range(0,1))=0.5
    }
    SubShader
    {
        Tags { "RenderType"= "Transparent" "Queue" = "AlphaTest" }
        Cull Off
        Zwrite Off

        CGPROGRAM
       
        #pragma surface surf Lambert alphatest:_Cutoff

        //#pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
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
