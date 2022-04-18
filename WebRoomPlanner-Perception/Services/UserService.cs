using System;
using System.Threading.Tasks;
using WebRoomPlanner_Domain;
using System.Collections.Generic;
using MongoDB.Driver;


namespace WebRoomPlanner_Perception.Services;

public class UserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _users = database.GetCollection<User>(settings.UsersCollectionName);
    }
    
    public int GetNextId()
    {
        try
        {
            return (_users.Find(s => true).SortByDescending(u => u.id).First().id) + 1;
        }
        catch (Exception)
        {
            return 1;
        }
    }
}