Shader "lcl/screenEffect/waterWave"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _distanceFactor;
            float _totalFactor;
            float _timeFactor;
            float _waveWidth;
            float _curWaveDis;
            float4 _startPos;

            fixed4 frag (v2f i) : SV_Target
            {
                
                
                #if UNITY_UV_STARTS_AT_TOP
                    if (_MainTex_TexelSize.y < 0)
                    _startPos.y = 1 - _startPos.y;
                #endif
               
                float2 dv = _startPos.xy - i.uv;
               
                dv = dv * float2(_ScreenParams.x / _ScreenParams.y, 1);
               
                float dis = sqrt(dv.x * dv.x + dv.y * dv.y);
               
                float sinFactor = sin(dis * _distanceFactor + _Time.y * _timeFactor) * _totalFactor * 0.01;
               
                float discardFactor = clamp(_waveWidth - abs(_curWaveDis - dis), 0, 1) / _waveWidth;
               
                float2 dv1 = normalize(dv);
                
                float2 offset = dv1  * sinFactor * discardFactor;
                
                float2 uv = offset + i.uv;
                return tex2D(_MainTex, uv);	

            }
            ENDCG
        }
    }
}
