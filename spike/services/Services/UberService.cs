using System.Collections.Generic;
using services.Infrastructure;

namespace services.Services
{
    public class UberService
    {
        private readonly IEnumerable<IAugmentViewModels> _viewModelServices;

        public UberService(IEnumerable<IAugmentViewModels> viewModelServices)
        {
            _viewModelServices = viewModelServices;
        }
        public void Augment(object viewModel)
        {
            foreach (var viewModelService in _viewModelServices)
            {
                viewModelService.Augment(viewModel);
            }
        }
    }
}
