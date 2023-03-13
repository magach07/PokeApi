using PokeApi.Application.Commands.Interfaces;

namespace PokeApi.Application.Receivers.Interface
{
    public interface IReceiver<in T, out W>
    where T : ICommand
    where W : State
    {
        W Action (T command);
    }
}