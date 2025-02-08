using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TitanStudio.Core.Interfaces;
using TitanStudio.Core.Services;
using TitanStudio.Core.ViewModel;
using TitanStudio.Wpf.View;

namespace TitanStudio.Wpf;

public partial class App : Application
{
    private IServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = _serviceProvider.GetRequiredService<MatchRulesEditorView>();
        mainWindow.Show();
        
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Configure logging
        services.AddLogging();

        // Register Services
        services.AddSingleton<ITestService, TestService>();

        // Register ViewModels
        services.AddSingleton<IMainViewModel, MainViewModel>();
        services.AddSingleton<IMatchRulesEditorViewModel, MatchRulesEditorViewModel>();

        // Register Views
        services.AddTransient<MainView>();
        services.AddTransient<MatchRulesEditorView>();
    }

    private void OnExit(object sender, EventArgs e)
    {
        // Dispose of services if needed
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
