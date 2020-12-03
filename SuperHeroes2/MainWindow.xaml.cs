using System;
using System.Collections.Generic;
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

namespace SuperHeroes2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            Superheroe nuevoHeroe = new Superheroe();
            List<Superheroe> superheroes = Superheroe.GetSamples();
            int contador=0;
        public MainWindow()

        {
            InitializeComponent();
        }

        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            stackPanelsSegundo.DataContext = nuevoHeroe;
            superheroes.Add(nuevoHeroe);
            
        }

        private void ButtonLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImagenFlechaIzq_MouseDown(object sender, MouseButtonEventArgs e)
        {

            textNumeroPagina.Text = ((contador + 1) + "/" + superheroes.Count);
            if (contador < 0)
            {
                contador = 0;
            }
                if (sender.Equals(ImagenFlechaIzq)){
                    contador--;
                }
                else if (sender.Equals(ImagenFlechaDer))
                {
                    contador++;
                }
       

          //  superheroes.ElementAt(contador);
            
        }
    }
}
