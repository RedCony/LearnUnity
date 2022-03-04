Shader "Custom/UV"
{
    Properties
    {
       
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _UVx("UVx",Range(0,1)) = 0
        _UVy("UVy",Range(0,1)) = 0
        _Speed("Speed",float) = 1
        _Dir("Dir",Range(-1,1))=0

        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
       

        CGPROGRAM
        
        #pragma surface surf Standard 

       

        sampler2D _MainTex;
        float _UVx;
        float _UVy;
        float _Speed;
        float _Dir;

        struct Input
        {
            float2 uv_MainTex;
        };

      

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            
            float2 uv = IN.uv_MainTex;
            
            //fixed4 c = tex2D (_MainTex,float2(uv.x+_UVx,uv.y+ _UVy));
            fixed4 c = tex2D(_MainTex, float2(uv.x + _UVx, uv.y + _UVy + (_Dir *(_Time.y * _Speed))));
            //fixed4 c = tex2D(_MainTex,uv +_Time.y);
            o.Albedo = c.rgb;
            //o.Emission = float3(IN.uv_MainTex.x,IN.uv_MainTex.y,0);
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
