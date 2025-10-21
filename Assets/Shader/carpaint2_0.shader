Shader "Car/CarPain2" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (1,1,1,1)
 _AmbientColor ("Metalic Color", Color) = (1,1,1,1)
 _AmbientColor2 ("Candy Color", Color) = (1,1,1,1)
 _ReflectionColor ("Reflection Color", Color) = (1,1,1,1)
 _Shininess ("Glossiness", Range(0.1,2)) = 0.5
 _MainTex ("Diffuse", 2D) = "white" {}
 _FlakeTex ("Flakes", 2D) = "white" {}
 _FlakeDens ("Flakes Tile", Range(1,40)) = 2
 _Cube ("Reflection Cubemap", CUBE) = "" { TexGen CubeReflect }
 _FresnelScale ("Fresnel Intensity", Range(0,2)) = 0
 _FresnelPower ("Fresnel Power", Range(0.1,3)) = 0
 _MetalicScale ("Metalic Intensity", Range(0,4)) = 0
 _MetalicPower ("Metalic Power", Range(0,20)) = 0
 _CandyScale ("Candy Intensity", Range(0,4)) = 0
 _CandyPower ("Candy Power", Range(0,20)) = 0
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