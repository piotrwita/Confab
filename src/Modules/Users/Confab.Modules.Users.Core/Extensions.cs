﻿using System.Runtime.CompilerServices;
using Confab.Modules.Users.Core.DAL;
using Confab.Modules.Users.Core.DAL.Repositories;
using Confab.Modules.Users.Core.Entities;
using Confab.Modules.Users.Core.Repositories;
using Confab.Modules.Users.Core.Services;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Confab.Modules.Users.Api")]
namespace Confab.Modules.Speakers.Core;
internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
        => services
            //.AddSingleton<IUserRepository, InMemoryUserRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddTransient<IIdentityService, IdentityService>()
            .AddPostgres<UsersDbContext>();
}
