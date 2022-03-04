Shader "Custom/toon"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _LineLength("LineLength",Range(0,1)) = 0.01
        _LineCol("Line Color",Color) = (1,1,1,1)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            Cull Front

            CGPROGRAM

            #pragma surface surf _Nolight vertex:vert noshadow noambient


            //#pragma target 3.0

            float _LineLength;
            float4 _LineCol;
        
        void vert(inout appdata_full v)
        {
            v.vertex.xyz = v.vertex.xyz + v.normal.xyz* _LineLength * sin(_Time.y);
        }

        struct Input
        {
            float4 color:COLOR;
        };

       

        void surf (Input IN, inout SurfaceOutput o)
        {
           
        }
        float4 Lighting_Nolight(SurfaceOutput s,float3 lightDir,float atten)
        {
            return _LineCol;
        }
        ENDCG

        Cull Back
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };
        void surf(Input IN, inout SurfaceOutput o)
        {

            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;

            o.Alpha = c.a;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
