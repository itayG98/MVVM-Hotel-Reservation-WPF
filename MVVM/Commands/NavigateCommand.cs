using MVVM.Services;

namespace MVVM.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigateService;

        public NavigateCommand(NavigationService navigateService)
        {
            _navigateService = navigateService;
        }

        public override void Execute(object? parameter)
        {
            _navigateService.Navigate();
        }
    }
}
