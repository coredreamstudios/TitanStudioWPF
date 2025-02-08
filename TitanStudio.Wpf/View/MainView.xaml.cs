using System.Windows;
using TitanStudio.Core.Interfaces;

namespace TitanStudio.Wpf.View;

public partial class MainView : Window
{
    public MainView(IMainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
