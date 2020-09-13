﻿using System;
using System.Data;

namespace HealthSup.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin
        (
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted
        );

        void Commit();

        void Rollback();

        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        IDoctorRepository DoctorRepository { get; }

        IHealthSupAgentRepository HealthSupAgentRepository { get; }

        IUserRepository UserRepository { get; }

        IMedicalAppointmentRepository MedicalAppointmentRepository { get; }

        INodeRepository NodeRepository { get; }
    }
}