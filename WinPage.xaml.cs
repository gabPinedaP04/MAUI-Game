namespace juego;

public partial class WinPage : ContentPage
{
	public WinPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void regresarMain_Clicked(object sender, EventArgs e)
    {
        Application.Current.OpenWindow(new Window(new MainPage()));

        var window = GetParentWindow();

        if (window != null)
        {
            Application.Current.CloseWindow(window);
        }
    }
}