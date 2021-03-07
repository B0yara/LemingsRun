/*****************************************************************************/
/*
  Project   - MudBun
  Publisher - Long Bunny Labs
              http://LongBunnyLabs.com
  Author    - Ming-Lun "Allen" Chou
              http://AllenChou.net
*/
/******************************************************************************/

using UnityEngine;

namespace MudBun
{
  public class ResourcesUtil
  {
    public static ComputeShader VoxelGen
    {
      get
      {
        var compute = Resources.Load<ComputeShader>(PathUtil.VoxelGen);
        if (compute == null)
          Debug.LogError($"MudBun: Compute shader \"{PathUtil.ResourceRoot}/{PathUtil.VoxelGen}.compute\" not found.");
        return compute;
      }
    }

    public static ComputeShader MarchingCubes
    {
      get
      {
        var compute = Resources.Load<ComputeShader>(PathUtil.MarchingCubes);
        if (compute == null)
          Debug.LogError($"MudBun: Compute shader \"{PathUtil.ResourceRoot}/{PathUtil.MarchingCubes}.compute\" not found.");
        return compute;
      }
    }

    public static ComputeShader DualMeshing
    {
      get
      {
        var compute = Resources.Load<ComputeShader>(PathUtil.DualMeshing);
        if (compute == null)
          Debug.LogError($"MudBun: Compute shader \"{PathUtil.ResourceRoot}/{PathUtil.DualMeshing}.compute\" not found.");
        return compute;
      }
    }

    public static ComputeShader SurfaceNets
    {
      get
      {
        var compute = Resources.Load<ComputeShader>(PathUtil.SurfaceNets);
        if (compute == null)
          Debug.LogError($"MudBun: Compute shader \"{PathUtil.ResourceRoot}/{PathUtil.SurfaceNets}.compute\" not found.");
        return compute;
      }
    }

    public static ComputeShader DualContouring
    {
      get
      {
        var compute = Resources.Load<ComputeShader>(PathUtil.DualContouring);
        if (compute == null)
          Debug.LogError($"MudBun: Compute shader \"{PathUtil.ResourceRoot}/{PathUtil.DualContouring}.compute\" not found.");
        return compute;
      }
    }

    public static ComputeShader NoiseCache
    {
      get
      {
        var compute = Resources.Load<ComputeShader>(PathUtil.NoiseCache);
        if (compute == null)
          Debug.LogError($"MudBun: CCompute shader \"{PathUtil.ResourceRoot}/{PathUtil.NoiseCache}.compute\" not found.");
        return compute;
      }
    }

    public static ComputeShader MeshLock
    {
      get
      {
        var compute = Resources.Load<ComputeShader>(PathUtil.MeshLock);
        if (compute == null)
          Debug.LogError($"MudBun: CCompute shader \"{PathUtil.ResourceRoot}/{PathUtil.MeshLock}.compute\" not found.");
        return compute;
      }
    }

    public static Material DefaultMeshMaterial => DefaultMeshSingleTexturedMaterial;
    public static Material DefaultSplatMaterial => DefaultSplatSingleTexturedMaterial;

