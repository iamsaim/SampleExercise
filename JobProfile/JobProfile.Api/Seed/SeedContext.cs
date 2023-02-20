using JobProfile.Application.Context;
using JobProfile.Domain.Entity;

namespace JobProfile.Api.Seed
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
            context.Jobs.Add(new JobEntity
            {
                JobProfileId = Guid.Parse("9a32346c-562d-4dfe-9a9a-e3e395ca949e"),
                JobTitle = "Manager",
                JobDescription = "Manage the team",
                JobLocation = "World Wide"
            });

            context.Jobs.Add(new JobEntity
            {
                JobProfileId = Guid.Parse("69e072aa-af26-408f-8947-99e45bb1c987"),
                JobTitle = "Dev",
                JobDescription = "Code the requirement",
                JobLocation = "World Wide"
            });

            context.Jobs.Add(new JobEntity
            {
                JobProfileId = Guid.NewGuid(),
                JobTitle = "QA",
                JobDescription = "Test the requirement",
                JobLocation = "World Wide"
            });

            context.Jobs.Add(new JobEntity
            {
                JobProfileId = Guid.NewGuid(),
                JobTitle = "BA",
                JobDescription = "Gather the requirement",
                JobLocation = "World Wide"
            });

            context.SaveChanges();
        }
    }
}
