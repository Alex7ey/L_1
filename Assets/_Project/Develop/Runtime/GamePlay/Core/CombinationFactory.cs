using Assets._Project.Develop.Runtime.Meta.Core;
using System.Text;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.GamePlay.Core
{
    public class CombinationFactory
    {  
        private CombinationConfig _config;
        private StringBuilder _stringBuilder = new();

        public CombinationFactory(CombinationConfig config) => _config = config;
        
        public ICombination CreateCombination(GameMode mode)
        {         
            string chars = mode == GameMode.Letter ? _config.LetterChars : _config.NumberChars;

            for (int i = 0; i < _config.LengthCombination; i++)           
                _stringBuilder.Append(chars[Random.Range(0, chars.Length)]);           
          
            string combinationString = _stringBuilder.ToString();

            _stringBuilder.Clear();

            return new Combination(combinationString);
        }
    }
}
