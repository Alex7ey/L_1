using UnityEngine;
using System.Collections;
using Assets._Project.Develop.Runtime.Meta.Core;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.GamePlay.Infrastructure;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class BootstrapMainMenu : Bootstrap
    {
        private DIContainer _container;
        private CombinationSelector _combinationSelector;

        private IKeyRangeConfig _selectedKeyRangeConfig;

        private bool _isRunning;

        public override IEnumerator Initialize()
        {
            ConfigsProviderService configsProviderService = _container.Resolve<ConfigsProviderService>();

            yield return configsProviderService.LoadAsync();

            _combinationSelector = new(_container.Resolve<ConfigsProviderService>());
        }

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs inputSceneArgs) => _container = container;
      
        public override void Run() => _isRunning = true;
      

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (_combinationSelector.TryGetSelectedCombination(out IKeyRangeConfig config))
                _selectedKeyRangeConfig = config;

            if (_selectedKeyRangeConfig != null)
            {
                _isRunning = false;
                _container.Resolve<ICoroutinesPerformer>().StartPerform(SwitchScene(_container));
            }
        }

        private IEnumerator SwitchScene(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcher = container.Resolve<SceneSwitcherService>();

            loadingScreen.Show();

            yield return new WaitForSeconds(1);

            loadingScreen.Hide();

            yield return sceneSwitcher.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(_selectedKeyRangeConfig));
        }
    }
}