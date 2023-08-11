using StudentApp.Models;
using StudentApp.Database;
using Java.Lang;

namespace StudentApp;

public partial class Students : ContentPage
{    //List<Course> _totalCourses
    //{
    //    get
    //    {
    //        StudentAppDatabase database = await StudentAppDatabase.Instance;
    //        return database.GetCoursesAsync().Result;
    //       // return _totalCourses;
    //    }
    //}

	public Students()
	{
		InitializeComponent();
        //pcrCourses.ItemsSource = _totalCourses;
    }



    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var _student = new Student();
        _student.Name = txtbxName.Text;
        _student.StudentNumber = txtbxStudentNumber.Text;
        _student.Address = txtbxStudentAddress.Text;
        _student.CourseName = lblSelectedItem.Text;
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        await database.SaveStudentAsync(_student);
        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var _student = new Student();
        _student.Name = txtbxName.Text;
        _student.StudentNumber = txtbxStudentNumber.Text;
        _student.Address = txtbxStudentAddress.Text;
        _student.CourseName = lblSelectedItem.Text;
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        await database.DeleteStudentAsync(_student);
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}