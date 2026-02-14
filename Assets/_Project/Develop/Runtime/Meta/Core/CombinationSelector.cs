using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Core
{
    public class CombinationSelector
    {
        private ConfigsProviderService _configsProviderService;

        public CombinationSelector(ConfigsProviderService configsProviderService)
        {
            _configsProviderService = configsProviderService;
        }

        public bool TryGetSelectedCombination(out IKeyRangeConfig combination)
        {
            combination = null;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                combination = _configsProviderService.GetConfig<CombinationConfig>().Number;        
                return true;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                combination = _configsProviderService.GetConfig<CombinationConfig>().Letter;
                return true;
            }

            return false;
        }
    }
}