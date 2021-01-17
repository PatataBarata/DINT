using System.Collections.Generic;
using System.ComponentModel;

namespace JuegoPeliculas
{
    internal class Peliculas : INotifyPropertyChanged
    {
       private string Titulo;
       private string Pista;
       private string Imagen;
       private int NivelDificultad; // si el nivel de difuculta es facil valdra 1, si es normal 3, y si el dificil 5
       private bool Facil;
       private bool Normal;
       private bool Dificil;
       private string Genero;
      


        public bool facil
        {
            get => Facil;
            set
            {
                Facil = value;
                NotifyPropertyChanged("Facil");
            }
        }

 
        public bool normal
        {
            get => Normal;
            set
            {
                Normal = value;
                NotifyPropertyChanged("Normal");
            }
        }


        public bool dificil
        {
            get => Dificil;
            set
            {
                Normal = value;
                NotifyPropertyChanged("Dificil");
            }
        }
        public string titulo
        {
            get { return Titulo; }
            set
            {

                if (this.Titulo != value)
                {
                    this.Titulo = value;
                    this.NotifyPropertyChanged("Titulo");
                }

            }
        }
        public string pista
        {
            get { return Pista; }
            set
            {
               
                if (this.Pista != value)
                {
                    this.Pista = value;
                    this.NotifyPropertyChanged("Pista");
                }

            }
        }
        public string imagen
        {
            get { return Imagen; }
            set
            {

                if (this.Imagen != value)
                {
                    this.Imagen = value;
                    this.NotifyPropertyChanged("Imagen");
                }

            }
        }
        public int nivelDificultad
        {
            get { return NivelDificultad; }
            set
            {

                if (this.NivelDificultad != value)
                {
                    this.NivelDificultad = value;
                    this.NotifyPropertyChanged("NivelDificultad");
                }

            }
        }
        public string genero
        {
            get { return Genero; }
            set
            {

                if (this.Genero != value)
                {
                    this.Genero = value;
                    this.NotifyPropertyChanged("Genero");
                }

            }
        }

        public Peliculas()
        {
        }

        public Peliculas(string titulo, string pista, string imagen, bool facil, bool normal, bool dificil, string genero)
        {
            Titulo = titulo;
            Pista = pista;
            Imagen = imagen;
            Facil = facil;
            Normal = normal;
            Dificil = dificil;
            Genero = genero;
        }

        //arreglar el nombre para poner uno mas correcto
        public static List<Peliculas> GuardarPeliculas() {

            List<Peliculas> todasLasPeliculas = new List<Peliculas>();
           
            // coger las peliculas con JSON...
            //todasLasPeliculas.Add(TODO);

            return todasLasPeliculas;
        }

        public event PropertyChangedEventHandler PropertyChanged;

         public void NotifyPropertyChanged(string propertyName)
         {
             this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }

    }

}