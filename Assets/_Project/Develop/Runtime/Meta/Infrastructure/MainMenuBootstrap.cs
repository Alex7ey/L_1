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
    public class MainMenuBootstrap : Bootstrap
    {
        private DIContainer _container;
        private CombinationSelector _combinationSelector;

        private GameMode _gameMode;

        private bool _isRunning;

        public override IEnumerator Initialize()
        {
            _combinationSelector = _container.Resolve<CombinationSelector>();

            yield return _container.Resolve<ConfigsProviderService>().LoadAsync();
        }

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs inputSceneArgs)
        {
            _container = container;

            MainMenuContextRegistration.Process(_container);
        }
      
        public override void Run() => _isRunning = true;
      

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (_combinationSelector.TryGetSelectedModeType(out GameMode mode))
            {
                _isRunning = false;

                _gameMode = mode;

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

            yield return sceneSwitcher.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(_gameMode));
        }
    }
}