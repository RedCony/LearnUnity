Shader "Custom/holo3"
{
    Properties
    {
        
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("NormalMap",2D) = "Bump"{}
        _Color("HoloColor",Color) = (1,1,1,1)
        _RimColor("RimColor",Color) = (1,1,1,1)
        _RimPower("RimPower",Range(1,10)) = 3
        _speed("speed",Range(1,10)) = 3
    }
    SubShader
    {
        Tags { "RenderType"= "Transparent" "Queue" = "Transparent" }
        LOD 200

        CGPROGRAM
       
        #pragma surface surf _nolight noambient alpha:fade

       
        //#pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        float4 _Color;
        float4 _RimColor;
        float _RimPower;
        float _speed;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float3 viewDir;
            float3 worldPos;
        };

       

        void surf (Input IN, inout SurfaceOutput o)
        {
            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Emission = _Color;

            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed3 normal = UnpackNormal(n);
            o.Normal = float3(normal.x, normal.y, normal.z);

            float holo = pow(frac(IN.worldPos.g * 3 - _Time.y), 30);
            
            float ndotv = saturate(dot(o.Normal, IN.viewDir));
            float rim = pow(1 - ndotv, 3);
            float alpha = rim + holo;
            o.Alpha = alpha;

        }
        float4 Lighting_nolight(SurfaceOutput s,float3 lightDir,float atten)
        {
            return float4(0,0,0,s.Alpha);
        }
        ENDCG
    }
    FallBack "Transparent/Diffuse"
}