    public static Material GetDefaultMeshSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline)
    {
      string path = PathUtil.GetDefaultMeshSingleTexturedMaterial(renderPipeline);
      var mat = Resources.Load<Material>(path);
      return mat;
    }
    public static Material DefaultMeshSingleTexturedMaterial
    {
      get
      {
        var mat = Resources.Load<Material>(PathUtil.DefaultMeshSingleTexturedMaterial);
        if (mat == null)
          Debug.LogError($"MudBun: Cannot load default {PathUtil.RenderPipelineFull} single-textured mesh renderer material at \"{PathUtil.ResourceRoot}/{PathUtil.DefaultMeshSingleTexturedMaterial}.mat\". Did you forget to import \"{PathUtil.ResourceRoot}/{PathUtil.RenderPipelineFull}\"?");
        return mat;
      }
    }
    public static bool IsDefaultMeshSingleTexturedMaterial(Material material)
    {
      if (material == null)
        return false;
      if (material == GetDefaultMeshSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum.BuiltIn))
        return true;
      if (material == GetDefaultMeshSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum.URP))
        return true;
      if (material == GetDefaultMeshSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum.HDRP))
        return true;
      return false;
    }

    public static Material GetDefaultSplatSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline)
    {
      string path = PathUtil.GetDefaultSplatSingleTexturedMaterial(renderPipeline);
      var mat = Resources.Load<Material>(path);
      return mat;
    }
    public static Material DefaultSplatSingleTexturedMaterial
    {
      get
      {
        var mat = Resources.Load<Material>(PathUtil.DefaultSplatSingleTexturedMaterial);
        if (mat == null)
          Debug.LogError($"MudBun: Cannot load default {PathUtil.RenderPipelineFull} single-textured splat renderer material at \"{PathUtil.ResourceRoot}/{PathUtil.DefaultSplatSingleTexturedMaterial}.mat\". Did you forget to import \"{PathUtil.ResourceRoot}/{PathUtil.RenderPipelineFull}\"?");
        return mat;
      }
    }
    public static bool IsDefaultSplatSingleTexturedMaterial(Material material)
    {
      if (material == GetDefaultSplatSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum.BuiltIn))
        return true;
      if (material == GetDefaultSplatSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum.URP))
        return true;
      if (material == GetDefaultSplatSingleTexturedMaterial(MudRendererBase.RenderPipelineEnum.HDRP))
        return true;
      return false;
    }

    public static Material GetDefaultMeshMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline)
    {
      string path = PathUtil.GetDefaultMeshMultiTexturedMaterial(renderPipeline);
      var mat = Resources.Load<Material>(path);
      return mat;
    }
    public static Material DefaultMeshMultiTexturedMaterial
    {
      get
      {
        var mat = Resources.Load<Material>(PathUtil.DefaultMeshMultiTexturedMaterial);
        if (mat == null)
          Debug.LogError($"MudBun: Cannot load default {PathUtil.RenderPipelineFull} multi-textured mesh renderer material at \"{PathUtil.ResourceRoot}/{PathUtil.DefaultMeshMultiTexturedMaterial}.mat\". Did you forget to import \"{PathUtil.ResourceRoot}/{PathUtil.RenderPipelineFull}\"?");
        return mat;
      }
    }
    public static bool IsDefaultMeshMultiTexturedMaterial(Material material)
    {
      if (material == GetDefaultMeshMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum.BuiltIn))
        return true;
      if (material == GetDefaultMeshMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum.URP))
        return true;
      if (material == GetDefaultMeshMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum.HDRP))
        return true;
      return false;
    }

    public static Material GetDefaultSplatMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum renderPipeline)
    {
      string path = PathUtil.GetDefaultSplatMultiTexturedMaterial(renderPipeline);
      var mat = Resources.Load<Material>(path);
      return mat;
    }
    public static Material DefaultSplatMultiTexturedMaterial
    {
      get
      {
        var mat = Resources.Load<Material>(PathUtil.DefaultSplatMultiTexturedMaterial);
        if (mat == null)
          Debug.LogError($"MudBun: Cannot load default {PathUtil.RenderPipelineFull} multi-textured splat renderer material at \"{PathUtil.ResourceRoot}/{PathUtil.DefaultSplatMultiTexturedMaterial}.mat\". Did you forget to import \"{PathUtil.ResourceRoot}/{PathUtil.RenderPipelineFull}\"?");
        return mat;
      }
    }
    public static bool IsDefaultSplatMultiTexturedMaterial(Material material)
    {
      if (material == GetDefaultSplatMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum.BuiltIn))
        return true;
      if (material == GetDefaultSplatMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum.URP))
        return true;
      if (material == GetDefaultSplatMultiTexturedMaterial(MudRendererBase.RenderPipelineEnum.HDRP))
        return true;
      return false;
    }

    public static Material GetDefaultLockedMeshMaterial(MudRendererBase.RenderPipelineEnum renderPipeline)
    {
      string path = PathUtil.GetDefaultLockedMeshMaterial(renderPipeline);
      var mat = Resources.Load<Material>(path);
      return mat;
    }
    public static Material DefaultLockedMeshMaterial
    {
      get
      {
        var mat = Resources.Load<Material>(PathUtil.DefaultLockedMeshMaterial);
        if (mat == null)
          Debug.LogError($"MudBun: Cannot load default {PathUtil.RenderPipelineFull} locked mesh material at \"{PathUtil.ResourceRoot}/{PathUtil.DefaultLockedMeshMaterial}.mat\". Did you forget to import \"{PathUtil.ResourceRoot}/{PathUtil.RenderPipelineFull}\"?");
        return mat;
      }
    }
    public static bool IsDefaultLockedMeshMaterial(Material material)
    {
      if (material == GetDefaultLockedMeshMaterial(MudRendererBase.RenderPipelineEnum.BuiltIn))
        return true;
      if (material == GetDefaultLockedMeshMaterial(MudRendererBase.RenderPipelineEnum.URP))
        return true;
      if (material == GetDefaultLockedMeshMaterial(MudRendererBase.RenderPipelineEnum.HDRP))
        return true;
      return false;
    }

    public static MudRendererBase.RenderPipelineEnum DetermineRenderPipeline(Material material)
    {
      var aRenderPipeline = 
        new MudRendererBase.RenderPipelineEnum[]
        {
          MudRendererBase.RenderPipelineEnum.BuiltIn, 
          MudRendererBase.RenderPipelineEnum.URP, 
          MudRendererBase.RenderPipelineEnum.HDRP, 
        };
      foreach (var renderPipeline in aRenderPipeline)
      {
        if (material == GetDefaultMeshSingleTexturedMaterial(renderPipeline))
          return renderPipeline;

        if (material == GetDefaultSplatSingleTexturedMaterial(renderPipeline))
          return renderPipeline;

        if (material == GetDefaultMeshMultiTexturedMaterial(renderPipeline))
          return renderPipeline;

        if (material == GetDefaultSplatMultiTexturedMaterial(renderPipeline))
          return renderPipeline;

        if (material == GetDefaultLockedMeshMaterial(renderPipeline))
          return renderPipeline;
      }

      return MudRendererBase.RenderPipelineEnum.Invalid;
    }

    public static void ValidateDefaultMaterial(ref Material material)
    {
      if (material == null)
        return;

      var matRenderPipeline = DetermineRenderPipeline(material);
      if (matRenderPipeline == MudRendererBase.RenderPipelineEnum.Invalid)
        return;

      if (matRenderPipeline == MudRendererBase.RenderPipeline)
        return;

      var prevMaterial = material;
      if (IsDefaultMeshSingleTexturedMaterial(material))
        material = DefaultMeshSingleTexturedMaterial;
      else if (IsDefaultSplatSingleTexturedMaterial(material))
        material = DefaultSplatSingleTexturedMaterial;
      else if (IsDefaultMeshMultiTexturedMaterial(material))
        material = DefaultMeshMultiTexturedMaterial;
      else if (IsDefaultSplatMultiTexturedMaterial(material))
        material = DefaultSplatMultiTexturedMaterial;
      else if (IsDefaultLockedMeshMaterial(material))
        material = DefaultLockedMeshMaterial;

      if (prevMaterial != material)
        Debug.LogWarning($"MudBun: Automatically upgraded default renderer materials from {PathUtil.GetRenderPipelineFull(matRenderPipeline)} to {PathUtil.RenderPipelineFull}.");
    }

    public static Texture2D BlueNoiseTetxture
    {
      get
      {
        var texture = Resources.Load<Texture2D>(PathUtil.BlueNoiseTexture);
        if (texture == null)
          Debug.LogError($"MudBun: Texture \"{PathUtil.ResourceRoot}/{PathUtil.BlueNoiseTexture}.png\" not found.");
        return texture;
      }
    }
  }
}

