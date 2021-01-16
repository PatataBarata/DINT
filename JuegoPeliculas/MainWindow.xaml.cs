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

       // Peliculas pelicula = new Peliculas("metropolis", "Mujer bionica blanco y negro", "https://www.experimenta.es/wp-content/uploads/2018/03/metropolis-la-boca-experimenta-02-800x1200.jpg" ,2, "ciencia-ficcion");
      
        ObservableCollection<Peliculas> cincoPeliculas=new ObservableCollection<Peliculas>(); //iniciar las peliculas del juego
        ObservableCollection<Peliculas> listaPeliculas=new ObservableCollection<Peliculas>();
        Juego juego=new Juego();

        public MainWindow()
        {
            InitializeComponent();
            // peliculas.Add(pelicula); //quitar, solo para hacer pruebas.
            // peliculas = Peliculas.GuardarPeliculas(); //usar cuando este arreglado.
          
            juegoPeliculasGrid.DataContext = cincoPeliculas;


           //  JuegoDockPanel.DataContext = listaPeliculas;
           // JuegoStackPanel.DataContext = listaPeliculas;

            puntosTotalesTextBox.DataContext = juego;// para los puntos del juego que no va

            dentro.DataContext = listaPeliculas;
            //textNumeroPagina.Text = cincoPeliculas.Count.ToString(); //poner cuando funcione
                   
        }

        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {

            if (listaPeliculas.Count() >= 5)
            {
             textNumeroPaginauno.Text = "1";
            cincoPeliculas = juego.InicarJuego(listaPeliculas);
            //selecionar 5 peliculas aleatorias.(esto ya esta hecho en un principio)
            textNumeroPagina.Text = cincoPeliculas.Count.ToString();

     
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
                using (StreamReader jsonStream = File.OpenText(openFileDialog.FileName))
                {
                    var json = jsonStream.ReadToEnd();
                List<Peliculas> nuevaListaPeliculas = JsonConvert.DeserializeObject<List<Peliculas>>(json);

                    foreach (Peliculas p in nuevaListaPeliculas)
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
            darPixtaTextBlok.Visibility = Visibility.Visible;
            juego.pistaVista = true; //Peta TODO arreglar
          //   juego.CalcularPuntos(pelicula.nivelDificultad); //mirar que esta mal, TODO
        }//falta algo

        private void validadPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            int numero = Int32.Parse(textNumeroPaginauno.Text); 

            //pasar a minusculas el texto que entra y el titulo o buscar solucion
           if (validarTituloTextBox.Text == cincoPeliculas[numero].titulo)
            {
                MessageBox.Show("Pelicula Correcta", "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
              //  juego.CalcularPuntos(pelicula.nivelDificultad);
                // pasar a siguiente pelicula, TODO
            }
        //    else*/
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
            this.Resources.Add("nuevaPeli", new Peliculas());//no deja los campos en blanco
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            listaPeliculas.Remove((Peliculas)dentro.SelectedItem);
            ReiniciarPeliculas();

        }
 
        private void ImagenFlechaIzq_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(textNumeroPaginauno.Text);

            if (actual > 1)
            {
                juegoPeliculasGrid.DataContext = cincoPeliculas[actual - 2];
                textNumeroPaginauno.Text = (actual - 1).ToString();
            }
        }

        private void ImagenFlechaDer_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(textNumeroPagina.Text);

            if (actual < cincoPeliculas.Count)
            {
                juegoPeliculasGrid.DataContext = cincoPeliculas[actual];
                textNumeroPagina.Text = (actual + 1).ToString();
            }
        }

        private void ExaminarButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG file (*.png)|*.PNG"; //ya funciona
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader imagenStream = File.OpenText(openFileDialog.FileName))
                {
                     ImagenPeliTexBox.Text=openFileDialog.FileName ;
                }
            }
        }
    }
}
