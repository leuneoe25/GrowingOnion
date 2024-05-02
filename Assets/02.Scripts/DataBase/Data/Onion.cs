using SQLite4Unity3d;


public class Onion
{
    [PrimaryKey]
    public int Id { get; set; }
    public string OnionName { get; set; }
    public string OnionImagePath { get; set; }
    public string Desc { get; set; }
    public int FirstPointValue { get; set; }
    public int RePointValue { get; set; }

    public override string ToString()
    {
        return string.Format("[Onion: Id={0}, Name={1}]", Id, OnionName);
    }
}
