using Confab.Modules.Users.Core.Entities;

namespace Confab.Modules.Users.Core.Repositories;

internal class InMemoryUserRepository : IUserRepository
{ 
    private readonly List<User> _users = new();

    public Task<User> GetAsync(Guid id) => Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

    public Task<User> GetAsync(string email) => Task.FromResult(_users.SingleOrDefault(x => x.Email == email)); 

    public Task AddAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(User user)
    {
        return Task.CompletedTask;
    } 
}
