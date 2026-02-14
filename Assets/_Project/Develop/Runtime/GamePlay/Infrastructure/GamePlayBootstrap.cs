using System;
using System.Collections;
using Assets._Project.Develop.Runtime.GamePlay.Core;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DIContainer;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.GamePlay.Infrastructure
{
    public class GamePlayBootstrap : Bootstrap
    {
        private GameProcess _gameProcess;
        private DIContainer _container;
        private GameplayInputArgs _gameplayInputArgs;

        public override IEnumerator Initialize()
        {
            _gameProcess = new(_gameplayInputArgs, _container.Resolve<SceneSwitcherService>(), _container.Resolve<ICoroutinesPerformer>());
            _gameProcess.Initialize();
            yield break;
        }

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs inputSceneArgs)
        { 
            if (inputSceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(inputSceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _container = container;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public override void Run() => _gameProcess.Run();     
    }
}