using System.Windows.Input;

internal class RelayCommand<T> : ICommand
{
    private Action<string> selectCampus;

    public RelayCommand(Action<string> selectCampus)
    {
        this.selectCampus = selectCampus;
    }
}