using Assets._Project.Develop.Runtime;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Meta;
using Assets._Project.Develop.Runtime.SceneManagment;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BootstrapMainMenu : Bootstrap
{
    private CombinationSelector _combinationSelection;
    private ICombination _combinationFactory;
    private DIContainer _projectContainer;

    private ICombination _combination;

    private bool _isRunning;

    public override IEnumerator Initialize()
    {
        _combinationSelection = new();
        yield break;
    }

    public override void ProcessRegistrations(DIContainer container)
    {
        _projectContainer = container;

        //MainMenyServiceRegistration.Process(container);
    }

    public override void Run()
    {
        _isRunning = true;
    }

    private void Update()
    {
        if (_isRunning == false)
            return;

        if (_combinationSelection.TryGetSelectedCombination(out ICombination combination))
            _combination = combination;

        if (_combination != null)
        {
            _isRunning = false;
            _projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(SwitchScene(_projectContainer));
        }
    }

    private IEnumerator SwitchScene(DIContainer container)
    {
        ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
        SceneSwitcherService sceneSwitcher = container.Resolve<SceneSwitcherService>();

        loadingScreen.Show();

        yield return new WaitForSeconds(2);

        loadingScreen.Hide();

        yield return sceneSwitcher.ProcessSwitchTo(Scenes.Gameplay);
    }

}



