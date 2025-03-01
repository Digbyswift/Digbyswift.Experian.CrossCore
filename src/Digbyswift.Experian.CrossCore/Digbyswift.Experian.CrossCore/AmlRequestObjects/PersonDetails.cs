using System;
using Digbyswift.Core.Extensions;

namespace Digbyswift.Experian.CrossCore.AmlRequestObjects
{
    public class PersonDetails
    {
        public int? Age { get; set; }
        public int? NoOfDependents { get; set; }
#if NET6_0_OR_GREATER
        public string? CountryOfBirth { get; set; }
        public string? DateOfBirth { get; set; }
        public string? DateOfDeath { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? MothersMaidenName { get; set; }
        public string? NationalityCountryCode { get; set; }
        public string? OccupancyStatus { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? SpouseName { get; set; }
        public string? YearOfBirth { get; set; }
#else
        public string CountryOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfDeath { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string MothersMaidenName { get; set; }
        public string NationalityCountryCode { get; set; }
        public string OccupancyStatus { get; set; }
        public string PlaceOfBirth { get; set; }
        public string SpouseName { get; set; }
        public string YearOfBirth { get; set; }
#endif

        public PersonDetails()
        {
        }

        public PersonDetails(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth.ToString("yyyy-MM-dd");
            Age = dateOfBirth.GetAge();
            YearOfBirth = dateOfBirth.Year.ToString();
        }
    }
}
