using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Infrastructure;
using Ninject.Planning.Bindings;
using services.Infrastructure;
using services.Services;
using services.ViewModels;
using Xunit;

namespace services.test
{
    public class AugmentationTests
    {
        private readonly UberService _sut;

        public AugmentationTests()
        {
            
            var container = new Ninject.StandardKernel();
            
            container.Bind(x => 
                x.FromAssemblyContaining(typeof(IAugmentViewModels))
                    .SelectAllClasses()
                    .InheritedFrom<IAugmentViewModels>()
                    .BindAllInterfaces()
                    );

            var services = container.GetAll<IAugmentViewModels>();

            _sut = new UberService(services);
        }

        [Theory]
        [InlineData("Carly Rae Jepsen")]
        [InlineData("Lou Bega")]
        public void ArtistWithNoExtras(string name)
        {
            var vm = new Artist()
            {
                Name = name
            };
            _sut.Augment(vm);

            Assert.Equal(name, vm.Name);
        }

        [Theory]
        [InlineData("Carly Rae Jepsen", "Canada")]
        [InlineData("Lou Bega", "Germany")]
        public void ArtistAndCountry(string name, string expectedCountry)
        {
            var vm = new ArtistAndCountry()
            {
                Name = name
            };
            _sut.Augment(vm);

            Assert.Equal(name, vm.Name);
            Assert.Equal(expectedCountry, vm.Country);
        }

        [Theory]
        [InlineData("Carly Rae Jepsen", "https://www.youtube.com/watch?v=fWNaR-rxAic")]
        [InlineData("Lou Bega", "https://www.youtube.com/watch?v=EK_LN3XEcnw")]
        public void CarlyAndVideo(string name, string expectedVideo)
        {
            var vm = new ArtistAndVideo()
            {
                Name = name
            };
            _sut.Augment(vm);

            Assert.Equal(name, vm.Name);
            Assert.Equal(expectedVideo, vm.YoutubeLink);
        }

        [Theory]
        [InlineData("Carly Rae Jepsen", "Canada", "https://www.youtube.com/watch?v=fWNaR-rxAic")]
        [InlineData("Lou Bega", "Germany", "https://www.youtube.com/watch?v=EK_LN3XEcnw")]
        public void CarlyAndCountryAndVideo(string name, string expectedCountry, string expectedVideo)
        {
            var vm = new ArtistAndCountryAndVideo()
            {
                Name = name
            };
            _sut.Augment(vm);

            Assert.Equal(name, vm.Name);
            Assert.Equal(expectedCountry, vm.Country);
            Assert.Equal(expectedVideo, vm.YoutubeLink);
        }

    }
}
