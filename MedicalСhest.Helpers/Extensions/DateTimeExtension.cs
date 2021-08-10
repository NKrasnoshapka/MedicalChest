﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalСhest.Helpers.Extensions
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
