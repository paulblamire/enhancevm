namespace services.Infrastructure
{
    public abstract class ViewModelProviderBase<TSupportedInterface> : IAugmentViewModels
        where TSupportedInterface : class 
    {
        public void Augment(object viewModel)
        {
            TSupportedInterface typedViewModel = viewModel as TSupportedInterface;
            if (typedViewModel == null)
                return;
            PopulateModel(typedViewModel);
        }

        protected abstract void PopulateModel(TSupportedInterface viewModel);
    }
}