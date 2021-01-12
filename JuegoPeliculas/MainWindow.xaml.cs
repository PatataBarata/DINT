using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //quitar, solo para hacer pruebas.
        Peliculas pelicula = new Peliculas("metropolis", "Mujer bionica blanco y negro", "https://www.experimenta.es/wp-content/uploads/2018/03/metropolis-la-boca-experimenta-02-800x1200.jpg" ,2, "ciencia-ficcion");
        List<Peliculas> peliculas=new List<Peliculas>();  //quitar, solo para hacer pruebas.
        Juego juego = new Juego();

        public MainWindow()
        {
            InitializeComponent();
            peliculas.Add(pelicula); //quitar, solo para hacer pruebas.
           
            posterImage.DataContext = peliculas;
            JuegoDockPanel.DataContext = peliculas;
            puntosTotalesTextBox.DataContext = juego; 
                   
        }

        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            if (peliculas.Count()+1 > 5)
            {
                //InicarJuego();
                //TODO selecionar 5 peliculas aleatorias.
            }
            else
                MessageBox.Show("No tenemos peliculas para jugar");
        }

        private void CargarJSON(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                dentro.Text = File.ReadAllText(openFileDialog.FileName);//arreglar lo del texto
                openFileDialog.Filter = "JSON file (*.JSON)|*.JSON"; //no funciona arreglar
            }

        }

        private void GuardarJSON(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, dentro.Text);
                saveFileDialog.Filter = "JSON file (*.JSON)|*.JSON"; //no funciona arreglar
            }
        }

        private void darPistaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            darPixtaTextBlok.Visibility = Visibility;
            //juego.bajar puntos a la mitad por miron
        }

        private void validadPeliculaButton_Click(object sender, RoutedEventArgs e)
        { 
            //pasar a minusculas el texto que entra y el titulo o buscar solucion
            if (validarTituloTextBox.Text == pelicula.titulo)
            {
                //añadir puntos y pasar a siguiente pelicula
            }
            else
                MessageBox.Show("Pelicula erronea");
        }

       

    }
}
