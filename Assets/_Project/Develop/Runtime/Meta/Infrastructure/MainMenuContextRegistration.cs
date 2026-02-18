using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Core;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateCombinationSelectorService);
        }

        private static CombinationSelector CreateCombinationSelectorService(DIContainer container) => new CombinationSelector();
    }
}
