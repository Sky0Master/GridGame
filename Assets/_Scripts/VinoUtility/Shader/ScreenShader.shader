Shader "Unlit/screenEffect"
{

    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PixelNum ("PixelNum", Range(0, 100)) = 10
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _PixelNum;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float2 pixelUV = i.uv * _PixelNum;
                pixelUV = floor(pixelUV) / _PixelNum;
                fixed4 col = tex2D(_MainTex, pixelUV);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                
                //return i.uv.x;
                return col;
            }
            ENDCG
        }
    }
}
