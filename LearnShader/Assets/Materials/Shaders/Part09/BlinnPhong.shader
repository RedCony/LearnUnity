Shader "Custom/BlinnPhong"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SpecColor("Specula Color",color)=(1,1,1,1)
        _Spcular("Specular",Range(0,1)) = 0.5
        _Gloss("Gloss",Range(0,1) ) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
      
        #pragma surface surf BlinnPhong
      
       // #pragma target 3.0

        sampler2D _MainTex;
        float _Spcular;
        float _Gloss;

        struct Input
        {
            float2 uv_MainTex;
        };
       
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) ;
            o.Albedo = c.rgb;
            o.Specular = 0.5* _Spcular;
            o.Gloss = 1* _Gloss;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
