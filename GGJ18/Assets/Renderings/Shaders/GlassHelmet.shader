// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3423,x:33577,y:32794,varname:node_3423,prsc:2|emission-9887-OUT,alpha-9814-OUT;n:type:ShaderForge.SFN_Slider,id:2482,x:32795,y:33212,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_2482,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5384616,max:1;n:type:ShaderForge.SFN_Tex2d,id:2171,x:32411,y:32811,ptovrint:False,ptlb:BRDF,ptin:_BRDF,varname:node_2171,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4376-OUT;n:type:ShaderForge.SFN_NormalVector,id:7596,x:31499,y:32413,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:4717,x:31679,y:32477,varname:node_4717,prsc:2,dt:0|A-7596-OUT,B-7136-OUT;n:type:ShaderForge.SFN_LightVector,id:2176,x:31192,y:32566,varname:node_2176,prsc:2;n:type:ShaderForge.SFN_Append,id:4376,x:32160,y:32797,varname:node_4376,prsc:2|A-9431-OUT,B-9822-OUT;n:type:ShaderForge.SFN_Fresnel,id:9822,x:31946,y:32843,varname:node_9822,prsc:2|EXP-6639-OUT;n:type:ShaderForge.SFN_Clamp01,id:8353,x:31863,y:32517,varname:node_8353,prsc:2|IN-4717-OUT;n:type:ShaderForge.SFN_OneMinus,id:9431,x:31946,y:32710,varname:node_9431,prsc:2|IN-8353-OUT;n:type:ShaderForge.SFN_ViewVector,id:1316,x:31192,y:32686,varname:node_1316,prsc:2;n:type:ShaderForge.SFN_Add,id:9488,x:31357,y:32627,varname:node_9488,prsc:2|A-2176-OUT,B-1316-OUT;n:type:ShaderForge.SFN_Normalize,id:7136,x:31499,y:32596,varname:node_7136,prsc:2|IN-9488-OUT;n:type:ShaderForge.SFN_Power,id:9887,x:32768,y:32798,varname:node_9887,prsc:2|VAL-2171-RGB,EXP-4299-OUT;n:type:ShaderForge.SFN_Vector1,id:4299,x:32547,y:32890,varname:node_4299,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:6639,x:31779,y:32865,varname:node_6639,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Length,id:2412,x:32941,y:32945,varname:node_2412,prsc:2|IN-2171-RGB;n:type:ShaderForge.SFN_Max,id:9814,x:33338,y:33064,varname:node_9814,prsc:2|A-5697-OUT,B-2482-OUT;n:type:ShaderForge.SFN_Power,id:5697,x:33135,y:32992,varname:node_5697,prsc:2|VAL-2412-OUT,EXP-4073-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4073,x:32941,y:33087,ptovrint:False,ptlb:OpacMinPower,ptin:_OpacMinPower,varname:node_4073,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;proporder:2482-2171-4073;pass:END;sub:END;*/

Shader "PPPPP/GlassHelmet" {
    Properties {
        _Alpha ("Alpha", Range(0, 1)) = 0.5384616
        _BRDF ("BRDF", 2D) = "white" {}
        _OpacMinPower ("OpacMinPower", Float ) = 4
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float _Alpha;
            uniform sampler2D _BRDF; uniform float4 _BRDF_ST;
            uniform float _OpacMinPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float2 node_4376 = float2((1.0 - saturate(dot(normalDirection,normalize((lightDirection+viewDirection))))),pow(1.0-max(0,dot(normalDirection, viewDirection)),0.5));
                float4 _BRDF_var = tex2D(_BRDF,TRANSFORM_TEX(node_4376, _BRDF));
                float3 emissive = pow(_BRDF_var.rgb,2.0);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,max(pow(length(_BRDF_var.rgb),_OpacMinPower),_Alpha));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
