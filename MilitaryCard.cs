using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static LabaOOP10.MilitaryCard;

namespace LabaOOP10
{
    public class MilitaryCard
    {
        public string pattern = @"^([А-ЯІЇЄҐ][а-яіїєґ]+)\s([А-ЯІЇЄҐ][а-яіїєґ]+)\s([А-ЯІЇЄҐ][а-яіїєґ]+)$";
        public enum suitability { unattributed, unattributedWithSecondGlance,suitableWithException,suitable,temporaryUnattributed}
        public string name;
        public DateTime yearOfBirth;
        public string adress;
        public DateTime dateOfDemobilization;
        public string placeOfService;
        public suitability suitabilitys;
        public MilitaryCard(string name, DateTime yearOfBirth, string adress, DateTime dateOfDemobilization, string placeOfService, suitability suitability)
        {
            this.name = Regex.IsMatch(name, pattern) ? name : "no name";
            this.yearOfBirth = yearOfBirth;
            this.adress = adress;
            this.dateOfDemobilization = dateOfDemobilization;
            this.placeOfService = placeOfService;
            this.suitabilitys = suitability;

        }
        public MilitaryCard() {
            Name = "No name";
            YearOfBirth = DateTime.Now;
            Adress = "Unknown";
            DateOfDemobilization = DateTime.Now;
            PlaceOfService = "Unknown";
            Suitabilitys = suitability.unattributed;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (Regex.IsMatch(value, pattern))
                    name = value;
                else
                    name = "no name";
            }
        }
        public DateTime YearOfBirth
        {
            get { return yearOfBirth; }
            set { yearOfBirth = value; }
        }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        public DateTime DateOfDemobilization
        {
            get { return dateOfDemobilization; }
            set { dateOfDemobilization = value; }
        }
        public string PlaceOfService
        {
            get { return placeOfService; }
            set { placeOfService = value; }
        }
        public suitability Suitabilitys
        {
            get { return suitabilitys; }
            set { suitabilitys = value; }
        }
        public override string ToString()
        {
            return $"Name: {name}, Year of Birth: {yearOfBirth.ToShortDateString()}, Adress: {adress}, Date of Demobilization: {dateOfDemobilization.ToShortDateString()}, Place of Service: {placeOfService}, Suitability: {suitabilitys}";
        }



    }
}
