using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu]
    public sealed class RobotPartAsset : ScriptableObject
    {
        [field : SerializeField] public GameObject Prefab { get; set; }
        [field : SerializeField] public PartType PartType { get; set; }
        [field : SerializeField] public float Weight { get; set; }
        [field : SerializeField] public float Power { get; set; }
    }
}