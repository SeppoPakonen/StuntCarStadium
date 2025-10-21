Shader "Tasharen/Water" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _WaterTex ("Normal Map (RGB), Foam (A)", 2D) = "white" {}
 _ReflectionTex ("Reflection", 2D) = "white" { TexGen ObjectLinear }
 _Cube ("Skybox", CUBE) = "_Skybox" { TexGen CubeReflect }
 _Color0 ("Shallow Color", Color) = (1,1,1,1)
 _Color1 ("Deep Color", Color) = (0,0,0,0)
 _Specular ("Specular", Color) = (0,0,0,0)
 _Shininess ("Shininess", Range(0.01,1)) = 1
 _Tiling ("Tiling", Range(0.025,0.25)) = 0.25
 _ReflectionTint ("Reflection Tint", Range(0,1)) = 0.8
 _InvRanges ("Inverse Alpha, Depth and Color ranges", Vector) = (1,0.17,0.17,0)
}
	//DummyShaderTextExporter
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Lambert
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
}