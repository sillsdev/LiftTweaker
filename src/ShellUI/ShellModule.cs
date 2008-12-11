namespace Tweaker
{
    public class ShellModule : Autofac.Builder.Module
    {
        protected override void Load(Autofac.Builder.ContainerBuilder builder)
        {
            builder.Register<Shell>();
            builder.Register<OpenLiftCommand>();

        }
    }
}