using People.Service.DTO;


namespace People.Service.Service
{
    public interface IPeopleService
    {
        public IEnumerable<PeopleDTO> GetPersons();
        public Task<PeopleDTO> GetPerson(Guid Id);
        public void AddPeople(PeopleDTO job);
    }
}
