Shader "Custom/Substract"{
        Properties
    {
       _MainTex ("Base (RGB)", 2D) = "white" {}
       _Mask ("Culling Mask", 2D) = "white" {}
       _Details ("Details", 2D) = "white" {}
       _Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
    }
    SubShader
    {
       Tags {"Queue"="Transparent"}
       Lighting Off
       ZWrite Off
       Blend SrcAlpha OneMinusSrcAlpha
       AlphaTest GEqual [_Cutoff]
       Pass
       {
          SetTexture [_Mask] {combine texture}
          SetTexture [_MainTex] {combine texture, previous}
       }
 
       CGPROGRAM
 
 #pragma surface surf Lambert alpha
  
 sampler2D _MainTex;
 sampler2D _Details;
  
 struct Input {
     float2 uv_MainTex;
     float2 uv_Details;
 };
  
 void surf (Input IN, inout SurfaceOutput o) {
     fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
     fixed4 details = tex2D (_Details, IN.uv_Details);
     o.Albedo = c.rgb * details.rgb;
    // How can I make it 0 out of details texture bounds?
     o.Alpha = details.a;
 }
 ENDCG
    
    }
 }