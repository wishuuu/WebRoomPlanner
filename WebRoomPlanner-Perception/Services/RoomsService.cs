using System;
using System.Threading.Tasks;
using WebRoomPlanner_Domain;
using System.Collections.Generic;
using MongoDB.Driver;


namespace WebRoomPlanner_Perception.Services;

public class RoomsService
{
    private readonly IMongoCollection<Room> _rooms;

    public RoomsService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _rooms = database.GetCollection<Room>(settings.RoomsCollectionName);
    }

    public int GetNextId()
    {
        try
        {
            return (_rooms.Find(s => true).SortByDescending(u => u.id).First().id) + 1;
        }
        catch (Exception)
        {
            return 1;
        }
    }
}