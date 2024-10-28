Shader "Sorcery/MainShadeWorld"{
    Properties {
        
        _Color("Color", Color) = (1.0,1.0,1.0)

        [MaterialToggle] _UseAmbiant ("Use Ambience", float) = 0

        [MaterialToggle] _UseSpecular ("Use Specular", float) = 0
        _SpecColor("Specular Color", Color) = (1.0,1.0,1.0) // MODIFIED
        _Shininess("Shininess", Range(0.0, 100)) = 10 // MODIFIED

        

    }
    SubShader {
        Pass{
			Tags {"LightMode" = "ForwardBase" "RenderType" = "Opaque"} // MODIFIED

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			// user defined variables
			uniform float4 _Color;
            uniform float4 _SpecColor;
            uniform float _Shininess;

            float _UseAmbiant;

            float _UseSpecular;

			// unity defined variables
			uniform float4 _LightColor0;

			// unity 3 definitions
			// float4x4 _Object2World;
			// float4x4 _World2Object;
			// float4 _WorldSpaceLightPos0;

			// base input structs

            struct Input {
                float2 uv_myDiffuse;
                float2 uv_myBump;
            };

			struct vertexInput {
                float4 vertex: POSITION;
                float3 normal: NORMAL;

			};

			struct vertexOutput {
                float4 pos: SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float4 normalDir : TEXCOORD1;
                float4 col: COLOR;
			};



			// vertex functions
			vertexOutput vert(vertexInput v) {
                vertexOutput o;

                float3 normalDirection = normalize(mul(float4(v.normal,0.0),unity_WorldToObject).xyz);


                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz); // MODIFIED
                float atten = 1.0;

                float3 diffuseReflection = atten * _LightColor0.xyz * (_UseAmbiant ? 1.0 : _Color.rgb) * max(0.0,dot(normalDirection, lightDirection)); // MODIFIED

                if (_UseAmbiant)
                {
                    //float3 diffuseReflection = atten * _LightColor0.xyz*max(0.0,dot(normalDirection, lightDirection)); // MODIFIED

                    float3 lightFinal = diffuseReflection + UNITY_LIGHTMODEL_AMBIENT.xyz;

                    o.col = float4(lightFinal * _Color.rgb, 1.0);
                }
                else
                {
                    o.col = float4(diffuseReflection, 1.0);
                }
                //o.pos = UnityObjectToClipPos(v.vertex); // MODIFIED

                if (_UseSpecular)
                {
                    o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                    o.normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject));
                    
                }
                o.pos = UnityObjectToClipPos(v.vertex); // MODIFIED
                return o;
			}

			// fragment function
			float4 frag(vertexOutput i) : COLOR
			{
                if (_UseSpecular)
                {
                    // Vectors
                    float3 normalDirection = i.normalDir;
                    float atten = 1.0;

                    // Lighting
                    float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                    float3 diffuseReflection = atten * _LightColor0.xyz * max(0.0, dot(normalDirection, lightDirection));

                    // Specular Direction
                    float3 lightReflectDirection = reflect(-lightDirection, normalDirection);
                    float3 viewDirection = normalize(float3(float4(_WorldSpaceCameraPos.xyz, 1.0) - i.posWorld.xyz));

                    float3 lightSeeDirection = max(0.0,dot(lightReflectDirection, viewDirection));
                    float3 shininessPower = pow(lightSeeDirection, _Shininess);

                    float3 specularReflection = atten * _SpecColor.rgb * shininessPower;
                    float3 lightFinal = diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT;
                
                    return float4(lightFinal * _Color.rgb, 1.0);
                }
                else
                {
                    return i.col;
                }

			}
			ENDCG
        }
    }
    FallBack "Diffuse"
}