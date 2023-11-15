
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Rendering;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace net.narazaka.vrchat.render_texture_2d
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class RenderTexture2DAsync : UdonSharpBehaviour
    {
        [SerializeField]
        public Texture SourceTexture;
        [SerializeField]
        [Tooltip("Same size as Source Texture / Recommend: sRGB=OFF")]
        public Texture2D Texture;
        [SerializeField]
        int PixelLength = 1;
        [SerializeField]
        public int MipIndex;
        [SerializeField]
        UdonBehaviour Callback;
        
        public void Render()
        {
            VRCAsyncGPUReadback.Request(SourceTexture, MipIndex, (IUdonEventReceiver)this);
        }

        public override void OnAsyncGpuReadbackComplete(VRCAsyncGPUReadbackRequest request)
        {
            var data = new byte[SourceTexture.width * SourceTexture.height * PixelLength];
            request.TryGetData(data);
            Texture.LoadRawTextureData(data);
            Texture.Apply(false);
            if (Callback != null)
            {
                Callback.SendCustomEvent(nameof(RenderTexture2DCallback.OnRendered));
            }
        }
    }
}
