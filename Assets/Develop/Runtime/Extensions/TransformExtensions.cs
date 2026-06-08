using UnityEngine;

namespace Develop.Runtime.Extensions
{
    public static class TransformExtensions
    {
        public static Vector3 GetChildrenCenter(this Transform target)
        {
            var renderers = target.GetComponentsInChildren<Renderer>();

            if (renderers.Length == 0) return target.position;

            var bounds = renderers[0].bounds;
            for (int i = 1; i < renderers.Length; i++)
                bounds.Encapsulate(renderers[i].bounds);

            return bounds.center;
        }
        
        public static void SetMatrix(this Transform self, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            self.position = new Vector3(position.x, position.y, position.z);
            self.localScale = new Vector3(scale.x, scale.y, scale.z);
            self.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
        }

        public static void SetLocalScale(this Transform self, float value)
        {
            self.localScale = Vector3.one * value;
        }

        public static void SetLocalScaleX(this Transform self, float value)
        {
            var scale = self.localScale;
            self.localScale = new Vector3(value, scale.y, scale.z);
        }

        public static void SetLocalScaleY(this Transform self, float value)
        {
            var scale = self.localScale;
            self.localScale = new Vector3(scale.x, value, scale.z);
        }

        public static void SetLocalScaleZ(this Transform self, float value)
        {
            var scale = self.localScale;
            self.localScale = new Vector3(scale.x, scale.y, value);
        }

        public static void SetLocalScaleXY(this Transform self, float value)
        {
            var scale = self.localScale;
            self.localScale = new Vector3(value, value, scale.z);
        }

        public static void SetLocalPositionX(this Transform self, float value)
        {
            var localPosition = self.localPosition;
            localPosition.x = value;
            self.localPosition = localPosition;
        }

        public static void SetLocalPositionY(this Transform self, float value)
        {
            var localPosition = self.localPosition;
            localPosition.y = value;
            self.localPosition = localPosition;
        }

        public static void SetLocalPositionZ(this Transform self, float value)
        {
            var localPosition = self.localPosition;
            localPosition.z = value;
            self.localPosition = localPosition;
        }

        public static void SetLocalPositionXY(this Transform self, float x, float y)
        {
            var localPosition = self.localPosition;
            localPosition.x = x;
            localPosition.y = y;
            self.localPosition = localPosition;
        }

        public static void SetLocalPositionYZ(this Transform self, float y, float z)
        {
            var localPosition = self.localPosition;
            localPosition.y = y;
            localPosition.z = z;
            self.localPosition = localPosition;
        }

        public static void SetLocalPositionXZ(this Transform self, float x, float z)
        {
            var localPosition = self.localPosition;
            localPosition.x = x;
            localPosition.z = z;
            self.localPosition = localPosition;
        }

        public static void Reset(this Transform self)
        {
            self.localRotation = Quaternion.identity;
            self.localPosition = Vector3.zero;
            self.localScale = Vector3.one;
        }

        public static void ResetLocalScale(this Transform self)
        {
            self.localScale = Vector3.one;
        }

        public static void ResetLocalPosition(this Transform self)
        {
            self.localPosition = Vector3.zero;
        }

        public static void ResetLocalRotation(this Transform self)
        {
            self.localRotation = Quaternion.identity;
        }

        public static string GetPath(this Transform obj)
        {
            var path = "/" + obj.name;

            while (obj.parent != null)
            {
                obj = obj.parent.transform;
                path = "/" + obj.name + path;
            }

            return path;
        }
    }
}