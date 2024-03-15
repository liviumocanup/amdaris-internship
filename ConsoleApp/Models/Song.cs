public class Song : Entity
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }

    public Song(int id, string title, string artist, string genre)
    {
        Id = id;
        Title = title;
        Artist = artist;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"{Title} by {Artist}";
    }
}
