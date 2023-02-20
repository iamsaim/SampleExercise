using People.Service.HTTPClientWrapper;
using People.Application.Context;
using People.Domain.Entity;
using People.Service.DTO;
using Microsoft.Extensions.Configuration;

namespace People.Service.Service 
{
    public class PeopleService : IPeopleService
    {
        private readonly ApplicationContext _dbContext;
        private readonly IConfiguration _configuration;

        public PeopleService(ApplicationContext dbContext, IConfiguration configuration) 
        {
            _dbContext = dbContext;
            _configuration = configuration;
        } 

        public IEnumerable<PeopleDTO> GetPersons()
        {
            var result = _dbContext.People.Select(x => GetPerson(x).Result);

            return result;
        }

        public void AddPeople(PeopleDTO job)
        {
            _dbContext.People.Add(new PersonEntity
            {
                PersonId = job.PersonId,
                JobProfileId = job.JobProfileId,
                FirstName = job.FirstName,
                LastName = job.LastName

            });

            _dbContext.SaveChanges();
        }

        public async Task<PeopleDTO> GetPerson(Guid Id)
        {
            var result = _dbContext.People.FirstOrDefault(x=>x.JobProfileId == Id);

            return await GetPerson(result);
        }

        private async Task<PeopleDTO> GetPerson(PersonEntity result)
        {
            
            var uri = $"{_configuration.GetSection("APIUri").Get<APIUri>().JobAPI}/JobProfiles/{result.JobProfileId}";

            var jobProfile = await GetAPI(uri);
            return new PeopleDTO
            {
                PersonId = result.PersonId,
                JobProfileId = result.JobProfileId,
                JobDescription = jobProfile.JobDescription,
                JobLocation = jobProfile.JobLocation,
                JobTitle = jobProfile.JobTitle,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
        }
        private async Task<JobDTO> GetAPI(string URI)
        {

            return await HTTPClientWrapper<JobDTO>.Get(URI);


        }
    }
}
