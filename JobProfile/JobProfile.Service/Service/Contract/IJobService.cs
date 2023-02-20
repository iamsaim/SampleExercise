using JobProfile.Service.DTO;


namespace JobProfile.Service.Service
{
    public interface IJobService
    {
        public IEnumerable<JobDTO> GetAllJob();
        public JobDTO GetJob(Guid Id);
        public void AddJob(JobDTO job);
    }
}
