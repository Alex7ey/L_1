using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Core
{
    public class CombinationSelector
    {
        private GameMode _defaultMode = GameMode.Number;

        public bool TryGetSelectedModeType(out GameMode selectedMode)
        {
            selectedMode = _defaultMode;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedMode = GameMode.Number;        
                return true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedMode = GameMode.Letter;
                return true;
            }

            return false;
        }
    }
}