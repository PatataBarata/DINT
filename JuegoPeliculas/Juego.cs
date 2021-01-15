using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;


namespace JuegoPeliculas 
{
    class Juego : INotifyPropertyChanged //falta hacer el propertychange de lo que se necesite (si se necesita)
    {
       const int PUNTOSBASE = 0;
       private int Puntos;
       private int Dificultad;//darle el valor segun los boolean de facil, normal, dificil
       private  bool PistaVista;
        
       // List<Peliculas> peliculas;//pasar todas las peliculas que tenemos
        public static Random random = new Random();

        public int dificultad { get; set; }
        public bool pistaVista
        {
            get => PistaVista;
            set
            {
                PistaVista = value;
                NotifyPropertyChanged("Facil");
            }
        }

        public Juego(int puntos, int dificultad, bool pistaVista)
        {
            
            Puntos = 0;
            this.Dificultad = dificultad;
            PistaVista = false;
            
        }

        public Juego()
        {
        }
        public void CalcularPuntos(int puntosDePelicula) {

            if (PistaVista) {
                
                Puntos=  (PUNTOSBASE / 2)* puntosDePelicula;
            }
                Puntos =  PUNTOSBASE * puntosDePelicula;    
        }
        public List<Peliculas> InicarJuego(List<Peliculas> peliculas)
        {
          List<int> yaElegidas = new List<int>();
          List<Peliculas> cincoPeliculas=new List<Peliculas>();

            while (yaElegidas.Count() + 1 < 5)
            {
                int aleatoria = random.Next(peliculas.Count()+1);
                if (!yaElegidas.Contains(aleatoria))
                {
                    yaElegidas.Add(aleatoria);
                     cincoPeliculas.Add(peliculas[aleatoria]);

                }
            }
            return cincoPeliculas;
        }

        internal List<Peliculas> InicarJuego(ObservableCollection<Peliculas> listaPeliculas)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
