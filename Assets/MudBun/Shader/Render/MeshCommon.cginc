/******************************************************************************/
/*
  Project   - MudBun
  Publisher - Long Bunny Labs
              http://LongBunnyLabs.com
  Author    - Ming-Lun "Allen" Chou
              http://AllenChou.net
*/
/******************************************************************************/

#ifndef MUDBUN_MESH_COMMON
#define MUDBUN_MESH_COMMON

#ifdef MUDBUN_VALID

#include "../BrushDefs.cginc"
#include "../GenPointDefs.cginc"
#include "../Math/Codec.cginc"
#include "../Math/Vector.cginc"
#include "../NormalDefs.cginc"
#include "../RenderModeDefs.cginc"

#endif

void mudbun_mesh_vert
(
  uint id, 
  out float4 vertexWs, 
  out float3 vertexLs, 
  out float3 normalWs, 
  out float3 normalLs, 
  out float4 color, 
  out float hash
)
{
#if MUDBUN_VALID

  vertexLs = aGenPoint[id].posNorm.xyz;
  vertexWs = mul(localToWorld, float4(vertexLs, 1.0f));
  normalLs = unpack_normal(aGenPoint[id].posNorm.w);

  if (should_quantize_normal())
    normalLs = quantize_normal(normalLs);

  normalWs = mul(localToWorld, float4(normalLs, 0.0f)).xyz;

  color = unpack_rgba(aGenPoint[id].material.color);

  hash = aGenPoint[id].material.hash;

#endif
}

void mudbun_mesh_vert
(
  uint id, 
  out float4 vertexWs, 
  out float3 vertexLs, 
  out float3 normalWs, 
  out float3 normalLs, 
  out float4 color, 
  out float4 emissionHash,
  out float2 metallicSmoothness, 
  out float4 intWeight
)
{
#if MUDBUN_VALID

  mudbun_mesh_vert(id, vertexWs, vertexLs, normalWs, normalLs, color, emissionHash.a);

  emissionHash.rgb = unpack_rgba(aGenPoint[id].material.emissionTightness).rgb;
  metallicSmoothness = unpack_saturated(aGenPoint[id].material.metallicSmoothness);
  intWeight = unpack_rgba(aGenPoint[id].material.intWeight);

#endif
}

#endif
