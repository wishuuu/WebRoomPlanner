using System;
using System.Collections.Generic;
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

namespace WebRoomPlanner_Domain;

public class FurnitureObject : FurnitureObjectBase
{
    public int id { get; set; }
    public float width { get; set; }
    public float height { get; set; }
}