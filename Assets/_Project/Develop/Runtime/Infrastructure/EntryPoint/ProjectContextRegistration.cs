using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.AssetsLoader;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class ProjectContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle(CreateResourceAssetsLoader);
            container.RegisterAsSingle(CreateConfigsProviderService);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinePerformer);
            container.RegisterAsSingle<IConfigsLoader>(CreateResourcesConfigsLoader);
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

        private static ConfigsProviderService CreateConfigsProviderService(DIContainer container) => new ConfigsProviderService(container.Resolve<IConfigsLoader>());

        private static ResourcesConfigsLoader CreateResourcesConfigsLoader(DIContainer container) => new (container.Resolve<ResourcesAssetsLoader>());
       
    }
}