using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using Assets._Project.Develop.Runtime.GamePlay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.Core;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.GamePlay.Core
{
    public class GameProcess
    {
        private bool _isRunning;
        private int _currentCharIndex;
        private Combination _combination;

        private GameplayInputArgs _gameplayInputArgs;
        private ICoroutinesPerformer _coroutinesPerformer;
        private SceneSwitcherService _sceneSwitcherService;

        public GameProcess(GameplayInputArgs gameplayInputArgs, SceneSwitcherService sceneSwitcherService, ICoroutinesPerformer coroutinesPerformer)
        {
            _gameplayInputArgs = gameplayInputArgs;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Initialize()
        {
            Keyboard.current.onTextInput += ProcessInput;

            _combination = new CombinationFactory(_gameplayInputArgs.KeyRangeConfig).CreateCombination();

            _isRunning = true;

            ShowGameInfo();
        }

        public void Run() => _isRunning = true;

        public void ProcessInput(char inputChar)
        {
            if (_isRunning == false)
                return;

            if (IsCorrectChar(inputChar))
            {
                _currentCharIndex++;

                if (_currentCharIndex >= _combination.Value.Length)
                {
                    _coroutinesPerformer.StartPerform(WinGameProcess());
                    return;
                }
            }

            _coroutinesPerformer.StartPerform(DefeatGameProcess());
        }

        public bool IsCorrectChar(char inputChar)
        {
            if (inputChar.ToString().ToUpper() == _combination.Value[_currentCharIndex].ToString().ToUpper())
                return true;

            return false;
        }
      
        private IEnumerator WinGameProcess()
        {
            Debug.Log("Ты победил!");
            Debug.Log("Нажмите Space чтобы продолжить");

            yield return Reset(Scenes.MainMenu);
        }

        private IEnumerator DefeatGameProcess()
        {
            Debug.Log("Ты проиграл!");
            Debug.Log("Нажмите Space чтобы продолжить");

            yield return Reset(Scenes.Gameplay);
        }

        private IEnumerator Reset(string sceneName)
        {
            _isRunning = false;
            _currentCharIndex = 0;

            Keyboard.current.onTextInput -= ProcessInput;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(sceneName, _gameplayInputArgs));
        }

        private void ShowGameInfo() => Debug.Log($"Для победы введите без ошибок {_combination.Value}");
    }
}