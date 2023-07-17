using System.Diagnostics;
using ToDoMauiClient.DataServices;
using ToDoMauiClient.MVVM.Models;
using ToDoMauiClient.MVVM.Pages;

namespace ToDoMauiClient;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _dataService;
    int count = 0;

	public MainPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        collectionView.ItemsSource = await _dataService.GetAllToDosAsync();
    }

    async void OnAddToDoClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("---> Add button clicked!");

        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(ToDo), new ToDo() }
        }; 

        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
    }

    async void OnSelecteionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("---> Item changed clicked!");

        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(ToDo), e.CurrentSelection.FirstOrDefault() as ToDo }
        };

        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
    }

}

