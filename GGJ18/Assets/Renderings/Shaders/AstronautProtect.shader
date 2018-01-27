// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3423,x:33065,y:32927,varname:node_3423,prsc:2|emission-4420-OUT;n:type:ShaderForge.SFN_Tex2d,id:6401,x:32408,y:32741,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_6401,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8748-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:405,x:31599,y:32728,varname:node_405,prsc:2;n:type:ShaderForge.SFN_Add,id:1935,x:31790,y:32689,varname:node_1935,prsc:2|A-405-X,B-405-Y;n:type:ShaderForge.SFN_Add,id:9591,x:31790,y:32816,varname:node_9591,prsc:2|A-405-Y,B-405-Z;n:type:ShaderForge.SFN_Append,id:9043,x:31975,y:32750,varname:node_9043,prsc:2|A-1935-OUT,B-9591-OUT;n:type:ShaderForge.SFN_Divide,id:8748,x:32219,y:32770,varname:node_8748,prsc:2|A-9043-OUT,B-790-OUT;n:type:ShaderForge.SFN_ValueProperty,id:790,x:31975,y:32909,ptovrint:False,ptlb:Scaler,ptin:_Scaler,varname:node_790,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_NormalVector,id:9552,x:31620,y:33106,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:9865,x:31975,y:33116,varname:node_9865,prsc:2,dt:0|A-9552-OUT,B-2322-OUT;n:type:ShaderForge.SFN_Power,id:9842,x:32215,y:33157,varname:node_9842,prsc:2|VAL-9865-OUT,EXP-1291-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1291,x:31975,y:33280,ptovrint:False,ptlb:LightPower,ptin:_LightPower,varname:node_1291,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2.1;n:type:ShaderForge.SFN_Color,id:5978,x:32408,y:32920,ptovrint:False,ptlb:LightColor,ptin:_LightColor,varname:node_5978,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_LightVector,id:2322,x:31620,y:33247,varname:node_2322,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:5896,x:32420,y:33157,varname:node_5896,prsc:2|IN-9842-OUT;n:type:ShaderForge.SFN_Multiply,id:3052,x:32624,y:33030,varname:node_3052,prsc:2|A-5978-RGB,B-5896-OUT;n:type:ShaderForge.SFN_Add,id:4420,x:32873,y:33019,varname:node_4420,prsc:2|A-6401-RGB,B-3052-OUT,C-6122-OUT;n:type:ShaderForge.SFN_Dot,id:101,x:32067,y:33495,varname:node_101,prsc:2,dt:0|A-9552-OUT,B-9281-OUT;n:type:ShaderForge.SFN_Power,id:9391,x:32257,y:33518,varname:node_9391,prsc:2|VAL-101-OUT,EXP-4503-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4503,x:32067,y:33669,ptovrint:False,ptlb:ShadePower,ptin:_ShadePower,varname:node_4503,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2.1;n:type:ShaderForge.SFN_Clamp01,id:2020,x:32416,y:33518,varname:node_2020,prsc:2|IN-9391-OUT;n:type:ShaderForge.SFN_Color,id:3581,x:32416,y:33323,ptovrint:False,ptlb:ShadowColor,ptin:_ShadowColor,varname:node_3581,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:6122,x:32620,y:33312,varname:node_6122,prsc:2|A-3581-RGB,B-2020-OUT;n:type:ShaderForge.SFN_Multiply,id:9281,x:31887,y:33518,varname:node_9281,prsc:2|A-2322-OUT,B-1192-OUT;n:type:ShaderForge.SFN_Vector1,id:1192,x:31707,y:33552,varname:node_1192,prsc:2,v1:-1;proporder:6401-790-1291-5978-4503-3581;pass:END;sub:END;*/

Shader "PPPPP/SpaceshipWall" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Scaler ("Scaler", Float ) = 10
        _LightPower ("LightPower", Float ) = 2.1
        _LightColor ("LightColor", Color) = (0.5,0.5,0.5,1)
        _ShadePower ("ShadePower", Float ) = 2.1
        _ShadowColor ("ShadowColor", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Scaler;
            uniform float _LightPower;
            uniform float4 _LightColor;
            uniform float _ShadePower;
            uniform float4 _ShadowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float2 node_8748 = (float2((i.posWorld.r+i.posWorld.g),(i.posWorld.g+i.posWorld.b))/_Scaler);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_8748, _MainTex));
                float3 node_6122 = (_ShadowColor.rgb*saturate(pow(dot(i.normalDir,(lightDirection*(-1.0))),_ShadePower)));
                float3 node_4420 = (_MainTex_var.rgb+(_LightColor.rgb*saturate(pow(dot(i.normalDir,lightDirection),_LightPower)))+node_6122);
                float3 emissive = node_4420;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
