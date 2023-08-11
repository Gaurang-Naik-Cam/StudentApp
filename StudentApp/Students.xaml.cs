using StudentApp.Models;
using StudentApp.Database;
//using Java.Lang;

namespace StudentApp;

public partial class Students : ContentPage
{    
    
    List<string> _totalCourses { get;}

    public Students()
    {
        InitializeComponent();
        _totalCourses = new List<string>(); 
        //pcrCourses.ItemsSource = new List<string>() { " Test 1", "Test 2" };
        StudentAppDatabase studentAppDatabase = new StudentAppDatabase();
        var courses = studentAppDatabase.GetCoursesAsync().Result;
        foreach (var course in courses)
        {
            _totalCourses.Add(course.CourseName);
        }

        pcrCourses.ItemsSource = _totalCourses;
    }



    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var _student = (Student)BindingContext;//new Student();
        _student.CourseName = lblSelectedItem.Text;
        //_student.Name = txtbxName.Text;
        //_student.StudentNumber = txtbxStudentNumber.Text;
        //_student.Address = txtbxStudentAddress.Text;
        //_student.CourseName = lblSelectedItem.Text;
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        await database.SaveStudentAsync(_student);
        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        //var _student = new Student();
        //_student.Name = txtbxName.Text;
        //_student.StudentNumber = txtbxStudentNumber.Text;
        //_student.Address = txtbxStudentAddress.Text;
        //_student.CourseName = lblSelectedItem.Text;
        var _student = (Student)BindingContext;
        _student.CourseName = lblSelectedItem.Text;
        StudentAppDatabase database = await StudentAppDatabase.Instance;
        await database.DeleteStudentAsync(_student);
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnDropDownChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            lblSelectedItem.Text = (string)picker.ItemsSource[selectedIndex];
        }
        //await Navigation.PopAsync();
    }
}