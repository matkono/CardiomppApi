﻿using System.Runtime.Serialization;

namespace HealthSup.Application.DataContracts.v1.Responses.Node
{
    [DataContract]
    public class NodeTypeResponse
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public int Code { get; private set; }

        [DataMember]
        public string Name { get; private set; }
    }
}
