class Program
{
    static void Main(string[] args)
    {
        IRepository<User> userRepository = new Repository<User>();
        IRepository<Song> songRepository = new Repository<Song>();
        UserService userService = new UserService(userRepository);
        PlaylistService playlistService = new PlaylistService(userRepository, songRepository);
        SongService songService = new SongService(songRepository, playlistService);
        Song song1 = new Song(1, "Imagine", "John Lennon", "Rock");
        Song song2 = new Song(2, "Billie Jean", "Michael Jackson", "Pop");
        Song song3 = new Song(3, "Smells Like Teen Spirit", "Nirvana", "Grunge");
        User user = new User(1, "Alice");

        songService.AddSong(song1);
        songService.AddSong(song2);
        songService.AddSong(song3);

        userService.AddUser(user);

        

        // User Service Verification
        printAll(userService.GetAllUsers());

        userService.UpdateUser(new User(1, "Alice Smith"));
        userService.AddUser(new User(2, "Bob"));
        printAll(userService.GetAllUsers());

        User? user1 = userService.GetUserById(1);
        Console.WriteLine($"Finding user with id {1}: {user1?.Name}\n");

        userService.DeleteUser(2);
        printAll(userService.GetAllUsers());

        user1 = userService.GetUserById(2);
        Console.WriteLine($"Finding user with id {2}: {user1?.Name ?? "null"}");
        Console.WriteLine("============================\n");


        // Song Service Verification
        IEnumerable<Song> allSongs = songService.GetAllSongs();
        printAll(allSongs);

        songService.UpdateSong(new Song(1, "Radioactive", "Imagine Dragons", "Rock"));
        songService.AddSong(new Song(4, "Bohemian Rhapsody", "Queen", "Rock"));
        printAll(songService.GetAllSongs());

        Song? song = songService.GetSongById(1);
        Console.WriteLine($"Finding song with id {1}: {song?.Title}\n");

        songService.DeleteSong(4);
        printAll(songService.GetAllSongs());

        song = songService.GetSongById(4);
        Console.WriteLine($"Finding song with id {4}: {song?.Title ?? "null"}");
        Console.WriteLine("============================\n");



        // PlayList Service Verification
        playlistService.AddSongToPlaylist(user.Id, song1.Id);
        playlistService.AddSongToPlaylist(user.Id, song2.Id);
        playlistService.AddSongToPlaylist(user.Id, song3.Id);

        List<Song> alicesPlaylist = playlistService.GetUserPlaylist(user.Id);
        printPlaylist(user.Name, alicesPlaylist);

        playlistService.RemoveSongFromPlaylist(user.Id, song2.Id);
        // songService.DeleteSong(song2.Id);

        alicesPlaylist = playlistService.GetUserPlaylist(user.Id);
        printPlaylist(user.Name, alicesPlaylist);
    }

    static void printPlaylist(string userName, List<Song> playlist)
    {
        Console.WriteLine($"{userName}'s Playlist:");
        foreach (Song song in playlist)
        {
            Console.WriteLine($"- '{song.Title}' by {song.Artist}");
        }
        Console.WriteLine();
    }

    static void printAll(IEnumerable<Entity> entities)
    {
        Console.WriteLine($"All {entities.First().GetType().Name}s:");
        foreach (Entity entity in entities)
        {
            Console.WriteLine($"- {entity}");
        }
        Console.WriteLine();
    }
}