using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TitanStudio.Wpf.Controls;

public partial class NumericUpDown : UserControl
{
    public NumericUpDown() // Constructor should have a different name
    {
        InitializeComponent();
    }

    // Dependency Property for Value
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(int), typeof(NumericUpDown),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, Math.Max(Minimum, Math.Min(Maximum, value))); // Clamping
    }

    // Dependency Property for Minimum
    public static readonly DependencyProperty MinimumProperty =
        DependencyProperty.Register(nameof(Minimum), typeof(int), typeof(NumericUpDown), new PropertyMetadata(int.MinValue));

    public int Minimum
    {
        get => (int)GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    // Dependency Property for Maximum
    public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register(nameof(Maximum), typeof(int), typeof(NumericUpDown), new PropertyMetadata(int.MaxValue));

    public int Maximum
    {
        get => (int)GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    // Dependency Property for Increment
    public static readonly DependencyProperty IncrementProperty =
        DependencyProperty.Register(nameof(Increment), typeof(int), typeof(NumericUpDown), new PropertyMetadata(1));

    public int Increment
    {
        get => (int)GetValue(IncrementProperty);
        set => SetValue(IncrementProperty, value);
    }

    // Increase Value
    private void IncreaseValue(object sender, RoutedEventArgs e)
    {
        Value += Increment;
    }

    // Decrease Value
    private void DecreaseValue(object sender, RoutedEventArgs e)
    {
        Value -= Increment;
    }

    // Allow only numeric input
    private void NumberOnly(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !int.TryParse(e.Text, out _);
    }
}
