using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Core
{
    [CreateAssetMenu(fileName = "Config")]

    public class CombinationConfig : ScriptableObject
    {
        [field: SerializeField] public KeyRangeNumberConfig Number { get; }
        [field: SerializeField] public KeyRangeLetterConfig Letter { get; }
    }

    [Serializable]
    public class KeyRangeNumberConfig : IKeyRangeConfig
    {
        [field: SerializeField] public int KeyCodeFrom { get; }
        [field: SerializeField] public int KeyCodeTo { get; }
    }

    [Serializable]
    public class KeyRangeLetterConfig : IKeyRangeConfig
    {
        [field: SerializeField] public int KeyCodeFrom { get; }
        [field: SerializeField] public int KeyCodeTo { get; }
    }
}