using services.Infrastructure;

namespace services.Services
{
    public class CountryService : ViewModelProviderBase<IAugmentArtistWithCountry>
    {
        protected override void PopulateModel(IAugmentArtistWithCountry viewModel)
        {
            if (viewModel.Name == "Carly Rae Jepsen")
            {
                viewModel.Country = "Canada";
            }
            if (viewModel.Name == "Lou Bega")
            {
                viewModel.Country = "Germany";
            }
        }
    }
}