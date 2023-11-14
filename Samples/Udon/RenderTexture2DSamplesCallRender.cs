
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace net.narazaka.vrchat.render_texture_2d.samples
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class RenderTexture2DSamplesCallRender : UdonSharpBehaviour
    {
        [SerializeField]
        RenderTexture2D RenderTexture2D;

        public override void Interact()
        {
            RenderTexture2D.Render();
        }
    }
}
