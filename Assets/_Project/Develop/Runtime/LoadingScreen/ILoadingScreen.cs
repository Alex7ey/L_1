namespace Assets._Project.Develop.Runtime.SceneManagment
{
    public interface ILoadingScreen
    {
        bool IsShown { get; }
        void Show();
        void Hide();
    }
}
