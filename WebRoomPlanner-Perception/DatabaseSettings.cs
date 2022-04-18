namespace WebRoomPlanner_Perception;

public class DatabaseSettings : IDatabaseSettings
{
    public string UsersCollectionName { get; set; }
    public string RoomsCollectionName { get; set; }
    public string BaseObjectsCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}

public interface IDatabaseSettings
{
    string UsersCollectionName { get; set; }
    string RoomsCollectionName { get; set; }
    string BaseObjectsCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}