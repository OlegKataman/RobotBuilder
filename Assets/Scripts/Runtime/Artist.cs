using System.Linq;
using UnityEngine;

namespace Runtime
{
    public sealed class Artist : MonoBehaviour
    {
        [SerializeField] 
        public BuilderPallete _pallete;

        [SerializeField] 
        private LayerMask _robotLayer;

        private ColorEntry _current;

        public void SetColor(BuilderColor color)
        {
            _current = _pallete.Entries.FirstOrDefault(x => x.builderColor == color);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
                
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit, 500, _robotLayer)) return;

            var robotPartInstance = hit.transform.GetComponentInParent<RobotPartInstance>();
            robotPartInstance.SetColor(_current.color);
        }
    }
}