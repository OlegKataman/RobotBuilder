using UnityEngine;

namespace Runtime
{
    public sealed class PartRoot : MonoBehaviour
    {
        [field : SerializeField] public PartType PartType { get; private set; }
    }
}