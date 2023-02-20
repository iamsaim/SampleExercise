using People.Application.Context;
using People.Domain.Entity;

namespace People.Api.Seed
{
    public static class SeedContext
    {
        public static IServiceCollection Seed(this IServiceCollection services)
        {

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetService<ApplicationContext>();

                SeedData(applicationDbContext);
            }
            return services;
        }

        private static void SeedData(ApplicationContext context)
        {
            context.People.Add(new PersonEntity
            {
                PersonId = Guid.NewGuid(),
                JobProfileId = Guid.Parse("9a32346c-562d-4dfe-9a9a-e3e395ca949e"),
                FirstName = "Saim",
                LastName = "Sohail"
            });

            context.People.Add(new PersonEntity
            {
                PersonId = Guid.NewGuid(),
                JobProfileId  = Guid.Parse("69e072aa-af26-408f-8947-99e45bb1c987"),
                FirstName = "John",
                LastName = "Smith"
            });

            context.SaveChanges();
        }
    }
}
