Shader "Custom/matcap"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap("NormalMap",2D)="bump"{}
        _Matcap("Matcap", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf _Nolight noambient

        //#pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _Matcap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float3 worldNormal;
            INTERNAL_DATA
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

            //normal
            fixed4 nm = tex2D(_BumpMap, IN.uv_BumpMap);
            o.Normal = UnpackNormal(nm);
            float3 worldNor = WorldNormalVector(IN, o.Normal);

            //matcap
            float3 viewNormal = mul((float3x3)UNITY_MATRIX_V, worldNor);
            float2 MatcapUV = viewNormal.xy * 0.5 + 0.5;
            fixed4 mc = tex2D(_Matcap, MatcapUV);

            //final
            o.Emission = c.rgb * mc.rgb;
            o.Alpha = c.a;
        }
        float4 Lighting_Nolight(SurfaceOutput s,float3 lightDir,float atten)
        {
            return float4(0, 0, 0, s.Alpha);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
