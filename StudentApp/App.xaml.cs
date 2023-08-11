namespace StudentApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

  //  protected override Window CreateWindow(IActivationState activationState)
  //  {
  //     Window window = base.CreateWindow(activationState);
		//window.Created += (sender, eventArgs) =>
		//{
			
		//}
  //  }
}
