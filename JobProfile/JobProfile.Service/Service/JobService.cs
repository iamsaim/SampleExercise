using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobProfile.Application.Context;
using JobProfile.Domain.Entity;
using JobProfile.Service.DTO;

namespace JobProfile.Service.Service 
{
    public class JobService : IJobService
    {
        private readonly ApplicationContext _dbContext;

        public JobService(ApplicationContext dbContext) => _dbContext = dbContext;

        public IEnumerable<JobDTO> GetAllJob()
        {
            var result = _dbContext.Jobs.Select(x => 
            new JobDTO 
            { 
                JobProfileId = x.JobProfileId,
                JobDescription = x.JobDescription,
                JobTitle = x.JobTitle,
                JobLocation = x.JobLocation
            });

            return result;
        }

        public void AddJob(JobDTO job)
        {
            _dbContext.Jobs.Add(new JobEntity
            {
                JobProfileId = job.JobProfileId,
                JobDescription = job.JobDescription,
                JobLocation = job.JobLocation,
                JobTitle = job.JobTitle

            });

            _dbContext.SaveChanges();
        }

        public JobDTO GetJob(Guid Id)
        {
            var result = _dbContext.Jobs.FirstOrDefault(x=>x.JobProfileId == Id);

            return new JobDTO {
                JobProfileId = result.JobProfileId,
                JobDescription = result.JobDescription,
                JobTitle = result.JobTitle,
                JobLocation = result.JobLocation
            };
        }
    }
}
