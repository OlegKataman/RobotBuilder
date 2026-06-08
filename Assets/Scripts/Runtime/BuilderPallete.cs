using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu]
    public class BuilderPallete : ScriptableObject
    {
        [field : SerializeField] 
        public List<ColorEntry> Entries { get; private set; }
    }
    
    [Serializable]
    public class ColorEntry
    {
        public BuilderColor builderColor;
        public Color color;
    }
    
    public enum BuilderColor
    {
        Red,
        Green,
        Yellow
    }
}