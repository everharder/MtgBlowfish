using Autofac;
using Autofac.Features.Indexed;
using MtgBlowfish.Internal.Agent;
using MtgBlowfish.Internal.Deck;
using MtgBlowfish.Internal.Game;
using MtgBlowfish.Internal.Game.Behaviors;
using MtgBlowfish.Internal.Game.Interaction;
using MtgBlowfish.Internal.Game.Phases;
using MtgBlowfish.Internal.Models;
using MtgBlowfish.Internal.Oracle;

namespace MtgBlowfish;

internal class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<OracleService>().As<IOracleService>();
        builder.RegisterType<ArenaDeckListParser>().As<IDeckListParser>();
        builder.RegisterType<AgentService>().As<IAgentService>();
        builder.RegisterType<GameService>().As<IGameService>();
        builder.RegisterType<ActionResolver>().As<IActionResolver>();
        builder.RegisterType<PlayerFactory>().As<IPlayerFactory>();
        
        builder.RegisterType<HumanQuery>().Keyed<IQuery>(PlayerType.Human);
        builder.RegisterType<AgentQuery>().Keyed<IQuery>(PlayerType.Agent);
        builder.Register<Func<PlayerType, IQuery>>(c =>
        {
            var index = c.Resolve<IIndex<PlayerType, IQuery>>();
            return p => index[p];
        });

        builder.RegisterType<PhaseExecutor>().As<IPhaseExecutor>();
        builder.RegisterModule<BehaviorsModule>();
        
        builder.RegisterType<Random>().AsSelf();
    }
}