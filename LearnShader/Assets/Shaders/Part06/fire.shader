Shader "Custom/fire"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2("Albedo (RGB)", 2D) = "white" {}
        _Speed("Speed",float)=0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        CGPROGRAM
        #pragma surface surf Standard alpha:fade

        sampler2D _MainTex;
        sampler2D _MainTex2;
        float _Speed;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float dir = -1;
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) ;
            float2 uvd = IN.uv_MainTex2;
            fixed4 d = tex2D(_MainTex2, float2(uvd.x, uvd.y +(dir*(_Time.y * _Speed))));
            //o.Albedo = c.rgb;
            o.Emission = c.rgb*d.rgb;
            
            o.Alpha = c.a*d.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
