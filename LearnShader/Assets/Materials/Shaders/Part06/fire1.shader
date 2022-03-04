Shader "Custom/fire1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2("Albedo2 (RGB)", 2D) = "white" {}
        _MainTex3("Albedo3 (RGB)", 2D) = "white" {}
       
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
        sampler2D _MainTex3;
        
        float _Speed;
        float _Dir;
        float _Noise;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2;
            float2 uv_MainTex3;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uvd = IN.uv_MainTex2 * _Noise;
           
            fixed4 d = tex2D(_MainTex2,float2(uvd.x,uvd.y + (_Dir *_Time.y * _Speed* _Noise)));
           
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex+d.r) ;
            fixed4 e = tex2D(_MainTex3, IN.uv_MainTex3 + d.r);
           
            o.Emission = c.rgb+e.rgb;
          
            o.Alpha = c.a*e.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
