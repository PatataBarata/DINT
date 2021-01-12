using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JuegoPeliculas 
{
    class Juego : INotifyPropertyChanged //falta hacer el propertychange de lo que se necesite (si se necesita)
    {
        int Puntos;
        int Dificultad;
        bool PistaVista;
        List<Peliculas> peliculas;
        public static Random random = new Random();

        public int puntos { get; set; }
        public int dificultad { get; set; }
        public bool pistaVista { get; set; }

        public Juego(int puntos, int dificultad, bool pistaVista, List<Peliculas> peliculas)
        {
            // arreglar puntos
            Puntos = 0;
            this.Dificultad = dificultad;
            this.PistaVista = pistaVista;
            this.peliculas = peliculas;
        }

        public Juego()
        {
        }


        private static void InicarJuego()
        {
          List<int> yaElegidas = new List<int>();
         int aleatoria = random.Next(/*peliculas.Count()+*/1);
            while (yaElegidas.Count() + 1 < 5)
            {
                if (!yaElegidas.Contains(aleatoria))
                {
                    yaElegidas.Add(aleatoria);
                }
            }



        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
