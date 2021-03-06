﻿using SammakEnterprise.Core.Persistence.Services;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Service.Agency
{
    public interface IAgencyService : IService<Middle.JobSearchAccess.Entity.Agency>
    {
        AgencyExposeCollection GetAll();
        AgencyExpose GetAgency(string agencyName);
        AgencyExpose CreateAgency(string agencyName);
    }
}
