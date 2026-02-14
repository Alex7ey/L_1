using Assets._Project.Develop.Runtime.Meta.Core;
using System.Text;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.GamePlay.Core
{
    public class CombinationFactory 
    {
        private const int MinLength = 2;
        private const int MaxLength = 5;

        private IKeyRangeConfig _keyRangeConfig;

        private StringBuilder _stringBuilder = new();

        public CombinationFactory(IKeyRangeConfig config)
        {
            _keyRangeConfig = config;
        }

        public Combination CreateCombination()
        {
            int length = Random.Range(MinLength, MaxLength + 1);

            for (int i = 0; i < length; i++)
            {
                _stringBuilder.Append((char)Random.Range(_keyRangeConfig.KeyCodeFrom, _keyRangeConfig.KeyCodeTo));
            }

            return new Combination(_stringBuilder.ToString());
        }
    }
}
