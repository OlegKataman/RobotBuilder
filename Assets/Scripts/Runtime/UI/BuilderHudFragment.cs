using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runtime.UI
{
    public sealed class BuilderHudFragment : MonoBehaviour
    {
        [SerializeField] 
        private RobotBuilder _builder;

        [SerializeField] 
        private TMP_Text _weightText, _powerText;

        [SerializeField] 
        private List<RobotPartAsset> _heads, _torsos, _legs;

        private int _headIndex;
        private int _torsoIndex;
        private int _legsIndex;

        private void Start()
        {
            _builder.SetPart(_heads[0]);
            _builder.SetPart(_torsos[0]);
            _builder.SetPart(_legs[0]);
        }

        private void OnEnable() => _builder.OnStatsChanged += UpdateStatsUI;
        private void OnDisable() => _builder.OnStatsChanged -= UpdateStatsUI;
        
        private void UpdateStatsUI(float weight, float power)
        {
            _weightText.text = $"Weight: {weight:0.0}";
            _powerText.text = $"Power: {power:0.0}";
        }

        public void OnTestButtonClick()
        {
            FindAnyObjectByType<Robot>().PlayTestAction();
        }

        public void PreviousHead()
        {
            _headIndex = (_headIndex - 1 + _heads.Count) % _heads.Count;
            _builder.SetPart(_heads[_headIndex]);
        }

        public void NextHead()
        {
            _headIndex = (_headIndex + 1) % _heads.Count;
            _builder.SetPart(_heads[_headIndex]);
        }

        public void PreviousTorso()
        {
            _torsoIndex = (_torsoIndex - 1 + _torsos.Count) % _torsos.Count;
            _builder.SetPart(_torsos[_torsoIndex]);
        }

        public void NextTorso()
        {
            _torsoIndex = (_torsoIndex + 1) % _torsos.Count;
            _builder.SetPart(_torsos[_torsoIndex]);
        }

        public void PreviousLegs()
        {
            _legsIndex = (_legsIndex - 1 + _legs.Count) % _legs.Count;
            _builder.SetPart(_legs[_legsIndex]);
        }

        public void NextLegs()
        {
            _legsIndex = (_legsIndex + 1) % _legs.Count;
            _builder.SetPart(_legs[_legsIndex]);
        }
    }
}