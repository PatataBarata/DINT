using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas 
{
    class Juego : INotifyPropertyChanged //falta hacer el propertychange de lo que se necesite (si se necesita)
    {
        int Puntos;
        int dificultad;
        bool pistaVista;
        List<Peliculas> peliculas;
        public static Random random = new Random();

        public Juego(int puntos, int dificultad, bool pistaVista, List<Peliculas> peliculas)
        {
            Puntos = puntos;
            this.dificultad = dificultad;
            this.pistaVista = pistaVista;
            this.peliculas = peliculas;
        }

        public Juego()
        {
        }

 

        public static void JugarAlJuego()
        {
            
            if (/*peliculas.Count+1 > 5*/true)
            {
                InicarJuego();
                //TODO selecionar 5 peliculas aleatorias.
            }
            else 
                //sacar dialogo diciendo: 
                Console.WriteLine(" No tenemos peliculas para jugar");
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
