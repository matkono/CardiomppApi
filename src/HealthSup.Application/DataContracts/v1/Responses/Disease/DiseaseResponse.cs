﻿using System.Runtime.Serialization;

namespace HealthSup.Application.DataContracts.v1.Responses.Disease
{
    [DataContract]
    public class DiseaseResponse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
