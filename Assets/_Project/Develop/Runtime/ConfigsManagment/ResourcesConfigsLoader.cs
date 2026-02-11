using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Project.Develop.Runtime.AssetsLoader;

namespace Assets._Project.Develop.Runtime.ConfigsManagment
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resources = new();

        private Dictionary<Type, string> _configsResourcesPaths = new()
        {

        };

        public ResourcesConfigsLoader(ResourcesAssetsLoader resources)
        {
            _resources = resources;
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (var configsResourcesPaths in _configsResourcesPaths)
            {
                ScriptableObject config = _resources.Load<ScriptableObject>(configsResourcesPaths.Value); 
                loadedConfigs.Add(configsResourcesPaths.Key, config);
                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }

    }
}
