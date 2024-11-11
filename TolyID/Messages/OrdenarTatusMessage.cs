using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TolyID.Messages;

public class OrdenarTatusMessage : ValueChangedMessage<Dictionary<int, int>>
{
    public OrdenarTatusMessage(Dictionary<int, int> value) : base(value)
    {
    }
}
