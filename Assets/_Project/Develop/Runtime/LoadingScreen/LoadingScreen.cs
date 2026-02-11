using UnityEngine;

namespace Assets._Project.Develop.Runtime.SceneManagment
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        public bool IsShown => gameObject.activeSelf;

        private void Awake()
        {        
            Hide();
            DontDestroyOnLoad(this);
        }

        public void Hide() => gameObject.SetActive(false);
     
        public void Show() => gameObject.SetActive(true);
    }
}
