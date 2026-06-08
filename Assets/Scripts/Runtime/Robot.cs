using System.Collections;
using UnityEngine;

namespace Runtime
{
    public sealed class Robot : MonoBehaviour
    {
        [SerializeField] 
        private float _speed = 5f;
    
        private Coroutine _testRoutine;

        private void Update()
        {
            if (!Input.GetMouseButton(0)) return;
        
            var delta = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, -delta * _speed);
        }

        public void PlayTestAction()
        {
            if (_testRoutine != null)
                return;

            _testRoutine = StartCoroutine(TestRoutine());
        }
    
        private IEnumerator TestRoutine()
        {
            transform.position += Vector3.up * 0.2f;
            yield return new WaitForSeconds(0.2f);
            transform.position -= Vector3.up * 0.2f;

            _testRoutine = null;
        }
    }
}