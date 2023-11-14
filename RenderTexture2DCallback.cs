using System.Collections;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;

namespace net.narazaka.vrchat.render_texture_2d
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public abstract class RenderTexture2DCallback : MonoBehaviour
    {
        public abstract void OnRendered();
    }
}
