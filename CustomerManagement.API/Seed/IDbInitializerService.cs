namespace CustomerManagement.API.Seed
{
    public interface IDbInitializerService
    {
        Task SeedRoleAndUserAsync();

        Task SeedCustomersAsync();
    }
}
