using StudentApp.Database;
using StudentApp.Models;

namespace StudentApp;

public partial class ViewCourses : ContentPage
{
	public ViewCourses()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        listView.ItemsSource = await database.GetCoursesAsync();
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Courses()
        {
            BindingContext = new Course()
        });
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new Courses()
            {
                BindingContext = e.SelectedItem as Course
            });
        }
    }
}