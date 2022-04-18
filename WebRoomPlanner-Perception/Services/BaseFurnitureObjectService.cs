using System;
using System.Threading.Tasks;
using WebRoomPlanner_Domain;
using System.Collections.Generic;
using MongoDB.Driver;


namespace WebRoomPlanner_Perception.Services;

public class BaseFurnitureObjectService
{
    private readonly IMongoCollection<FurnitureObjectBase> _objects;

    public BaseFurnitureObjectService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        _objects = database.GetCollection<FurnitureObjectBase>(settings.BaseObjectsCollectionName);
    }

    public int GetNextId()
    {
        try
        {
            return (_objects.Find(s => true).SortByDescending(u => u.id).First().id) + 1;
        }
        catch (Exception)
        {
            return 1;
        }
    }
}