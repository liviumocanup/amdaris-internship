public class PlaylistService
{
    private IRepository<User> _userRepository;
    private IRepository<Song> _songRepository;

    public PlaylistService(IRepository<User> userRepository, IRepository<Song> songRepository)
    {
        _userRepository = userRepository;
        _songRepository = songRepository;
    }

    public void RemoveSongFromAllPlaylists(int songId)
    {
        List<User> allUsers = _userRepository.GetAll().ToList();
        List<User> usersWithSong = new List<User>();

        foreach (User user in allUsers)
        {
            if (user.Playlist.Any(s => s.Id == songId))
            {
                usersWithSong.Add(user);
            }
        }

        foreach (User user in usersWithSong)
        {
            user.Playlist.RemoveAll(s => s.Id == songId);
            _userRepository.Update(user);
        }
    }


    public void AddSongToPlaylist(int userId, int songId)
    {
        User? user = _userRepository.GetById(userId);
        Song? song = _songRepository.GetById(songId);

        if (user != null && song != null)
        {
            if (!user.Playlist.Any(s => s.Id == song.Id))
            {
                user.Playlist.Add(song);
                _userRepository.Update(user);
            }
        }
    }

    public void RemoveSongFromPlaylist(int userId, int songId)
    {
        User? user = _userRepository.GetById(userId);

        if (user != null)
        {
            Song? song = user.Playlist.FirstOrDefault(s => s.Id == songId);
            if (song != null)
            {
                user.Playlist.Remove(song);
                _userRepository.Update(user);
            }
        }
    }

    public List<Song> GetUserPlaylist(int userId)
    {
        User? user = _userRepository.GetById(userId);
        return user?.Playlist ?? [];
    }
}
