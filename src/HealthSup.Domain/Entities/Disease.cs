﻿namespace HealthSup.Domain.Entities
{
    public class Disease : BaseEntity
    {
        public Disease
        (
            int id,
            string name
        )
        {
            Id = id;
            Name = name;
        }

        public Disease() { }

        public int Id { get; private set; }

        public string Name { get; private set; }
    }
}
