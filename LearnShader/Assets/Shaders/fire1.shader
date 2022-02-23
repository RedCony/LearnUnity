Shader "Custom/fire1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2("Albedo (RGB)", 2D) = "white" {}
       
        _Speed("Speed",float) = 0
        _Dir("Dir",Range(-1,1)) = 0
        _Noise("Noise",float)=0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"= "Transparent" }
     
        CGPROGRAM
        #pragma surface surf Standard alpha:fade

        sampler2D _MainTex;
        sampler2D _MainTex2;
        
        float _Speed;
        float _Dir;
        float _Noise;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uvd = IN.uv_MainTex2;
            fixed4 d = tex2D(_MainTex2,float2(uvd.x,uvd.y + (_Dir * (_Time.y * _Speed))));
           
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex+d.r) ;
           
            o.Emission = c.rgb;
          
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
