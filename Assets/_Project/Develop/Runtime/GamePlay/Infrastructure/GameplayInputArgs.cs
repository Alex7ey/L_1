using Assets._Project.Develop.Runtime.Meta.Core;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.GamePlay.Infrastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(GameMode mode)
        {
            GameMode = mode;
        }

        public GameMode GameMode { get; private set; }
    }
}
