using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta
{
    public class CombinationSelector
    {
        public bool TryGetSelectedCombination(out ICombination combination)
        {
            combination = null;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                combination = new NumberCombination();
                return true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                combination = new LetterCombination();
                return true;
            }

            return false;
        }
    }
}