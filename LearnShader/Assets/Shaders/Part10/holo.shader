Shader "Custom/holo"
{
    Properties
    {
        
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Color("HoloColor",Color)=(1,1,1,1)
        _RimColor("RimColor",Color) = (1,1,1,1)
        _RimPower("RimPower",Range(1,10)) = 3
        _speed("speed",Range(1,10))=3
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
       

        CGPROGRAM
        
        #pragma surface surf Lambert noambient alpha:fade

        
        //#pragma target 3.0

        sampler2D _MainTex;
        float4 _Color;
        float4 _RimColor;
        float _RimPower;
        float _speed;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
        };

       
        void surf (Input IN, inout SurfaceOutput o)
        {
            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //o.Albedo = c.rgb;
            o.Emission = _Color.rgb;

            float rim = saturate(dot(o.Normal, IN.viewDir));
            rim = pow(1 - rim, _RimPower)* _RimColor.rgb;
          
            o.Alpha = rim*sin(abs(_Time.y* _speed));
        }
        ENDCG
    }
    FallBack "Diffuse"
}
