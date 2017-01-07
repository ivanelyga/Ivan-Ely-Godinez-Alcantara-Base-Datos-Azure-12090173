using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace basedatosazure
{
    public class Insertar : ContentPage
    {
        public Insertar()
        {
            MobileServiceClient client;
            IMobileServiceTable<TodoItem> tabla;
            client = new MobileServiceClient(Constants.ApplicationURL);
            tabla = client.GetTable<TodoItem>();
            Entry nombre1 = new Entry()
            {

                Placeholder="Tarea",
            };

            nombre1.BackgroundColor = Color.Black;
            nombre1.TextColor = Color.White;
            nombre1.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            nombre1.FontAttributes = FontAttributes.Italic;
            Entry descripcion = new Entry() {
                Placeholder = "Descripcion",
            };
           
            descripcion.BackgroundColor = Color.Black;
            descripcion.TextColor = Color.White;
            descripcion.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            descripcion.FontAttributes = FontAttributes.Italic;
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
            DatePicker datePicker = new DatePicker
            {

                VerticalOptions = LayoutOptions.Center
            };
            DatePicker Fecha_final = new DatePicker
            {

                VerticalOptions = LayoutOptions.Center
            };

            Dictionary<string, Color> habilitado = new Dictionary<string, Color>
        {
            { "false", Color.Green},
            { "true", Color.Red }

        };
            Picker status = new Picker
            {
                Title = "STATUS",
                VerticalOptions = LayoutOptions.Center
            };

            foreach (string colorName in habilitado.Keys)
            {
                status.Items.Add(colorName);
            }

            Dictionary<string, Color> PRIORIDAD = new Dictionary<string, Color>
        {
            { "BAJA", Color.Green},
            { "MEDIA", Color.Red },
                 { "ALTA", Color.Green},
            { "CRITICA", Color.Red }
        };
            Picker prioridad = new Picker
            {
                Title = "PRIORIDAD",
                VerticalOptions = LayoutOptions.Center
            };

            foreach (string colorPRIORIDAD in PRIORIDAD.Keys)
            {
                prioridad.Items.Add(colorPRIORIDAD);
            }
            Button enviar = new Button();
            enviar.Text = "Enviar Datos";
            enviar.HorizontalOptions = LayoutOptions.Center;
            enviar.TextColor = Color.Aqua;
            enviar.BackgroundColor = Color.Lime;
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
            mensaje.IsVisible = false;
            ListView lista = new ListView();
            ListView lista1 = new ListView();
            ListView lista2 = new ListView();
            leer.Clicked += async (sender, args) =>
            {

                IEnumerable<TodoItem> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo1 = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Tarea;
                    arreglo1[i] = x.Date;
                    arreglo2[i] = x.Fecha_Fin;
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista1.ItemsSource = arreglo1;
                lista2.ItemsSource = arreglo2;
            };

            enviar.Clicked += async (sender, args) =>
            {

                var datos = new TodoItem { Tarea = nombre1.Text, Estado = status.SelectedIndex.ToString(), Fecha_Fin = Fecha_final.Date.ToString("d/M/yyyy 23:59:59"), Prioridad = prioridad.Items[prioridad.SelectedIndex], Descripcion = descripcion.Text, Responsable = responsable.Items[responsable.SelectedIndex] };
                await tabla.InsertAsync(datos);
                await DisplayAlert("Insertado Correctamente", "Aviso", "OK");
                IEnumerable<TodoItem> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo1 = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Tarea;
                    arreglo1[i] = x.Fecha_Inicio;
           
                    arreglo2[i] = x.Fecha_Fin;
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista1.ItemsSource = arreglo1;
                lista2.ItemsSource = arreglo2;
                nombre1.Text = "";
                descripcion.Text = "";
                responsable.SelectedIndex = -1;
                status.SelectedIndex = -1;
                prioridad.SelectedIndex = -1;
            };
       


            Content = new StackLayout
            {
                Children = {
            nombre1,
            descripcion,
            responsable,
            Fecha_final,
            status,
            prioridad,
            enviar,
            lista,
            lista1,
            lista2,
                }
            };
        }
    }
}
