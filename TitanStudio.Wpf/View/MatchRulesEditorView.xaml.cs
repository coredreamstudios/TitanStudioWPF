using System.Windows;
using TitanStudio.Core.Interfaces;

namespace TitanStudio.Wpf.View;

public partial class MatchRulesEditorView : Window
{
    public MatchRulesEditorView(IMatchRulesEditorViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
