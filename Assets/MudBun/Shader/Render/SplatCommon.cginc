/******************************************************************************/
/*
  Project   - MudBun
  Publisher - Long Bunny Labs
              http://LongBunnyLabs.com
  Author    - Ming-Lun "Allen" Chou
              http://AllenChou.net
*/
/******************************************************************************/

#ifndef MUDBUN_SPLAT_COMMON
#define MUDBUN_SPLAT_COMMON

#ifdef MUDBUN_VALID

#include "../BrushDefs.cginc"
#include "../GenPointDefs.cginc"
#include "../Math/Codec.cginc"
#include "../Math/Vector.cginc"
#include "../Math/Quaternion.cginc"
#include "../MeshingModeDefs.cginc"
#include "../Noise/ClassicNoise3D.cginc"
#include "../Noise/RandomNoise.cginc"
#include "../NormalDefs.cginc"
#include "../RenderModeDefs.cginc"

#ifdef MUDBUN_QUAD_SPLATS
static const float2 splatVertOffsetLsTableQuad[6] = 
{
  float2(-0.5f, -0.5f), 
  float2( 0.5f,  0.5f), 
  float2( 0.5f, -0.5f), 
  float2(-0.5f, -0.5f), 
  float2(-0.5f,  0.5f), 
  float2( 0.5f,  0.5f), 
};
#else
static const float2 splatVertOffsetLsTableTri[3] = 
{
  float2(-0.866f, -0.5f), 
  float2( 0.0f  ,  1.0f), 
  float2( 0.866f, -0.5f), 
};
#endif

#endif

