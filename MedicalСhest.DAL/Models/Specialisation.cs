using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace MedicalСhest.DAL.Models
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum Specialisation
    {
        [EnumMember(Value = "Physician")]
        Physician = 1,
        [EnumMember(Value = "Cardiologists")]
        Cardiologists = 2,
        [EnumMember(Value = "Endocrinologists")]
        Endocrinologists = 3,
        [EnumMember(Value = "Neurologists")]
        Neurologists = 4
    }
}
