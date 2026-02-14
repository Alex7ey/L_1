using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Core
{
    [CreateAssetMenu(fileName = "Config")]

    public class CombinationConfig : ScriptableObject
    {
        [field: SerializeField] public KeyRangeNumberConfig Number { get; set; }
        [field: SerializeField] public KeyRangeLetterConfig Letter { get; set; }
    }

    [Serializable]
    public class KeyRangeNumberConfig : IKeyRangeConfig
    {
        [field: SerializeField] public int KeyCodeFrom { get; set; }
        [field: SerializeField] public int KeyCodeTo { get; set; }
    }

    [Serializable]
    public class KeyRangeLetterConfig : IKeyRangeConfig
    {
        [field: SerializeField] public int KeyCodeFrom { get; set; }
        [field: SerializeField] public int KeyCodeTo { get; set; }
    }
}