using Assets._Project.Develop.Runtime.AssetsLoader;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.SceneManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime
{
    public class ProjectContextServiceRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle(CreateResourceAssetsLoader);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinePerformer);
        }

        private static CoroutinesPerformer CreateCoroutinePerformer(DIContainer container)
        {
            ResourcesAssetsLoader _assetsLoader = container.Resolve<ResourcesAssetsLoader>();

            CoroutinesPerformer coroutinePerformer = _assetsLoader.Load<CoroutinesPerformer>("Prefabs/CoroutinePerformer");

            return Object.Instantiate(coroutinePerformer);
        }

        private static LoadingScreen CreateLoadingScreen(DIContainer container)
        {
            ResourcesAssetsLoader _assetsLoader = container.Resolve<ResourcesAssetsLoader>();

            LoadingScreen loadingScreen = _assetsLoader.Load<LoadingScreen>("Prefabs/StandartLoadingScreen");

            return Object.Instantiate(loadingScreen);
        }

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer container)
        {
            return new SceneSwitcherService(container.Resolve<SceneLoaderService>(), container.Resolve<ILoadingScreen>(), container);
        }

        private static SceneLoaderService CreateSceneLoaderService(DIContainer container) => new SceneLoaderService();

        private static ResourcesAssetsLoader CreateResourceAssetsLoader(DIContainer container) => new ResourcesAssetsLoader();


    }
}