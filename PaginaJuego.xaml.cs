using Microsoft.Maui.Controls;
using System.Reflection.Metadata.Ecma335;

namespace juego;

public partial class PaginaJuego : ContentPage
{
    string answer = "";
    string question = "";
    string image = "";
    string possible = "";
    string respuestaSeleccionada;
    
    int random;
    string message = "Inicio";
    double progress = 0;
    int correctas;
    int intentos = 0;

    bool gano =false;
    bool perdio = false;    

    
    
	public PaginaJuego()
	{

		InitializeComponent();
        generarPreguntaYRespuesta();
        BindingContext = this;
        StartLoading();
        asignarRespuestasABotones();
        
	}

    async void StartLoading()
    {
        new Thread(() =>
        {
            for (progress = 0; progress <= 1.0; progress += 0.1)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    progressBar.Progress = progress;
                    segundero.Text = Math.Round(progress * 10).ToString();

                    if(progress >= 1.0)
                    {
                        respuestaIncorrecta();
                    }

                });

                Thread.Sleep(1000);
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                BarEnd();
            });
        }).Start();
    }





    public void BarEnd()
    {
        StartLoading();
        generar4PosibleRespuesta();
        generarPreguntaYRespuesta();
        respuestaIncorrecta();
    }

    List<string> respuestas = new List<string>()
    {
        "BigSmoke",
        "Carl Jhonson",
        "Polasky",
        "Tempeny",
        "Michael de Santa",
        "Catalina",
        "Claude Speed",
        "Ryder",
        "Sweet",
        "Zero"
    };

    List<string> Preguntas = new List<string>()
    {
        "Quien traiciono a cj",
        "Quien es el protagonista",
        "Policia que estafa a cj",
        "Policia que muere",
        "Aparece en gta 5",
        "Cj se enamora de ella",
        "Es protagonista del gta 3",
        "Lo mata cj casi al final del juego",
        "Carnal del CJ",
        "Nos hace completar misiones en drone"
    };

    List<string> Imagen = new List<string>()
    {
        "bigsmoke.jpg",
        "cj.jpg",
        "pulasky.jpg",
        "tempeny.jpg",
        "michael.jpg",
        "catalina.jpg",
        "claude.jpg",
        "ryder.jpg",
        "sweet.jpg",
        "zero.jpg"
    };

    List<string> PosiblesRespuestas = new List<string>()
    {
        "BigSmoke",
        "Carl Jhonson",
        "Polasky",
        "Tempeny",
        "Michael de Santa",
        "Catalina",
        "Claude Speed",
        "Ryder",
        "Sweet",
        "Zero"
    };


    public void asignarRespuestasABotones()
    {

        int indiceBotonCorrecto = new Random().Next(1,4);
        switch(indiceBotonCorrecto)
        {
            case 1: btn1.Text = answer;
                break;
            case 2: btn2.Text = answer;
                break;
            case 3: btn3.Text = answer;
                break;
            case 4: btn4.Text = answer;
                break;
        }
    }


    public void generarPreguntaYRespuesta() {
        random = new Random().Next(respuestas.Count);
        Answer = respuestas[random];
        Question = Preguntas[random];   
        Image = Imagen[random];
        generar4PosibleRespuesta();   
        eliminarRepetidos();
    }

    public void generar4PosibleRespuesta()
    {
        Button[] buttons = { btn1, btn2, btn3, btn4 };

        for (int i = 0; i < buttons.Length; i++)
        {
            int randomPossibbleIndex = new Random().Next(0, PosiblesRespuestas.Count);
            possible = PosiblesRespuestas[randomPossibbleIndex];
            buttons[i].Text = possible;
        }
        asignarRespuestasABotones();
    }



    public void eliminarRepetidos()
    {
        string respuestaAEliminar = respuestas[random];
        string imageAEliminar = Imagen[random];
        string questionAEliminar = Preguntas[random];
        string answerAEliminar = PosiblesRespuestas[random];
        string posibleAelminar = PosiblesRespuestas[random];

        foreach (string respuesta in respuestas.ToList())
        {
            if (respuesta == respuestaAEliminar)
            {
                respuestas.Remove(respuesta);
                break;
            }
        }

        foreach(string imageB in Imagen.ToList())
        {
            if(imageB == imageAEliminar)
            {
                Imagen.Remove(imageB);
                break;
            }
        }
        foreach(string questionB in Preguntas.ToList())
        {
            if(questionB == questionAEliminar)
            {
                Preguntas.Remove(questionB);
                break;
            }
        }
        foreach(string posibleB in PosiblesRespuestas.ToList() )
        {
            if(posibleB == posibleAelminar)
            {
                PosiblesRespuestas.Remove(posibleB);
                break;
            }
        }



    }


    public string Image
    {
        get => image;
        set
        {
            image = value;
            OnPropertyChanged();
        }
    }
    

    public string Answer
    {
        get => answer;
        set
        {
            answer = value;
            OnPropertyChanged();

        }
    }

    public string Question
    {
        get => question;
        set
        {
            question = value;
            OnPropertyChanged();
        }
    }

    public string Possible
    {
        get => possible;
        set
        {
            possible = value;
            OnPropertyChanged();

        }
    }

    
    


    public void verificarRespuesta()
    {
        progress = 0;
        intentos++;

        if (respuestaSeleccionada == answer)
        {
            respuestaCorrecta();
        }
        else
        {
            respuestaIncorrecta();
        }
        generarPreguntaYRespuesta();
        generar4PosibleRespuesta(); 

    }

    public void respuestaCorrecta()
    {
        correctas++;
        lblCorrectoIncorrecto.Text = "Correcto";

        if(correctas == 3)
        {
            lblCorrectoIncorrecto.Text = "Ganaste";
            gano = true;
            terminarJuego();
        }
    }

    public void respuestaIncorrecta()
    {
        lblCorrectoIncorrecto.Text = "Error";
        vidaslbl.Text= "Intentos: " + intentos.ToString();
        if (intentos == 5)
        {
            lblCorrectoIncorrecto.Text = "Perdiste";
            perdio = true;
            terminarJuego(); 
        }
        
    }

    public void terminarJuego()
    {
        if(gano == true)
        {
            Application.Current.OpenWindow(new Window(new WinPage()));

            var window = GetParentWindow();

            if (window != null)
            {
                Application.Current.CloseWindow(window);
            }
        }
        else if(perdio == true) 
        {
            Application.Current.OpenWindow(new Window(new LosePage()));

            var window = GetParentWindow();

            if (window != null)
            {
                Application.Current.CloseWindow(window);
            }
        }
    }

    public void reiniciarJuego()
    {
        
    }



    private void btn1_Clicked(object sender, EventArgs e)
    {
        respuestaSeleccionada = btn1.Text;
        verificarRespuesta();
    }

    private void btn2_Clicked(object sender, EventArgs e)
    {
        respuestaSeleccionada = btn2.Text;
        verificarRespuesta();
    }

    private void btn3_Clicked(object sender, EventArgs e)
    {
        respuestaSeleccionada=btn3.Text;
        verificarRespuesta();
    }

    private void btn4_Clicked(object sender, EventArgs e)
    {
        respuestaSeleccionada= btn4.Text;
        verificarRespuesta();
    }

    private void btnback_Clicked(object sender, EventArgs e)
    {
        Application.Current.OpenWindow(new Window(new MainPage()));

        var window = GetParentWindow();

        if (window != null)
        {
            Application.Current.CloseWindow(window);
        }
    }
}