Shader "Custom/lerp"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("BG (RGB)", 2D) = "white" {}
        _lerpTest("lerpTest",Range(0,1)) = 0
        _AlphaTest("AlphaTest",Range(0,1)) = 0
        _AlphaBrightDark("AlphaBright & Darkness",Range(-1,1)) = 0

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
       
        CGPROGRAM
        #pragma surface surf Standard 

        sampler2D _MainTex;
        sampler2D _MainTex2;
        float _lerpTest;
        float _AlphaTest;
        float _AlphaBrightDark;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 d = tex2D(_MainTex2, IN.uv_MainTex2);
            o.Albedo = lerp(c.rgb,d.rgb,((1- _AlphaTest)  +_lerpTest ));
            _AlphaTest = c.a;
            o.Alpha = (_AlphaTest * _AlphaBrightDark);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
