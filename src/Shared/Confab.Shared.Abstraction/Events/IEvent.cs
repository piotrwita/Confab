using Confab.Shared.Abstractions.Messaging;

namespace Confab.Shared.Abstractions.Events;

//Marker
// Dziedzicze po imessage poniewaz 
// to jest zdarzenie integracyjne (nie domenowe) 
//wobectego sluzy nam do integracji miedz modulami mozemy spokojnie oznaczyc jako imessage
public interface IEvent : IMessage
{
}
