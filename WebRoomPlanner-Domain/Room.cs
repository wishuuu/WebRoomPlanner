using System;
using System.Collections.Generic;
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

namespace WebRoomPlanner_Domain;

public class Room
{
    public int id { get; set; }
    public int userId { get; set; }
    public float width { get; set; }
    public float height { get; set; }
    public List<Wall> walls { get; set; }
    public List<FurnitureObject> objects { get; set; }
}