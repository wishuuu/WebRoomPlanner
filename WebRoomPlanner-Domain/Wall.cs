using System;
using System.Collections.Generic;
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

namespace WebRoomPlanner_Domain;

public enum WallOrientation
{
    horizontal,
    vertical,
    diagonal
}

public class Wall
{
    public float length { get; set; }
    public WallOrientation orientation { get; set; }
    private float _angle { get; set; }
    public float angle { get; set; } // TODO return based on orientation
    public Door door;
}