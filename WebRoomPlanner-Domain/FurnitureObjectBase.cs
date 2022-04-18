using System;
using System.Collections.Generic;
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

namespace WebRoomPlanner_Domain;

public enum BaseFurnitureObjectType
{
    bed,
    desk,
    standingLamp,
    roofLamp,
    door
}

public class FurnitureObjectBase
{
    public int id { get; set; }
    public float baseWidth { get; set; }
    public float baseHeight { get; set; }
    public float maxWidth { get; set; }
    public float maxHeight { get; set; }
    public BaseFurnitureObjectType objectType { get; set; }
}