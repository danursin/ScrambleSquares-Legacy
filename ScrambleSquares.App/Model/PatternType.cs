using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MilitaryPuzzle.App.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PatternType
    {
        
        Pattern1,
        Pattern2,
        Pattern3,
        Pattern4
    }
}