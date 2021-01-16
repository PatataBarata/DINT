using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //quitar, solo para hacer pruebas.
       // Peliculas pelicula = new Peliculas("metropolis", "Mujer bionica blanco y negro", "https://www.experimenta.es/wp-content/uploads/2018/03/metropolis-la-boca-experimenta-02-800x1200.jpg" ,2, "ciencia-ficcion");
       // List<Peliculas> peliculas=new List<Peliculas>();  //quitar, solo para hacer pruebas.

        ObservableCollection<Peliculas> cincoPeliculas=new ObservableCollection<Peliculas>(); //iniciar las peliculas del juego
        ObservableCollection<Peliculas> listaPeliculas=new ObservableCollection<Peliculas>();
        Juego juego=new Juego();

        public MainWindow()
        {
            InitializeComponent();
            // peliculas.Add(pelicula); //quitar, solo para hacer pruebas.
            // peliculas = Peliculas.GuardarPeliculas(); //usar cuando este arreglado.
           // listaPeliculas.Add(pelicula);
            posterImage.DataContext = listaPeliculas;


            JuegoDockPanel.DataContext = listaPeliculas;
           // JuegoStackPanel.DataContext = listaPeliculas;

            puntosTotalesTextBox.DataContext = juego;// para los puntos del juego que no va

            dentro.DataContext = listaPeliculas;
            //textNumeroPagina.Text = cincoPeliculas.Count.ToString(); //poner cuando funcione
                   
        }

        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            if (listaPeliculas.Count() > 5)
            {
                textNumeroPaginauno.Text = "1";
                textNumeroPagina.Text = cincoPeliculas.Count.ToString();//no peta pero no funciona

                cincoPeliculas = juego.InicarJuego(listaPeliculas);
                //selecionar 5 peliculas aleatorias.(esto ya esta hecho en un principio)

            }
            else
                MessageBox.Show("No tenemos peliculas para jugar", "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CargarJSON(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON file (*.JSON)|*.JSON"; //ya funciona
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader jsonStream = File.OpenText("personas.json"))
                {
                    var json = jsonStream.ReadToEnd();
                    listaPeliculas = JsonConvert.DeserializeObject<ObservableCollection<Peliculas>>(json);

                    foreach (Peliculas p in listaPeliculas)
                    {
                        listaPeliculas.Add(p);
                    }
                }
            }

        }

        private void GuardarJSON(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON file (*.JSON)|*.JSON"; //ya funciona
            if (saveFileDialog.ShowDialog() == true)
            {
                string guardadoPeliculas = JsonConvert.SerializeObject(listaPeliculas); 
                File.WriteAllText(saveFileDialog.FileName, guardadoPeliculas);//arrreglar
            }
        }

        private void darPistaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //se puede hacer con trigger pero como tengo que controlar los puntos veo mejor hacerlo aqui.
            darPixtaTextBlok.Visibility = Visibility;
            juego.pistaVista = true; //Peta TODO arreglar
          //   juego.CalcularPuntos(pelicula.nivelDificultad); //mirar que esta mal, TODO
        }//falta algo

        private void validadPeliculaButton_Click(object sender, RoutedEventArgs e)
        { 
            //pasar a minusculas el texto que entra y el titulo o buscar solucion
           /* if (validarTituloTextBox.Text == cincoPeliculas.Count(validarTituloTextBox.Text))
            {
                MessageBox.Show("Pelicula Correcta", "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
                juego.CalcularPuntos(pelicula.nivelDificultad);
                // pasar a siguiente pelicula, TODO
            }
            else*/
                MessageBox.Show("Pelicula erronea" , "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
        } //falta algo

        private void AnyadirButton_Click(object sender, RoutedEventArgs e)
        {
            if (dentro.SelectedItem==null)
            {

                listaPeliculas.Add((Peliculas)this.Resources["nuevaPeli"]);
                MessageBox.Show("Pelicula añadida", "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
            }
          
            ReiniciarPeliculas();
        }

        private void ReiniciarPeliculas()
        {
            this.Resources.Remove("nuevaPeli");
            this.Resources.Add("nuevaPeli", new Peliculas());
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            listaPeliculas.Remove((Peliculas)dentro.SelectedItem);
            ReiniciarPeliculas();

        }
    }
}
