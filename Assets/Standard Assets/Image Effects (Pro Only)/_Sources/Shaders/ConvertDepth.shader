<html><body><h1>403 Forbidden</h1>
Request forbidden by administrative rules.
</body></html>
hader code pasted into all further CGPROGRAM blocks
	CGINCLUDE
		
	#include "UnityCG.cginc"
	
	struct v2f {
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};
		
	sampler2D _MainTex;
	sampler2D_float _CameraDepthTexture;
		
	v2f vert( appdata_img v ) 
	{
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv =  v.texcoord.xy;
		return o;
	}
	
	half4 frag(v2f i) : SV_Target 
	{
		float d = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv.xy);
		d = Linear01Depth(d);
			 
		if(d>0.99999)
			return half4(1,1,1,1);
		else
			return EncodeFloatRGBA(d); 
	}

	ENDCG
	
Subshader {
	
 Pass {
	  ZTest Always Cull Off ZWrite Off
	  Fog { Mode off }      

      CGPROGRAM
      #pragma fragmentoption ARB_precision_hint_fastest
      #pragma vertex vert
      #pragma fragment frag
      ENDCG
  }
}

Fallback off
	
} // shader