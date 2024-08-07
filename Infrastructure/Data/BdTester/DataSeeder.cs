namespace Continuum.Core.BdTester;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Continuum.Core.Entities;
using Continuum.Application.Interfaces;

public class DataSeeder
{
    private readonly IUserService _userService;

    public DataSeeder(IUserService userService)
    {
        _userService = userService;
    }

    public async Task SeedDataAsync(int numberOfUsers)
    {
        var users = new List<User>();

        for (int i = 1; i <= numberOfUsers; i++)
        {
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                Name = $"User {i}",
                Email = $"user{i}@example.com"
            });
        }

        foreach (var user in users)
        {
            await _userService.AddUserAsync(user);
        }
    }
}