public class SongService
{
    private IRepository<Song> _songRepository;
    private PlaylistService _playlistService;

    public SongService(IRepository<Song> songRepository, PlaylistService playlistService)
    {
        _songRepository = songRepository;
        _playlistService = playlistService;
    }

    public void AddSong(Song song)
    {
        _songRepository.Add(song);
    }

    public void DeleteSong(int songId)
    {
        Song? song = _songRepository.GetById(songId);
        if (song != null)
        {
            // Remove the song from all users' playlists
            _playlistService.RemoveSongFromAllPlaylists(songId);

            // Delete the song from the repository
            _songRepository.Delete(song);
        }
    }

    public IEnumerable<Song> GetAllSongs()
    {
        return _songRepository.GetAll();
    }

    public Song? GetSongById(int songId)
    {
        return _songRepository.GetById(songId);
    }

    public void UpdateSong(Song song)
    {
        _songRepository.Update(song);
    }
}