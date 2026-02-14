using Assets._Project.Develop.Runtime.Infrastructure.DI;
using System.Collections;
using UnityEngine;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            DIContainer projectContainer = new();

            ProjectContextRegistration.Process(projectContainer);

            projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
        }

        private IEnumerator Initialize(DIContainer container)
        {   
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcher = container.Resolve<SceneSwitcherService>();
  
            loadingScreen.Show();

            yield return new WaitForSeconds(1);

            loadingScreen.Hide();

            yield return sceneSwitcher.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}