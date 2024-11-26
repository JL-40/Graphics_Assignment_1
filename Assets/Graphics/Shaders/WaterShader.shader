Shader "Sorcery/WaveFromOriginPoint"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _PointX("PointX", Range(-1, 1)) = 0
        _PointY("PointY", Range(-1, 1)) = 0

        
        _Amplitude ("Amplitude", float) = 0.5
        _Frequency ("Frequency", float) = 1.0
        _Speed ("Speed", float) = 1.0
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc" 

            
            float _Amplitude;
            float _Frequency;
            float _Speed;

            float _PointX;
            float _PointY;

            sampler2D _MainTex;
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;  
            };

            
            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float distance : TEXCOORD1;
            };

            
            v2f vert(appdata v)
            {
                v2f o;

                

                float2 Origin = float2(_PointX, _PointY);  

                
                float2 relativeToOrigin = v.uv * 2.0 - 1.0;  


                //Should get us the distance this vertex is from the wave's origin point.
                float2 diff = relativeToOrigin - Origin;
                float distance = sqrt(dot(diff, diff));

                
                float waveHeight = sin(distance * _Frequency + _Time.y * _Speed) * _Amplitude;
                //I took out the second peice for simplicity. visually it doesnt seem to matter much.

                v.vertex.y += waveHeight;

         
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.distance = distance; //this was for testing...ill leave it in, just in case it breaks before our performance later.

                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                //return half4(i.distance, i.distance, i.distance, 1.0); //(old visualisation Code)
                half4 texColor = tex2D(_MainTex, i.uv);

                return texColor;
            }
            ENDCG
        }
    }
}
