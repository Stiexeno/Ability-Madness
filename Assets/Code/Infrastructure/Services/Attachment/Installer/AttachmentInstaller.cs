using Zenject;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler.Installer
{
    public class AttachmentInstaller : Installer<AttachmentInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AttachmentFacade>()
                .AsSingle();

            Container.BindInterfacesTo<AttachmentUpgradeService>()
                .AsSingle();

            Container.BindInterfacesTo<AttachmentCalculatorService>()
                .AsSingle();

            Container.BindInterfacesTo<AttachmentGridService>()
                .AsSingle();
        }
    }
}
