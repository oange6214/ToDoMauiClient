using System.Diagnostics;
using ToDoMauiClient.DataServices;
using ToDoMauiClient.MVVM.Models;

namespace ToDoMauiClient.MVVM.Pages;

[QueryProperty(nameof(ToDo), "ToDo")]
public partial class ManageToDoPage : ContentPage
{
    private readonly IRestDataService _dataService;
    private ToDo _toDo;
    private bool _isNew;

    public ToDo ToDo
    {
        get => _toDo;
        set 
        { 
            _isNew = IsNew(value);
            _toDo = value;
            OnPropertyChanged();
        }
    }

    public ManageToDoPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;
        BindingContext = this;
    }

    bool IsNew(ToDo toDo)
    {
        if (toDo.Id == 0)
            return true;
        return false;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            Debug.WriteLine("---> Add new Item");
            await _dataService.AddToDoAsync(ToDo);
        }
        else
        {
            Debug.WriteLine("---> Update an Item");
            await _dataService.UpdateToDoAsync(ToDo);
        }

        await Shell.Current.GoToAsync("..");
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataService.DeleteToDoAsync(_toDo.Id);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}