using Newtonsoft.Json.Converters;

namespace BeerBowlingLeague.Server.Entity
{
    class JsonDateConverter : IsoDateTimeConverter
    {
        public JsonDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
