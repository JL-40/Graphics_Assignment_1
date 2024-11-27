Shader "Sorcery/TransparentGem"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)

        _Opacity("Alpha", Range(0.0,1.0)) = 1.0

        [MaterialToggle] _doFlash ("flashing", float) = 0

        _Amount ("Extrude", Range(-1,30)) = 0.001
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }

        CGPROGRAM
        #pragma surface surf Standard alpha:fade vertex:vert

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        float _Opacity;

        float _doFlash;

        float _Amount;

        struct appdata
        {
            float4 vertex: POSITION;
            float3 normal: NORMAL;
            float4 texcoord: TEXCOORD0;
        };

        void vert (inout appdata v) {
            if (_doFlash)
            {
                v.vertex.xyz += v.normal * abs(_Amount * sin(_Time.z * 5)) / 100;
            }
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            
            o.Albedo = _Color.rgb;

            o.Alpha = _Opacity;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