void mudbun_splat_vert
(
  uint id, 
  out uint iGenPoint, 
  out float4 vertexWs, 
  out float3 vertexLs, 
  out float3 normalWs, 
  out float3 normalLs, 
  out float3 tangentWs, 
  out float3 tangentLs,
  out float2 tex, 
  out float hash
)
{
#if MUDBUN_VALID

  iGenPoint = id;

  uint iOffset = 0;
  #ifdef MUDBUN_QUAD_SPLATS
    iGenPoint = id / 6;
    iOffset = id % 6;
  #else
    iGenPoint = id / 3;
    iOffset = id % 3;
  #endif

  switch (meshingMode)
  {
    case kMeshingModeSurfaceNets:
    case kMeshingModeDualContouring:
      iGenPoint *= 6;
      break;
  }

  normalLs = unpack_normal(aGenPoint[iGenPoint].posNorm.w);

  float normalShift = splatNormalShift;
  if (splatNormalShiftJitter > kEpsilon)
  {
    float noiseRes = cnoise(3 * splatJitterNoisiness + aGenPoint[iGenPoint].posNorm.xyz  * splatJitterNoisiness / voxelSize);
    normalShift = max(0.0f, normalShift * (1.0f + 2.0f * (noiseRes - 0.5f) * splatNormalShiftJitter));
  }

  float3 centerLs = aGenPoint[iGenPoint].posNorm.xyz + normalShift * normalLs;
  float3 normalJitter = float3(0.01f * (rand(centerLs) * 0.6f + 0.4f), 0.0f, 0.0f);

  tangentLs = normalize(find_ortho_consistent(normalLs + normalJitter));

  float3 rawCenterLs = centerLs;
  if (splatPositionJitter > kEpsilon)
  {
    float noiseRes = cnoise(centerLs * splatJitterNoisiness / voxelSize);
    float angle = noiseRes * kTwoPi;
    float4 q = quat_axis_angle(normalLs, angle);
    float3 jitterDirLs = quat_rot(q, tangentLs);
    centerLs += jitterDirLs * noiseRes * splatPositionJitter * voxelSize;
  }
  float3 centerWs = mul(localToWorld, float4(centerLs, 1.0f)).xyz;

  normalWs = mul(localToWorldIt, float4(normalLs, 0.0f)).xyz;
  tangentWs = mul(localToWorldIt, float4(tangentLs, 0.0f)).xyz;

  //float3 camDir = normalize(UNITY_MATRIX_V._m20_m21_m22);
  float3 camDir = normalize(_WorldSpaceCameraPos - centerWs);

  float3 geomNormal = normalize(lerp(normalWs, camDir, splatCameraFacing));
  float3 geomTangent = normalize(find_ortho_consistent(geomNormal + normalJitter));
  float3 geomTangent2 = normalize(cross(geomTangent, geomNormal));

  if (splatRotationJitter > kEpsilon)
  {
    float noiseRes = cnoise(splatJitterNoisiness + rawCenterLs * splatJitterNoisiness / voxelSize);
    float angle = noiseRes * splatRotationJitter * kTwoPi;
    float4 q = quat_axis_angle(geomNormal, angle);
    geomTangent = quat_rot(q, geomTangent);
    geomTangent2 = quat_rot(q, geomTangent2);
  }

  if (should_quantize_normal())
  {
    normalLs = quantize_normal(normalLs);
    normalWs = mul(localToWorldIt, float4(normalLs, 0.0f)).xyz;
  }


  #ifdef MUDBUN_QUAD_SPLATS
    tex = splatVertOffsetLsTableQuad[iOffset];
  #else
    tex = splatVertOffsetLsTableTri[iOffset];
  #endif

  float sizeMult = aGenPoint[iGenPoint].material.size;
  if (splatSizeJitter > kEpsilon)
  {
    float noiseRes = cnoise(2 * splatJitterNoisiness + rawCenterLs * splatJitterNoisiness / voxelSize);
    sizeMult = max(0.0f, sizeMult * (1.0f + 2.0f * (noiseRes - 0.5f) * splatSizeJitter));
  }

  float2 splatVertOffsetLs = splatSize * sizeMult * tex; 
  float3 splatVertOffsetWs = splatVertOffsetLs.x * localToWorldScale.xyz * geomTangent + splatVertOffsetLs.y * localToWorldScale.xyz * geomTangent2;
  vertexWs = float4(centerWs + splatVertOffsetWs, 1.0f);
  vertexLs = mul(worldToLocal, vertexWs).xyz;

  #ifndef SHADERPASS_SHADOWCASTER
    vertexWs.xyz -= splatScreenSpaceFlattening * project_vec(splatVertOffsetWs, camDir);
  #endif

  hash = aGenPoint[iGenPoint].material.hash;

#endif
}

void mudbun_splat_vert
(
  uint id, 
  out float4 vertexWs, 
  out float3 vertexLs, 
  out float3 normalWs, 
  out float3 normalLs, 
  out float3 tangentWs, 
  out float3 tangentLs, 
  out float4 color, 
  out float4 emissionHash, 
  out float2 metallicSmoothness, 
  out float2 tex, 
  out float4 intWeight
)
{
#ifdef MUDBUN_VALID

  uint iGenPoint = 0;
  mudbun_splat_vert(id, iGenPoint, vertexWs, vertexLs, normalWs, normalLs, tangentWs, tangentLs, tex, emissionHash.a);

  color = unpack_rgba(aGenPoint[iGenPoint].material.color);
  emissionHash.rgb = unpack_rgba(aGenPoint[iGenPoint].material.emissionTightness).rgb;
  metallicSmoothness = unpack_saturated(aGenPoint[iGenPoint].material.metallicSmoothness);
  intWeight = unpack_rgba(aGenPoint[iGenPoint].material.intWeight);

  if (splatColorJitter > kEpsilon)
  {
    float noiseRes = cnoise(3 * splatJitterNoisiness + aGenPoint[iGenPoint].posNorm.xyz * splatJitterNoisiness / voxelSize);
    color.rgb = saturate(color.rgb + splatColorJitter * (noiseRes - 0.5f));
  }

#endif
}

#endif
