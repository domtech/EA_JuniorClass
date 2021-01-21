using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FlatKitDepthNormals : ScriptableRendererFeature
{
    class DepthNormalsPass : ScriptableRenderPass
    {
        readonly int kDepthBufferBits = 32;
        private RenderTargetHandle DepthAttachmentHandle { get; set; }
        private RenderTextureDescriptor Descriptor { get; set; }

        private Material depthNormalsMaterial = null;
        private FilteringSettings m_FilteringSettings;
        readonly string _mProfilerTag = "FlatKit Depth Normals Pass";
        readonly ShaderTagId m_ShaderTagId = new ShaderTagId("DepthOnly");

        public DepthNormalsPass(RenderQueueRange renderQueueRange, LayerMask layerMask, Material material)
        {
            m_FilteringSettings = new FilteringSettings(renderQueueRange, layerMask);
            depthNormalsMaterial = material;
        }

        public void Setup(RenderTextureDescriptor baseDescriptor, RenderTargetHandle depthAttachmentHandle)
        {
            this.DepthAttachmentHandle = depthAttachmentHandle;
            baseDescriptor.colorFormat = RenderTextureFormat.ARGB32;
            baseDescriptor.depthBufferBits = kDepthBufferBits;
            Descriptor = baseDescriptor;
        }

        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            cmd.GetTemporaryRT(DepthAttachmentHandle.id, Descriptor, FilterMode.Point);
            ConfigureTarget(DepthAttachmentHandle.Identifier());
            ConfigureClear(ClearFlag.All, Color.black);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get(_mProfilerTag);

            using (new ProfilingScope(cmd, new ProfilingSampler(_mProfilerTag)))
            {
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                var sortFlags = renderingData.cameraData.defaultOpaqueSortFlags;
                var drawSettings = CreateDrawingSettings(m_ShaderTagId, ref renderingData, sortFlags);
                drawSettings.perObjectData = PerObjectData.None;


                ref CameraData cameraData = ref renderingData.cameraData;
                Camera camera = cameraData.camera;
                if (cameraData.isStereoEnabled)
                {
                    context.StartMultiEye(camera);
                }

                drawSettings.overrideMaterial = depthNormalsMaterial;

                context.DrawRenderers(renderingData.cullResults, ref drawSettings,
                    ref m_FilteringSettings);

                cmd.SetGlobalTexture("_CameraDepthNormalsTexture", DepthAttachmentHandle.id);
            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            if (DepthAttachmentHandle == RenderTargetHandle.CameraTarget) return;
            cmd.ReleaseTemporaryRT(DepthAttachmentHandle.id);
            DepthAttachmentHandle = RenderTargetHandle.CameraTarget;
        }
    }

    DepthNormalsPass _depthNormalsPass;
    RenderTargetHandle _depthNormalsTexture;
    Material _depthNormalsMaterial;

    public FlatKitDepthNormals(RenderTargetHandle depthNormalsTexture)
    {
        _depthNormalsTexture = depthNormalsTexture;
    }

    public override void Create()
    {
        _depthNormalsMaterial = CoreUtils.CreateEngineMaterial("Hidden/Internal-DepthNormalsTexture");
        _depthNormalsPass = new DepthNormalsPass(RenderQueueRange.opaque, -1, _depthNormalsMaterial)
        {
            renderPassEvent = RenderPassEvent.AfterRenderingPrePasses
        };
        _depthNormalsTexture.Init("_CameraDepthNormalsTexture");
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        _depthNormalsPass.Setup(renderingData.cameraData.cameraTargetDescriptor, _depthNormalsTexture);
        renderer.EnqueuePass(_depthNormalsPass);
    }
}
