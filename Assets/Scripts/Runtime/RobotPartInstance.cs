using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public sealed class RobotPartInstance : MonoBehaviour
    {
        private readonly List<Renderer> _renderers = new();
        
        public void Init(RobotPartAsset asset)
        {
            GetComponentsInChildren(_renderers);
        }

        public void SetColor(Color color)
        {
            foreach (var r in _renderers)
                r.material.color = color;
        }
    }
}