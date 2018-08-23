using services.Services;

namespace services.ViewModels
{
    public class ArtistAndVideo : IAugmentArtistWithVideo
    {
        public string Name { get; set; }

        public string YoutubeLink { get; set; }
    }
}