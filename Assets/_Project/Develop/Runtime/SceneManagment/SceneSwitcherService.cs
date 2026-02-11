using Assets._Project.Develop.Runtime.Infrastructure;
using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.SceneManagment
{
    public class SceneSwitcherService
    {
        private SceneLoaderService _sceneLoaderService;
        private ILoadingScreen _loadingScreen;
        private DIContainer _projectContainer;

        public SceneSwitcherService(SceneLoaderService sceneLoaderService, ILoadingScreen loadingScreen, DIContainer container)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreen = loadingScreen;
            _projectContainer = container;
        }

        public IEnumerator ProcessSwitchTo(string nameScene)
        {
            _loadingScreen.Show();

            yield return _sceneLoaderService.LoadAsync(Scenes.Empty);
            yield return _sceneLoaderService.LoadAsync(nameScene);

            Bootstrap sceneBootstrap = Object.FindObjectOfType<Bootstrap>();

            if (sceneBootstrap == null)   
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            //DIContainer sceneContainer = new(_projectContainer);

            sceneBootstrap.ProcessRegistrations(_projectContainer);

            yield return sceneBootstrap.Initialize();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}