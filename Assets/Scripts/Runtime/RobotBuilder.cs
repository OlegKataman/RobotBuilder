using System;
using UnityEngine;

namespace Runtime
{
    public sealed class RobotBuilder : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _robotPrefab;

        private Transform _headRoot;
        private Transform _torsoRoot;
        private Transform _legsRoot;

        private RobotPartAsset _currentHead;
        private RobotPartAsset _currentTorso;
        private RobotPartAsset _currentLegs;
        
        public event Action<float, float> OnStatsChanged;

        private void Awake()
        {
            var instance = Instantiate(_robotPrefab);
            
            foreach (var part in instance.GetComponentsInChildren<PartRoot>())
            {
                switch (part.PartType)
                {
                    case PartType.Head:  _headRoot = part.transform; break;
                    case PartType.Torso: _torsoRoot = part.transform; break;
                    case PartType.Legs:  _legsRoot = part.transform; break;
                    default: 
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void SetPart(RobotPartAsset asset)
        {
            var root = GetRoot(asset.PartType);
            
            if (root.childCount > 0)
                Destroy(root.GetChild(0).gameObject);

            var instance = Instantiate(asset.Prefab, root);
            var robotPart = instance.GetComponent<RobotPartInstance>();
            robotPart.Init(asset);
            
            switch (asset.PartType)
            {
                case PartType.Head:  _currentHead = asset;  break;
                case PartType.Torso: _currentTorso = asset; break;
                case PartType.Legs:  _currentLegs = asset;  break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            RecalculateStats();
        }

        private Transform GetRoot(PartType type)
        {
            var root = type switch
            {
                PartType.Head => _headRoot,
                PartType.Torso => _torsoRoot,
                PartType.Legs => _legsRoot,
                _ => throw new ArgumentOutOfRangeException()
            };

            return root;
        }
        
        private void RecalculateStats()
        {
            float weight = 0;
            float power = 0;

            if (_currentHead) { weight += _currentHead.Weight; power += _currentHead.Power; }
            if (_currentTorso) { weight += _currentTorso.Weight; power += _currentTorso.Power; }
            if (_currentLegs) { weight += _currentLegs.Weight; power += _currentLegs.Power; }

            OnStatsChanged?.Invoke(weight, power);
        }
    }
}