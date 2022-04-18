using System;
using System.Collections.Generic;
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

namespace WebRoomPlanner_Domain;

public class Door : FurnitureObjectBase
{
    public FurnitureObjectBase baseObject { get; set; }
    public float distanceFromCorner { get; set; }
}