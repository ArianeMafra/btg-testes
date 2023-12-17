
using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;

namespace btg_test.PlaylistSongsTest
{
    public class PlaylistServiceTest
    {
        private readonly IPlaylistValidationService _mockPlaylistValidationService;
        private readonly PlaylistService _service;


        public PlaylistServiceTest()
        {
            _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
            _service = new(_mockPlaylistValidationService);
        }

        [Fact]
        public void AddSongToPlaylist_ReceiveValidSong_ReturnTrue()
        {
            // Arrange
            Song song = new Song { 
                Title = "Yellow", Artist = "Coldplay",           
            };
            
            Playlist playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 50 };           

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song).Returns(true);

            // Act
            bool result = _service.AddSongToPlaylist(playlist, song);

            // Assert
            result.Should().BeTrue();
            playlist.Songs.Should().Contain(song);
            _mockPlaylistValidationService.Received(1).CanAddSongToPlaylist(playlist, song);
        }

        [Fact]
        public void AddSongToPlaylist_ReceiveInvalidSong_ReturnFalse()
        {
            // Arrange
            Song song = new Song
            {
                Title = "Yellow",
                Artist = "Coldplay",
            };

            Playlist playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 50 };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song).Returns(false);

            // Act
            bool result = _service.AddSongToPlaylist(playlist, song);

            // Assert
            result.Should().BeFalse();
            playlist.Songs.Should().NotContain(song);
            _mockPlaylistValidationService.Received(1).CanAddSongToPlaylist(playlist, song);
        }

        [Fact]
        public void AddSongToPlaylist_ReceiveAValidListOfSongs_ReturnTrue()
        {
            // Arrange
            Playlist playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 50 };
            List<Song> songs = new List<Song>
            {
                new Song {Title = "Yellow", Artist = "Coldplay" },
                new Song {Title = "Angela", Artist = "The Lumineers" }
            };                     

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(true);

            // Act
            _service.AddSongsToPlaylist(playlist, songs);

            // Assert
            playlist.Songs.Should().Contain(songs);
            _mockPlaylistValidationService.Received(2).CanAddSongToPlaylist(playlist, Arg.Any<Song>());                 
        }

        [Fact]
        public void AddSongToPlaylist_ReceiveAInvalidListOfSongs_ReturnTrue()
        {
            // Arrange
            Playlist playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 50 };
            List<Song> songs = new List<Song>
            {
                new Song {Title = "Yellow", Artist = "Coldplay" },
                new Song {Title = "Angela", Artist = "The Lumineers" }
            };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(false);

            // Act
            _service.AddSongsToPlaylist(playlist, songs);

            // Assert
            playlist.Songs.Should().NotContain(songs);
            _mockPlaylistValidationService.Received(2).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
        }
    }
}
