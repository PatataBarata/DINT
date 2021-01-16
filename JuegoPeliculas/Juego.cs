﻿using System;
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
        public ObservableCollection<Peliculas> InicarJuego(ObservableCollection<Peliculas> peliculas)
        {
          List<int> yaElegidas = new List<int>();
          ObservableCollection<Peliculas> cincoPeliculas=new ObservableCollection<Peliculas>();
            
            while (cincoPeliculas.Count()< 5)
            {
                int aleatoria = random.Next(peliculas.Count());// esto es para saber cuantas peliculas tenemos

                if (!cincoPeliculas.Contains(peliculas[aleatoria]))
                {
                    cincoPeliculas.Add(peliculas[aleatoria]);

                }
            }

            /*
            while (yaElegidas.Count()  < 5)
            {
                int aleatoria = random.Next(peliculas.Count());
                if (!yaElegidas.Contains(aleatoria))
                {
                    yaElegidas.Add(aleatoria);
                     cincoPeliculas.Add(peliculas[aleatoria]);

                }
            }*/
            return cincoPeliculas;
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
