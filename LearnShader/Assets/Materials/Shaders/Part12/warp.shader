Shader "Custom/warp"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap ("NormalMap", 2D) = "bump" {}
        _GlossTex("Gloss Tex",2D) = "white"{}
        _RampTex ("RampTex", 2D) = "white" {}
        _LineLength("LineLength",Range(0,1)) = 0.005
        _LineCol("Line Color",Color) = (0,0,0,1)
        _SpecCol("Specular Color",Color) = (1,1,1,1)
        _SpecPow("Specular Power",Range(10,200)) = 100
        _SpecCol2("Specular Color2",Color) = (1,1,1,1)
        _SpecPow2("Specular Power2",Range(10,200)) = 50
        _RimCol("Rim Color",Color) = (1,1,1,1)
        _RimPow("Rim Power",Range(1,20)) = 6
        
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        //1pass
        cull front

        CGPROGRAM

        #pragma surface surf _NoLight vertex:vert

        float _LineLength;
        float4 _LineCol;

        void vert(inout appdata_full v)
        {
             v.vertex.xyz += v.normal.xyz * _LineLength;
        }
        struct Input
        {
            float4 color:COLOR;
        };
        void surf(Input IN, inout SurfaceOutput o)
        {
        }
        float4 Lighting_NoLight(SurfaceOutput s, float3 lightDir, float atten)
        {
            return _LineCol;
        }
        ENDCG

        //2pass
        cull back

        CGPROGRAM
      
        #pragma surface surf _Warp noambient

        //#pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _RampTex;
        sampler2D _GlossTex;
        float4 _SpecCol;
        float _SpecPow;
        float4 _SpecCol2;
        float _SpecPow2;
        float4 _RimCol;
        float _RimPow;
       
        

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_GlossTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 n = tex2D(_BumpMap, IN.uv_BumpMap);
            fixed4 g = tex2D(_GlossTex, IN.uv_GlossTex);
            fixed3 normal = UnpackNormal(n);
            
            o.Albedo = c.rgb;
            o.Normal = normal.rgb;
            o.Gloss = g.a;
            o.Alpha = c.a;
        }
        float4 Lighting_Warp(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            float4 final;

            //half-lambert
            float ndotl = dot(s.Normal, lightDir) * 0.5 + 0.5;

            //spec
            float3 H = normalize(lightDir + viewDir);
            float spec = saturate(dot(s.Normal, H));
            spec = pow(spec, _SpecPow)* _SpecCol * s.Gloss;

            //rim
            float rim = abs(dot(s.Normal,viewDir));
            rim = pow(1 - rim, _RimPow);

            //fakespec
            float3 SpecColor2;
            SpecColor2 = pow(rim, _SpecPow2) * _SpecCol2.rgb * s.Gloss;

            //ramp
            fixed4 ramp = tex2D(_RampTex, float2(ndotl, spec));
            fixed4 ramp1 = tex2D(_RampTex, float2(ndotl, rim));
         
            //final
            final.rgb = s.Albedo.rgb * ((ramp.rgb+ramp1.rgb)+0.5+ SpecColor2.rgb);
            final.a = s.Alpha;

            return final;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
