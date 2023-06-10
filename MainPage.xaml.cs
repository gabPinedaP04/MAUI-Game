namespace juego;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		Console.WriteLine("negros");
	}

    private void btn_iniciar_Clicked(object sender, EventArgs e)
    {
		Application.Current.OpenWindow(new Window(new PaginaJuego()));

		var window = GetParentWindow();

		if(window != null)
		{
			Application.Current.CloseWindow(window);
		}




    }

	


}

