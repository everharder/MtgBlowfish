using Autofac;

namespace MtgBlowfish.Internal.Game.Behaviors;

internal class BehaviorsModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<DrawCardInDrawPhaseBehavior>().As<IBehavior>();
    }
}