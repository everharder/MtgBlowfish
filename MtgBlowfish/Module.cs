using Autofac;
using MtgBlowfish.Internal.Services.Agent;
using MtgBlowfish.Internal.Services.Deck;
using MtgBlowfish.Internal.Services.Game;
using MtgBlowfish.Internal.Services.Oracle;

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
        builder.RegisterType<Random>().AsSelf();
    }
}