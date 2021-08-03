using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MedicalСhest.DAL.Models
{
    public enum Specialisation
    {
        [EnumMember(Value = "Physician")]
        Physician,
        [EnumMember(Value = "Cardiologists")]
        Cardiologists,
        [EnumMember(Value = "Endocrinologists")]
        Endocrinologists,
        [EnumMember(Value = "Neurologists")]
        Neurologists
    }
}
