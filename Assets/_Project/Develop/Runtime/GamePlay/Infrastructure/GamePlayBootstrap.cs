using Assets._Project.Develop.Runtime.Infrastructure;
using System.Collections;

namespace Assets._Project.Develop.Runtime.GamePlay.Infrastructure
{
    public class GamePlayBootstrap : Bootstrap
    {
        private ICombination _combination;
        private DIContainer _projectContainer;
        public override IEnumerator Initialize()
        {     
            yield break;
        }

        public override void ProcessRegistrations(DIContainer container)
        {
            _projectContainer = container;
        }

        public override void Run()
        {
           
        }
    }
}