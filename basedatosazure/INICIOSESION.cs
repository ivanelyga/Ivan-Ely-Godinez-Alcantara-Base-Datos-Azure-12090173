using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;


namespace basedatosazure
{
	public class App : Application
	{
        public App()
        {
            // The root page of your application
            Entry correo = new Entry()
            {
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                Placeholder = "Ingrese su correo Electronico",
                FontAttributes = FontAttributes.Italic,
            };

            Entry pass = new Entry()
            {
                Placeholder = "Ingrese su password",
                TextColor = Color.Black,
                IsPassword = true,
            };

            Label mensaje = new Label();

            Button login = new Button();
            login.Text = "Ingresar al sistema";
            ActivityIndicator falso = new ActivityIndicator();
            falso.IsVisible = false;
            login.Clicked += (sender, args) => {
                if (correo.Text == null && pass.Text == null)
                {
                    mensaje.TextColor = Color.Red;

                    mensaje.Text = "Una o las cajas estan vacias";

                }
                else
                {
                    if (correo.Text == "ivanelyga91@hotmail.com" && pass.Text == "ivanelyga04.")
                    {
                        mensaje.TextColor = Color.Green;
                        mensaje.Text = "Usuario identificado";
                        correo.Text = "";
                        pass.Text = "";
                        var tabs = new TabbedPage();

                        tabs.Children.Add(new Insertar { Title = "Inicio" });
                        tabs.Children.Add(new ConsultaParticular { Title = "CONSULTA POR SELECCION DE PRIORIDAD" });
                        tabs.Children.Add(new ASIGNADO { Title = "CONSULTA POR SELECCION DE ASIGNADO" });
                        tabs.Children.Add(new FECHAS { Title = "CONSULTA POR FECHA" });
                        tabs.Children.Add(new FECHAS { Title = "CONSULTA POR EL DIA HOY" });
                        MainPage = tabs;

                    }
                    else
                    {
                        if (correo.Text != "ivanelyga91@hotmail.com" || pass.Text != "ivanelyga04.")
                        {
                            ActivityIndicator indicador = new ActivityIndicator();
                            indicador.IsRunning = true;

                            mensaje.TextColor = Color.Red;
                            falso.IsVisible = true;
                            mensaje.Text = "No se encuentra en la base de datos:'(";
                            correo.Text = "";
                            pass.Text = "";

                        }
                    }
                }
            };

            var layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.Center;
            layout.Children.Add(correo);
            layout.Children.Add(pass);
            layout.Children.Add(mensaje);
            layout.Children.Add(falso);
            layout.Children.Add(login);
        

            MainPage = new ContentPage
            {
               
                Content = layout
            };


        }

   

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	}
}

