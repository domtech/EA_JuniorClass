Shader "zerinlabs/sh_fx_SOLID_vegetationMoving"
{
	
	Properties
	{
		[Header(LIGHTING PARAMETERS)]
		_Metallic("Metallic", Range(0,1)) = 0.1
		_Smoothness("Smoothness", Range(0,1)) = 0.1

		[Header(VEGETATION COLOUR PARAMETERS)]
		_Color("Color A", Color) = (1,1,1,1)
		_Color2("Color B", Color) = (1,1,1,1)
		_MainTex("DF (DiffuseMap)", 2D) = "white" {}

		[Header(WORLDMAP COLOUR PARAMETERS)]
		_DF2("WM (WorldMap)", 2D) = "white" {}
		_DiffuseScale("WorldMap scale (WM)", Float) = 0.5

		[Space(20)]
		_influence("WM intensity", Range(0, 1)) = 1.0

		[Header(ANIMATION PARAMETERS)]
		_movementAmount("Amplitude", Float) = 0.5
		_movementSpeed("Speed", Float) = 0.5

		
	}

	SubShader
	{

		Tags
		{ 
			"Queue" = "Geometry" 
		}

		LOD 200

		CGPROGRAM

		#pragma surface surf Standard vertex:vert addshadow

		sampler2D _MainTex;
		sampler2D _DF2;
		float _DiffuseScale;
		fixed4 _Color;
		fixed4 _Color2;
		float _movementAmount;
		float _movementSpeed;
		float _Metallic;
		float _Smoothness;
		float _influence;

		struct Input 
		{
			float2 uv_MainTex;
			float3 vertexCol;

			float3 worldPos; //world mapping coords	
		};

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			
			float3 wPos = mul(unity_ObjectToWorld, v.vertex).xyz;

			float movAmount = _movementAmount * v.color.r ;// *sin(_Time);

			float3 vColTotal = v.color * 2.0 - 1.0;

			float stepPosX = sin((_Time + wPos.x * (vColTotal.g + vColTotal.b)) * _movementSpeed) * movAmount;
			float stepPosY = cos((_Time + wPos.y * vColTotal.g) * _movementSpeed) * movAmount;
			float stepPosZ = sin((_Time + wPos.z * vColTotal.b) * _movementSpeed) * movAmount;

			v.vertex.xyz += float3(stepPosX, stepPosY, stepPosZ);

			o.vertexCol = v.color;
		}

		/*
		https://docs.unity3d.com/Manual/SL-SurfaceShaders.html
		struct SurfaceOutputStandard
		{
			fixed3 Albedo;      // base (diffuse or specular) color
			fixed3 Normal;      // tangent space normal, if written
			half3 Emission;
			half Metallic;      // 0=non-metal, 1=metal
			half Smoothness;    // 0=rough, 1=smooth
			half Occlusion;     // occlusion (default 1)
			fixed Alpha;        // alpha for transparencies
		};
		*/

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			float2 uvs = IN.worldPos.xz * _DiffuseScale;

			fixed4 col = lerp(_Color2, _Color, IN.vertexCol.r);
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * col;
			float alpha = c.a;
			fixed4 c_world = tex2D(_DF2, uvs) * col;

			c = lerp(c, c_world, _influence);

			o.Albedo = c.rgb;
			o.Alpha = alpha;

			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
		}
		 
		ENDCG
	}
	
	Fallback "Diffuse"
}