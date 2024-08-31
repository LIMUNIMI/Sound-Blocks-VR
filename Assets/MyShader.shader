Shader "JazzBACH/OverdrawShader"{
 
    Properties{
        _Tex("Texture", 2D) = "white" {}
    }
   
    SubShader{
       
        Ztest Always
        Blend SrcAlpha OneMinusSrcAlpha
       
        pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct input{
                float4 vertex : POSITION;
                float4 texcoord : TEXCOORD0;
            };
 
            struct output{
                float4 vertex : SV_POSITION;
                float4 texcoord : TEXCOORD0;
            };
 
            uniform sampler2D _Tex;
 
            // ------------------------------------------------------OWN METHODS
           
            fixed4 _GetTexture(output o){
                return tex2D(_Tex, o.texcoord);
            }
 
            // ---------------------------------------------------SHADER METHODS
           
            output vert(input i){
                output o;
                o.vertex = UnityObjectToClipPos(i.vertex);
                o.texcoord = i.texcoord;
 
                return o;
            }
 
            fixed4 frag(output o) : SV_TARGET{
                //return _GetTexture(o);
                return _GetTexture(o);
            }
            ENDCG
        }
    }
}
