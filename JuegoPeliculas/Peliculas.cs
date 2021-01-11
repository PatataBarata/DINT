using System.ComponentModel;

namespace JuegoPeliculas
{
    internal class Peliculas : INotifyPropertyChanged
    {
       private string Titulo;
       private string Pista;
       private string Imagen;
       private int NivelDificultad;
       private string Genero;

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

        public Peliculas(string titulo, string pista, string imagen, int nivelDificultad, string genero)
        {
            Titulo = titulo;
            Pista = pista;
            Imagen = imagen;
            NivelDificultad = nivelDificultad;
            Genero = genero;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    }

}