using UnityEngine;

namespace Runtime
{
    public class RotateByDrag : MonoBehaviour
    {
        public float speed = 5f;

        private void Update()
        {
            if (!Input.GetMouseButton(0)) return;
            
            var delta = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, -delta * speed);
        }
    }
}