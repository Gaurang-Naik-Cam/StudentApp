using StudentApp.Models;
using StudentApp.Database;

namespace StudentApp;

public partial class Courses : ContentPage
{
	public Courses()
	{
		InitializeComponent();
	}

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var _course = new Course();
        _course.CourseName = txtbxCourseName.Text;
        _course.CourseCode = txtbxCourseCode.Text;
        _course.CourseCoordinator = txtbxCourseCoordinator.Text;
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        await database.SaveCourseAsync(_course);
        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var _course = new Course();
        _course.CourseName = txtbxCourseName.Text;
        _course.CourseCode = txtbxCourseCode.Text;
        _course.CourseCoordinator = txtbxCourseCoordinator.Text;
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        await database.DeleteCourseAsync(_course);
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}