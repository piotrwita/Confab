using Confab.Shared.Abstractions.Messaging;

namespace Confab.Shared.Abstractions.Commands;

//Marker
//dziedzicze po IMessage zeby przez mesage brokera wyslac komende obsluzona w innym module
public interface ICommand : IMessage
{
}
