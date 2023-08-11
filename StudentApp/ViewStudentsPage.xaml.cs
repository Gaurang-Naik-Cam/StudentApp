using StudentApp.Database;
using StudentApp.Models;

namespace StudentApp;

public partial class ViewStudents : ContentPage
{
	public ViewStudents()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        listView.ItemsSource = await database.GetStudentsAsync();
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Students()
        {
            BindingContext = new Student()
        });
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new Students()
            {
                BindingContext = e.SelectedItem as Student
            });
        }
    }
}