namespace juego;

public partial class LosePage : ContentPage
{
	public LosePage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.OpenWindow(new Window(new MainPage()));

        var window = GetParentWindow();

        if (window != null)
        {
            Application.Current.CloseWindow(window);
        }
    }
}