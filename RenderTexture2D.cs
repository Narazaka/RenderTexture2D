
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace net.narazaka.vrchat.render_texture_2d
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [RequireComponent(typeof(Camera))]
    public class RenderTexture2D : UdonSharpBehaviour
    {
        [SerializeField]
        [Tooltip("Same size as Camera Render Texture / Recommend: sRGB=OFF")]
        public Texture2D Texture;
        [SerializeField]
        bool RecalculateMipMaps;
        [SerializeField]
        UdonBehaviour Callback;

        Camera Camera;
        bool ToRender;

        void Start()
        {
            Camera = GetComponent<Camera>();
        }

        public void Render()
        {
            ToRender = true;
        }

        void OnPostRender()
        {
            if (ToRender)
            {

                ToRender = false;
                Texture.ReadPixels(new Rect(0, 0, Camera.activeTexture.width, Camera.activeTexture.height), 0, 0, RecalculateMipMaps);
                Texture.Apply(false);
                if (Callback != null)
                {
                    Callback.SendCustomEvent(nameof(RenderTexture2DCallback.OnRendered));
                }
            }
        }
    }
}
