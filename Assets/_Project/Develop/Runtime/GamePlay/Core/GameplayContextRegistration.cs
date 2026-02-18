using Assets._Project.Develop.Runtime.GamePlay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Core;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.GamePlay.Core
{
    public class GameplayContextRegistration
    {
        private static GameplayInputArgs _gameplayInputArgs;

        public static void Process(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _gameplayInputArgs = gameplayInputArgs;

            container.RegisterAsSingle(CreateCombinationFactory);
            container.RegisterAsSingle(CreateGameProcess);
        }

        private static CombinationFactory CreateCombinationFactory(DIContainer container)
        {
            return new CombinationFactory(container.Resolve<ConfigsProviderService>().GetConfig<CombinationConfig>());
        }

        private static GameProcess CreateGameProcess(DIContainer container)
        {
            GameProcess gameProcess = new(_gameplayInputArgs, container.Resolve<SceneSwitcherService>(), container.Resolve<ICoroutinesPerformer>(), container.Resolve<CombinationFactory>());

            return gameProcess;
        }
    }
}
