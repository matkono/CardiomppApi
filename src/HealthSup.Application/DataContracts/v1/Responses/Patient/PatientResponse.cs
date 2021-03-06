﻿using HealthSup.Application.DataContracts.v1.Responses.Address;

namespace HealthSup.Application.DataContracts.v1.Responses.Patient
{
    public class PatientResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Registration { get; set; }

        public AddressResponse Address { get; set; }
    }
}
