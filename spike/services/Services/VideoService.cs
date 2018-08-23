using services.Infrastructure;

namespace services.Services
{
    public class VideoService : ViewModelProviderBase<IAugmentArtistWithVideo>
    {
        protected override void PopulateModel(IAugmentArtistWithVideo viewModel)
        {
            if (viewModel.Name == "Carly Rae Jepsen")
            {
                viewModel.YoutubeLink = "https://www.youtube.com/watch?v=fWNaR-rxAic";
            }
            if (viewModel.Name == "Lou Bega")
            {
                viewModel.YoutubeLink = "https://www.youtube.com/watch?v=EK_LN3XEcnw";
            }
        }
    }
}