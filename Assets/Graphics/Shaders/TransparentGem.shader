Shader "Sorcery/TransparentGem"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)

        _Opacity("Alpha", Range(0.0,1.0)) = 1.0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }

        CGPROGRAM
        #pragma surface surf Standard alpha:fade

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;

        float _Opacity;

        

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
