using services.Services;

namespace services.ViewModels
{
    public class ArtistAndCountryAndVideo : IAugmentArtistWithCountry, IAugmentArtistWithVideo
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string YoutubeLink { get; set; }
    }
}