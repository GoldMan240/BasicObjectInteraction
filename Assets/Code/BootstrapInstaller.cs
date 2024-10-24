using Code.Player;
using Code.Services.Input;
using Code.Services.Interaction;
using Zenject;

namespace Code
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
            Container.Bind<IInteractionService>().To<InteractionService>().AsSingle();
        }
    }
}
