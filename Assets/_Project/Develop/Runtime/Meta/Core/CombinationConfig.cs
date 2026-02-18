using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Core
{
    [CreateAssetMenu(fileName = "Config")]

    public class CombinationConfig : ScriptableObject
    {
        [field: SerializeField] public string NumberChars { get; set; }
        [field: SerializeField] public string LetterChars { get; set; }
        [field: SerializeField] public int LengthCombination { get; set; }
    }
}