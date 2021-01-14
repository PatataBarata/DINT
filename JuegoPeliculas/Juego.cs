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
        const int PUNTOSBASE = 0;
        int Puntos;
        int Dificultad;//darle el valor segun los boolean de facil, normal, dificil
        bool PistaVista;
        
        List<Peliculas> peliculas;//pasar todas las peliculas que tenemos
        public static Random random = new Random();

        public bool facil { get; set; }
        public int puntos { get; set; }
        public int dificultad { get; set; }
        public bool pistaVista { get; set; }

        public List<Peliculas> cincoPeliculas=new List<Peliculas>();

        public Juego(List<Peliculas> cincoPeliculas)
        {
            this.cincoPeliculas = cincoPeliculas;
            // agreglar...TODO
        }

        public Juego(int puntos, int dificultad, bool pistaVista, List<Peliculas> peliculas)
        {
            // arreglar puntos
            Puntos = 0;
            this.Dificultad = dificultad;
            PistaVista = false;
            this.peliculas = peliculas;
        }

        public Juego()
        {
        }
        // planteamiento inicial
        public void CalcularPuntos() {

            if (PistaVista) {
                
                Puntos=  (PUNTOSBASE / 2)*dificultad;
            }
                Puntos =  PUNTOSBASE * dificultad;    
        }
        public void InicarJuego()
        {
          List<int> yaElegidas = new List<int>();

            while (yaElegidas.Count() + 1 < 5)
            {
                int aleatoria = random.Next(peliculas.Count()+1);
                if (!yaElegidas.Contains(aleatoria))
                {
                    yaElegidas.Add(aleatoria);
                     cincoPeliculas.Add(peliculas[aleatoria]);

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
