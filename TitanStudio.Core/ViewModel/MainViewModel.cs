using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TitanStudio.Core.Interfaces;

namespace TitanStudio.Core.ViewModel;
public partial class MainViewModel : ObservableObject, IMainViewModel
{
    private readonly ILogger<MainViewModel> _logger;

    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(IServiceProvider serviceProvider, ILogger<MainViewModel> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;

        LaunchMatchRulesEditor();
    }

    [RelayCommand]
    public void Test()
    {
        _logger.LogInformation("TEST");
    }


    [RelayCommand]
    public void LaunchMatchRulesEditor()
    {
      //  var view = _serviceProvider.GetRequiredService<MatchRulesEditorView>();   
    }
}
