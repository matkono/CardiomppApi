﻿using Cardiompp.Domain.Entities;
using Cardiompp.Domain.Repositories;
using Cardiompp.Infrastructure.Data.Scripts;
using Dapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cardiompp.Infrastructure.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private IUnitOfWork UnitOfWork { get; }

        public DoctorRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Doctor> GetByEmailAndPassword(string email, string password)
        {
            var query = ScriptManager.GetByName(ScriptManager.FileNames.Doctor.GetByEmailAndPassword);

            var result = await UnitOfWork.Connection.QueryAsync<Doctor>(
                                                                query,
                                                                new { email, password },
                                                                UnitOfWork.Transaction);

            return result.FirstOrDefault();
        }

        public async Task UpdatePassword(int doctorId, string newPassword)
        {
            var query = ScriptManager.GetByName(ScriptManager.FileNames.Doctor.UpdatePassword);

            await UnitOfWork.Connection.ExecuteAsync
            (
                query,
                new { doctorId, newPassword },
                UnitOfWork.Transaction
            );
        }
    }
}
