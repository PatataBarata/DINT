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
        ObservableCollection<Peliculas> cincoPeliculas=new ObservableCollection<Peliculas>();
        ObservableCollection<Peliculas> listaPeliculas=new ObservableCollection<Peliculas>();
        Juego juego=new Juego();
        Peliculas nuevaPeli;
        public MainWindow()
        {
            InitializeComponent();

            nuevaPeli = new Peliculas();
            nuevaPeli = (Peliculas)JuegoStackPanel.DataContext;


            cincoPeliculas=(ObservableCollection<Peliculas>)juegoPeliculasGrid.DataContext ;


           //  JuegoDockPanel.DataContext = listaPeliculas;
            JuegoStackPanel.DataContext = listaPeliculas;

          //  puntosTotalesTextBox.DataContext = juego;// para los puntos del juego que no va

            dentro.DataContext = listaPeliculas;

                   
        }

        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {

            if (listaPeliculas.Count() >= 5)
            {
                darPistaCheckBox.IsChecked = false;
                darPixtaTextBlok.Visibility = Visibility.Hidden;
                textNumeroPaginauno.Text = "1";
                 cincoPeliculas = juego.InicarJuego(listaPeliculas);
                textNumeroPagina.Text = cincoPeliculas.Count.ToString();
                int actual = Int32.Parse(textNumeroPaginauno.Text);              
                
                    juegoPeliculasGrid.DataContext = cincoPeliculas[actual];
            }
            else
                MessageBox.Show("No tenemos peliculas para jugar", "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CargarJSON(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON file (*.JSON)|*.JSON"; 
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

        }//en un principio no funciona correctamente.

        private void GuardarJSON(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON file (*.JSON)|*.JSON"; 
            if (saveFileDialog.ShowDialog() == true)
            {
                string guardadoPeliculas = JsonConvert.SerializeObject(listaPeliculas); 
                File.WriteAllText(saveFileDialog.FileName, guardadoPeliculas);//arrreglar
            }
        }

        private void darPistaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
            darPixtaTextBlok.Visibility = Visibility.Visible;
            juego.pistaVista = true; //Peta TODO arreglar
          //   juego.CalcularPuntos(pelicula.nivelDificultad); //mirar que esta mal, TODO
        }//falta algo

        private void validadPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            int numero = Int32.Parse(textNumeroPaginauno.Text); 
            

           if (validarTituloTextBox.Text.ToLower() == cincoPeliculas[numero].titulo.ToLower())
            {
                int puntos=0;
                if (cincoPeliculas[numero].facil)
                {
                    puntos = 2;
                }

                else if (cincoPeliculas[numero].normal)
                {
                    puntos = 4;
                }
                else if (cincoPeliculas[numero].dificil)
                {
                    puntos = 6;
                }

                MessageBox.Show("Pelicula Correcta", "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
                juego.CalcularPuntos(puntos);
             puntosTotalesTextBox.Text = juego.CalcularPuntos(puntos).ToString();

            }
           else
                MessageBox.Show("Pelicula erronea" , "Juego peliculas", MessageBoxButton.OK, MessageBoxImage.Information);
        } 

        private void AnyadirButton_Click(object sender, RoutedEventArgs e)
        {
            nuevaPeli = new Peliculas();
            nuevaPeli.titulo = anyadirPeliTituloTextBox.Text;
            nuevaPeli.pista = anyadirPeliPistaTextbos.Text;
            nuevaPeli.imagen  = anyadirImagenPeliTexBox.Text;
            nuevaPeli.genero = generoComboBox.Text;
            nuevaPeli.facil = (bool)facilRadioButton.IsChecked;
            nuevaPeli.normal = (bool)normalRadioButton.IsChecked;
            nuevaPeli.dificil = (bool)dificilRadioButton.IsChecked;

            if (dentro.SelectedItem==null)
            {
                listaPeliculas.Add(nuevaPeli);
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
            openFileDialog.Filter = "PNG file (*.png)|*.PNG";
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader imagenStream = File.OpenText(openFileDialog.FileName))
                {
                     anyadirImagenPeliTexBox.Text=openFileDialog.FileName ;
                }
            }
        }
    }
}
