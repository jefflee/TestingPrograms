﻿namespace TestingPrograms.AutoFixture.Tests.TestingClasses
{
    public class Airport
    {
        private string _airportCode = string.Empty;

        public string AirportCode
        {
            get => _airportCode;
            set
            {
                EnsureValidAirportCode(value);
                _airportCode = value;
            }
        }

        public string AirlineName { get; set; } = string.Empty;

        private void EnsureValidAirportCode(string airportCode)
        {
            var isWrongLength = airportCode.Length != 3;

            var isWrongCase = airportCode != airportCode.ToUpperInvariant();

            if (isWrongLength || isWrongCase)
            {
                throw new Exception(airportCode + " is an invalid airport");
            }
        }
    }
}