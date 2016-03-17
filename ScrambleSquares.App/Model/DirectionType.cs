using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MilitaryPuzzle.App.Model
{
    public enum DirectionType
    {
        [JsonConverter(typeof(StringEnumConverter))]
        Top,
        /// <summary>
        /// For Coast Guard, bottom means part with "Coastguard"
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        Bottom
    }
}