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

    public async Task<List<FurnitureObjectBase>> getObjects()
    {
        return (await _objects.FindAsync(_ => true)).ToList();
    }

    public async Task<FurnitureObjectBase> getObject(int id)
    {
        try
        {
            return (await _objects.FindAsync(o => o.id == id)).First();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<FurnitureObjectBase>> getByType(BaseFurnitureObjectType type)
    {
        return (await _objects.FindAsync(o => o.objectType == type)).ToList();
    }

    public async Task<FurnitureObjectBase> insertObject(FurnitureObjectBase objectBase)
    {
        try
        {
            objectBase.id = GetNextId();
            await _objects.InsertOneAsync(objectBase);
            return objectBase;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}