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
        
        public MainWindow()
        {
            InitializeComponent();
            //Ahora va github??
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Juego.JugarAlJuego();
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

        // poner en el boton de jugar

    }
}
