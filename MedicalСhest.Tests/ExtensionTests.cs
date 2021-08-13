using MedicalСhest.Helpers.Extensions;
using System;
using Xunit;

namespace MedicalСhest.Tests
{
    public class ExtensionTests
    {
        [Fact]
        public void CalculateAge_TheBirthdayHasAlreadyComeThisYear_IntValue()
        {
            DateTime dateOfBirth = new DateTime(1991, 01, 01);
            var result = dateOfBirth.CalculateAge();
            var expectedResult = DateTime.Now.Year - dateOfBirth.Year;
            Assert.Equal(expectedResult, result);
        }

        [Fact] 
        public void CalculateAge_TheBirthdayHasNotComeYetThisYear_IntValue()
        {
            DateTime dateOfBirth = new DateTime(1991, 12, 31);
            var result = dateOfBirth.CalculateAge();
            var expectedResult = (DateTime.Now.Year - dateOfBirth.Year)-1;
            Assert.Equal(expectedResult, result);
        }
    }
}
