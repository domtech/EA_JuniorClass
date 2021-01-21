// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "zerinlabs/sh_regular_SOLID_groundWorldCoords_props"
{
	Properties
	{
		//
		[Header(GROUND LIGHTING PARAMETERS)]
		_MetallicFactor1("Metallic Factor",Range(0, 1)) = 0
		_GlossMapScale1("Smoothness", Range(0, 1)) = 0

		[Header(GROUND PARAMETERS)]
		[NoScaleOffset]
		_DF1("DF (DiffuseMap)", 2D) = "white" {}
		[NoScaleOffset]
		_NM1("NM (Normalmap)", 2D) = "bump" {}
		_BumpScale1("NM intensity", float) = 1.0
		_DiffuseScale("WorldMap scale (DF/NM)", float) = 1.0
		
		[Space(20)]
		[NoScaleOffset]
		_DM("DM (DetailMap)", 2D) = "white" {}
		_DMScale("DM intensity", range(0, 1)) = 1.0
		_DetailScale("WorldMap scale (DM)", float) = 1.0
		
		[Header(WALLS LIGHTING PARAMETERS)]
		_MetallicFactor2("Metallic Factor",Range(0, 1)) = 0
		_GlossMapScale2("Smoothness", Range(0, 1)) = 0
		
		[Header(WALLS PARAMETERS)]
		_DF2("DF (DiffuseMap)",2D) = "white" {}
		[NoScaleOffset]
		_NM2("NM (NormalMap)", 2D) = "bump" {}
		_BumpScale2("NM intensity", float) = 1.0

		[Header(TRANSITION MASK PARAMETERS)]
		[NoScaleOffset]
		_MK("MK (MaskMap)",2D) = "white" {}
		_maskPos("Mask position", Range(0, 1)) = 0.5
		_maskRange("Mask range", Range(0, 0.5)) = 0.05
		_MaskScale("WorldMap scale (MK)", float) = 1.0

		[Header(OTHER PARAMETERS)]
		_TopBottom("Top/Bottom mask influence", Range(0, 1)) = 1.0
		_Mask("VC mask influence", Range(0, 1)) = 1.0
	}

	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
			"Queue" = "Geometry" 
		}

		LOD 200

		CGPROGRAM

		#pragma surface surf Standard fullforwardshadows vertex:vert
		#pragma target 3.0

		float _MetallicFactor1;
		float _GlossMapScale1;

		sampler2D _DF1;
		sampler2D _NM1;
		float _BumpScale1;
		float _DiffuseScale;

		sampler2D _DM;
		float _DetailScale;
		float _DMScale;

		float _MetallicFactor2;
		float _GlossMapScale2;

		sampler2D _DF2;
		sampler2D _NM2;
		float _BumpScale2;

		sampler2D _MK;
		float _maskPos;
		float _maskRange;
		float _MaskScale;

		float _TopBottom;
		float _Mask;

		struct Input
		{
			//float2 uv_DF1;
			//float2 uv_NM1;
			float2 uv_DF2;
			//float2 uv_NM2;
			//float2 uv_MK;

			fixed4 color : COLOR;

			float NdotUP;

			float2 wPos_DF;
			float2 wPos_MK;

			float3 worldPos; //world mapping coords
		};

		/*
		struct appdata_full
		{
			//float4 vertex : POSITION;
			//float4 tangent : TANGENT;
			//float3 normal : NORMAL;
			fixed4 color : COLOR;
			//float4 texcoord : TEXCOORD0;
			//float4 texcoord1 : TEXCOORD1;
			//half4 texcoord2 : TEXCOORD2;
			//half4 texcoord3 : TEXCOORD3;
			//half4 texcoord4 : TEXCOORD4;
			//half4 texcoord5 : TEXCOORD5;
		};
		*/

		void vert(inout appdata_full v, out Input o)
		{

			UNITY_INITIALIZE_OUTPUT(Input, o);

			o.NdotUP = saturate(dot(normalize(mul(unity_ObjectToWorld, float4(v.normal, 0.0))), float4(0, 1, 0, 0)));
			
			float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
			o.wPos_DF = worldPos.xz *_DiffuseScale;
			o.wPos_MK = worldPos.xz *_MaskScale;
		}

		/*
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
			//DM (detailmap)
			fixed4 DM = tex2D(_DM, IN.worldPos.zx * _DetailScale) * 2.0 - 1.0;
			DM = DM * _DMScale;
			
			// DF & NM 1 (ground)
			fixed4 DF_1 = tex2D(_DF1, IN.wPos_DF) + DM.r;
			float3 NM_1 = lerp(fixed3(0.0, 0.0, 1.0), UnpackNormal(tex2D(_NM1, IN.wPos_DF)), _BumpScale1).rgb;
			
			// DF & NM 2 (walls)
			fixed4 DF_2 = tex2D(_DF2, IN.uv_DF2);
			float3 NM_2 = lerp(fixed3(0.0, 0.0, 1.0), UnpackNormal(tex2D(_NM2, IN.uv_DF2)), _BumpScale2).rgb;
			
			// MK (transition mask: ground >>> walls)
			float MK = tex2D(_MK, IN.wPos_MK).r * _TopBottom;
			float MK_VC = IN.color.r * _Mask;

			float min = saturate(_maskPos - _maskRange);
			float max = saturate(_maskPos + _maskRange);
			float topBottomMask = smoothstep(min, max, (IN.NdotUP + MK) * IN.NdotUP);
			topBottomMask = saturate(topBottomMask + MK_VC);
			topBottomMask = 1.0 - saturate(topBottomMask); //flip mask for comfortable use

			//composites
			float4 composite_DF = lerp(DF_1, DF_2, topBottomMask);
			float3 composite_NM = lerp(NM_1, NM_2, topBottomMask);
			float4 composite_Metallic = lerp(_MetallicFactor1, _MetallicFactor2, topBottomMask);
			float3 composite_Gloss = lerp(_GlossMapScale1, _GlossMapScale2, topBottomMask);

			o.Albedo = composite_DF;
			o.Alpha = composite_DF.a;

			o.Normal = composite_NM;

			o.Metallic = composite_Metallic;
			o.Smoothness = composite_Gloss;
		}

	ENDCG

	}

	FallBack "Diffuse"
}