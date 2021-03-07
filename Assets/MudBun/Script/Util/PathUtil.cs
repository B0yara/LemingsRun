/*****************************************************************************/
/*
  Project   - MudBun
  Publisher - Long Bunny Labs
              http://LongBunnyLabs.com
  Author    - Ming-Lun "Allen" Chou
              http://AllenChou.net
*/
/******************************************************************************/

namespace MudBun
{
  public class PathUtil
  {
    #if MUDBUN_FREE
    public static string ResourceRoot => "MudBunFree/Resources";
    #else
    public static string ResourceRoot => "MudBun/Resources";
    #endif

    public static string ComputeResourceFolder => "Compute";
    public static string RenderResourceFolder => "Render";
    public static string TextureResourceFolder => "Textures";

    public static string GetRenderPipelineFull(MudRendererBase.RenderPipelineEnum renderPipeline)
    {
      switch (renderPipeline)
      {
        case MudRendererBase.RenderPipelineEnum.BuiltIn:
          return "Built-In RP";
        case MudRendererBase.RenderPipelineEnum.URP:
          return "URP";
        case MudRendererBase.RenderPipelineEnum.HDRP:
          return "HDRP";
      }

      return "";
    }
    public static string RenderPipelineFull => GetRenderPipelineFull(MudRendererBase.RenderPipeline);

    public static string GetRenderPipelinePacked(MudRendererBase.RenderPipelineEnum renderPipeline)
    {
      switch (renderPipeline)
      {
        case MudRendererBase.RenderPipelineEnum.BuiltIn:
          return "BuiltInRP";
        case MudRendererBase.RenderPipelineEnum.URP:
          return "URP";
        case MudRendererBase.RenderPipelineEnum.HDRP:
          return "HDRP";
      }
      return "UNKNOWN";
    }
    public static string RenderPipelinePacked => GetRenderPipelinePacked(MudRendererBase.RenderPipeline);

    public static string VoxelGen => $"{ComputeResourceFolder}/VoxelGen";
    public static string MarchingCubes => $"{ComputeResourceFolder}/MarchingCubes";
    public static string DualMeshing => $"{ComputeResourceFolder}/DualMeshing";
    public static string SurfaceNets => $"{ComputeResourceFolder}/SurfaceNets";
    public static string DualContouring => $"{ComputeResourceFolder}/DualContouring";
    public static string NoiseCache => $"{ComputeResourceFolder}/NoiseCache";
    public static string MeshLock => $"{ComputeResourceFolder}/MeshLock";

    public static string GetDefaultMeshSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline) { return $"{RenderResourceFolder}/{GetRenderPipelineFull(renderPipeline)}/Default Mud Mesh Single-Textured ({GetRenderPipelineFull(renderPipeline)})"; }
    public static string GetDefaultSplatSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline) { return $"{RenderResourceFolder}/{GetRenderPipelineFull(renderPipeline)}/Default Mud Splat Single-Textured ({GetRenderPipelineFull(renderPipeline)})"; }
    public static string GetDefaultMeshMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline) { return $"{RenderResourceFolder}/{GetRenderPipelineFull(renderPipeline)}/Default Mud Mesh Multi-Textured ({GetRenderPipelineFull(renderPipeline)})"; }
    public static string GetDefaultSplatMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline) { return $"{RenderResourceFolder}/{GetRenderPipelineFull(renderPipeline)}/Default Mud Splat Multi-Textured ({GetRenderPipelineFull(renderPipeline)})"; }
    public static string GetDefaultLockedMeshMaterial(MudRendererBase.RenderPipelineEnum renderPipeline) { return $"{RenderResourceFolder}/{GetRenderPipelineFull(renderPipeline)}/Default Mud Locked Mesh ({GetRenderPipelineFull(renderPipeline)})"; }

    public static string DefaultMeshSingleTexturedMaterial => $"{RenderResourceFolder}/{RenderPipelineFull}/Default Mud Mesh Single-Textured ({RenderPipelineFull})";
    public static string DefaultSplatSingleTexturedMaterial => $"{RenderResourceFolder}/{RenderPipelineFull}/Default Mud Splat Single-Textured ({RenderPipelineFull})";
    public static string DefaultMeshMultiTexturedMaterial => $"{RenderResourceFolder}/{RenderPipelineFull}/Default Mud Mesh Multi-Textured ({RenderPipelineFull})";
    public static string DefaultSplatMultiTexturedMaterial => $"{RenderResourceFolder}/{RenderPipelineFull}/Default Mud Splat Multi-Textured ({RenderPipelineFull})";
    public static string DefaultLockedMeshMaterial => $"{RenderResourceFolder}/{RenderPipelineFull}/Default Mud Locked Mesh ({RenderPipelineFull})";

    public static string BlueNoiseTexture => $"{TextureResourceFolder}/blue-noise-256x256";
  }
}

