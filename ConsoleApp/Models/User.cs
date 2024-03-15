public class User : Entity
{
    public string Name { get; set; }
    public List<Song> Playlist { get; set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
        Playlist = new List<Song>();
    }

    public override string ToString()
    {
        return Name;
    }
}
