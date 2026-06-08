using UnityEngine;

namespace Runtime
{
    public sealed class RobotPartInstance : MonoBehaviour
    {
        private Renderer _renderer;
        
        public void Init(RobotPartAsset asset)
        {
            _renderer = GetComponentInChildren<Renderer>();
        }

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
    }
}