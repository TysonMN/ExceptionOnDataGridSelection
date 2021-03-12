using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MyNamespace {
  public class Command : ICommand {
    private readonly Action _action;
    public Command(Action action) => _action = action;
    public event EventHandler CanExecuteChanged;
    public bool CanExecute(object _) => true;
    public void Execute(object _) => _action();
  }

  public partial class MainWindow : Window {
    public ICommand MyCommand { get; }
    public ObservableCollection<int> MyItems { get; } = new ObservableCollection<int>();
    public int? MySelectedItem {
      get => null;
      set { }
    }

    public MainWindow() {
      DataContext = this;
      MyCommand = new Command(() => MyItems.Add(1));
      InitializeComponent();
    }
  }
}