using services.Services;

namespace services.ViewModels
{
    public class ArtistAndCountry : IAugmentArtistWithCountry
    {
        public string Name { get; set; }

        public string Country { get; set; }
    }
}