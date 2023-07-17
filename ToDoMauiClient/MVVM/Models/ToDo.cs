using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoMauiClient.MVVM.Models;

public class ToDo : INotifyPropertyChanged
{
	private int _id;

	public int Id
	{
		get => _id;

        set 
		{ 
			if (_id == value) 
				return;
			_id = value;
			OnPropertyChanged();
        }
	}

	private string _toDoName;

	public string ToDoName
    {
		get => _toDoName;
        set 
		{ 
            if (_toDoName == value)
                return;
            _toDoName = value;
            OnPropertyChanged();
        }
	}


	public event PropertyChangedEventHandler PropertyChanged;
	private void OnPropertyChanged([CallerMemberName] string propName = null)
	{
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
