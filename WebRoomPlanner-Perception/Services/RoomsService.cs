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

    public async Task<List<Room>> getRooms()
    {
        return (await _rooms.FindAsync(r => 1 == 1)).ToList();
    }

    public async Task<Room> getRoom(int id)
    {
        try
        {
            return (await _rooms.FindAsync(r => r.id == id)).First();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); // TODO Log exception
            throw;
        }
    }

    public async Task<Room> insertRoom(Room room)
    {
        try
        {
            room.id = GetNextId(); 
            await _rooms.InsertOneAsync(room);
            return room;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}