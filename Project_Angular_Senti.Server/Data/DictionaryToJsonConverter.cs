using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project_Angular_Senti.Server.Data
{
    public class DictionaryToJsonConverter : ValueConverter<Dictionary<string, string>, string>
    {

        public DictionaryToJsonConverter()
        : base(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v) ?? new Dictionary<string, string>())
        {}

        public static ValueComparer<Dictionary<string, string>> GetValueComparer()
        {
            return new ValueComparer<Dictionary<string, string>>(
                (d1, d2) => JsonConvert.SerializeObject(d1) == JsonConvert.SerializeObject(d2),
                d => d != null ? JsonConvert.SerializeObject(d).GetHashCode() : 0,
                d => d != null ? new Dictionary<string, string>(d) : new Dictionary<string, string>()
            );
        }
    }
}
