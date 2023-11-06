Shader "Unlit/Two Sided Unlit Shader"
{
    Properties
    {    
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        LOD 100
        Color [_Color]

        Pass
        {
            Cull off  
        }
    }
}
