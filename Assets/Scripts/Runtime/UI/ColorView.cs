using UnityEngine;

namespace Runtime.UI
{
    public sealed class ColorView : MonoBehaviour
    {
        [SerializeField] 
        private BuilderColor _color;
        
        public void OnClick()
        {
            FindAnyObjectByType<Artist>().SetColor(_color);
        }
    }
}