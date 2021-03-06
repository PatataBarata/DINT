using System.Collections.Generic;
using System.ComponentModel;

namespace SuperHeroes2
{
    class Superheroe : INotifyPropertyChanged
    {
        private string nombre;
        private string imagen;
        private bool vengador;
        private bool heroe;
        private bool xmen;
        private bool villano;
   

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                this.NotifyPropertyChanged("Nombre");
            }
        }
        public string Imagen
        {
            get { return imagen; }
            set
            {
                imagen = value;
                this.NotifyPropertyChanged("Imagen");
            }
        }
        public bool Vengador
        {
            get { return vengador; }
            set
            {
                vengador = value;
                this.NotifyPropertyChanged("Vengador");
            }
        }
        public bool Xmen
        {
            get { return xmen; }
            set
            {
                xmen = value;
                this.NotifyPropertyChanged("Xmen");
            }
        }
        public bool Heroe
        {
            get { return heroe; }
            set
            {
                heroe = value;
                this.NotifyPropertyChanged("Heroe");
            }
        }
        public bool Villano
        {
            get { return villano; }
            set
            {
                villano = value;
                this.NotifyPropertyChanged("Villano");
            }
        }


        public Superheroe()
        {
        }

        public Superheroe(string nombre, string imagen, bool vengador, bool xmen, bool heroe, bool villano)
        {
            Nombre = nombre;
            Imagen = imagen;
            Vengador = vengador;
            Xmen = xmen;
            Heroe = heroe;
            Villano = villano;
        }
        

    

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<Superheroe> GetSamples()
        {
            List<Superheroe> ejemplos = new List<Superheroe>();

            Superheroe ironman = new Superheroe("Ironman", @"https://sm.ign.com/ign_latam/screenshot/default/ybbpqktez5whedr0-1592031889_31aa.jpg", true, false, true, false);
            Superheroe kingpin = new Superheroe("Kingpin", @"https://www.comicbasics.com/wp-content/uploads/2017/09/Kingpin.jpg", false, false, false, true);
            Superheroe spiderman = new Superheroe("Spiderman", @"https://wipy.tv/wp-content/uploads/2019/08/destino-de-%E2%80%98Spider-Man%E2%80%99-en-los-Comics.jpg", true, true, true, false);

            ejemplos.Add(ironman);
            ejemplos.Add(kingpin);
            ejemplos.Add(spiderman);

            return ejemplos;
        }
    }
}