using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace basedatosazure
{
    public class ASIGNADO : ContentPage
    {
        public ASIGNADO()
        {
            MobileServiceClient client;
            IMobileServiceTable<TodoItem> tabla;
            client = new MobileServiceClient(Constants.ApplicationURL);
            tabla = client.GetTable<TodoItem>();
            Dictionary<string, Color> res = new Dictionary<string, Color>
        {
            { "ivanelyga91@gmail.com", Color.Green},
            { "raidenvortex@hotmail.com", Color.Red }

        };

            Picker responsable = new Picker
            {
                Title = "RESPONSABLE",
                VerticalOptions = LayoutOptions.Center
            };
            foreach (string respon in res.Keys)
            {
                responsable.Items.Add(respon);
            }
            Button leer = new Button()
            {
                Text = "leer Tabla",
                HorizontalOptions = LayoutOptions.Center,


            };
            leer.HorizontalOptions = LayoutOptions.Center;
            leer.TextColor = Color.Black;
            leer.BackgroundColor = Color.White;
            Label mensaje1 = new Label();
            mensaje1.IsVisible = false;
            Label mensaje = new Label();
            Label mensaje01 = new Label();
            Label mensaje2 = new Label();
            ListView lista = new ListView();
            ListView lista1 = new ListView();
            ListView lista2 = new ListView();
            leer.Clicked += async (sender, args) =>
            {
                if (responsable.SelectedIndex == -1)
                {
                    await DisplayAlert("No a seleccionado ningun asignado por favor verifique", "", "Ok");
                }
                else
                {

                    IEnumerable<TodoItem> items = await tabla.Where(TodoItem => TodoItem.Responsable ==responsable.Items[responsable.SelectedIndex] ).ToListAsync();
                    string[] arreglo = new string[items.Count()];
                    string[] arreglo1 = new string[items.Count()];
                    string[] arreglo2 = new string[items.Count()];
                    int i = 0;
                    foreach (var x in items)
                    {
                        mensaje.Text = "TAREA";
                        arreglo[i] = x.Tarea;
                        mensaje01.Text = "FECHA INICIO";
                        arreglo1[i] = x.Update;
                        mensaje2.Text = "FECHA FINAL";
                        arreglo2[i] = x.Fecha_Fin;
                        i++;
                    }
                    lista.ItemsSource = arreglo;
                    lista1.ItemsSource = arreglo1;
                    lista2.ItemsSource = arreglo2;
                    responsable.SelectedIndex = -1;
                }

            };

            Content = new StackLayout
            {
                Children = {
       responsable,
            leer,
               mensaje,
            lista,
               mensaje01,
            lista1,

                mensaje2,
            lista2,
                }
            };
        }
    }
}
