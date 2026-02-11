using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            DIContainer projectContainer = new();

            ProjectContextServiceRegistration.Process(projectContainer);

            projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
        }

        private IEnumerator Initialize(DIContainer container)
        {   
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcher = container.Resolve<SceneSwitcherService>();
  
            loadingScreen.Show();

            yield return new WaitForSeconds(2);

            loadingScreen.Hide();

            yield return sceneSwitcher.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}