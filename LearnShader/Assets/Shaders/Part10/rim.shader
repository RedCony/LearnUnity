Shader "Custom/rim"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("NormalMap",2D) = "Bump"{}
        _RimColor("RimColor",Color)=(1,1,1,1)
        _RimPower("RimPower",Range(1,10))=3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
      
        CGPROGRAM
        
        #pragma surface surf Lambert 

        //#pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        float4 _RimColor;
        float _RimPower;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;

            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed3 normal = UnpackNormal(n);
            o.Normal = float3(normal.x, normal.y, normal.z);

            float rim = saturate(dot(o.Normal, IN.viewDir));
            o.Emission =pow(1-rim, _RimPower)* _RimColor.rgb;

            o.Alpha = c.a;
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}
