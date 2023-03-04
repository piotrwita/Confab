using System.Text;
using System.Text.Json;

namespace Confab.Shared.Infrastructure.Modules;

internal sealed class JsonModuleSerializer : IModuleSerializer
{
    //ustawienie parametrow serializacji
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        //dzieki temu nie ma znaczenia konwecja nazewnicza czy ktos snake czy pascal itp
        PropertyNameCaseInsensitive = true
    };

    public byte[] Serialize<T>(T value)
        => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, SerializerOptions));

    public T Deserialize<T>(byte[] value)
        => JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(value), SerializerOptions);

    public object Deserialize(byte[] value, Type type)
        => JsonSerializer.Deserialize(Encoding.UTF8.GetString(value), type, SerializerOptions);
}