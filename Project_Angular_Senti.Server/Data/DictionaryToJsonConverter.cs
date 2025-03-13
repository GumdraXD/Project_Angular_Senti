using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project_Angular_Senti.Server.Data
{
    public class DictionaryToJsonConverter : ValueConverter<Dictionary<string, object>, string>
    {

        public DictionaryToJsonConverter()
        : base(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Dictionary<string, object>>(v) ?? new Dictionary<string, object>())
        {}

        public static ValueComparer<Dictionary<string, object>> GetValueComparer()
        {
            return new ValueComparer<Dictionary<string, object>>(
                (d1, d2) => JsonConvert.SerializeObject(d1) == JsonConvert.SerializeObject(d2),
                d => d != null ? JsonConvert.SerializeObject(d).GetHashCode() : 0,
                d => d != null ? new Dictionary<string, object>(d) : new Dictionary<string, object>()
            );
        }
    }
}
