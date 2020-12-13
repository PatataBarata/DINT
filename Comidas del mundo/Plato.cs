using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;

namespace Comidas_del_mundo
{
   public class Plato :  INotifyPropertyChanged, IValueConverter
    {
        private string nombre;
        private string imagen;
        private string tipo;
        private bool gluten;
        private bool soja;
        private bool leche;
        private bool sulfitos;
        public string Nombre {
            get {
                return this.nombre; }
            set {
                if (this.nombre != value)
                {
                    this.nombre = value;
                    this.NotifyPropertyChanged("Nombre");
                }
            } }
        public string Imagen {
            get { return this.imagen; }
            set
            {
                if (this.imagen != value)
                {
                    this.imagen = value;
                    this.NotifyPropertyChanged("Imagen");
                }
            }
        }
        public string Tipo
        {
            get { return this.tipo; }
            set
            {
                if (this.tipo != value)
                {
                    this.tipo = value;
                    this.NotifyPropertyChanged("Tipo");
                }
            }
        }
        public bool Gluten {
            get { return this.gluten; }
            set
            {
                if (this.gluten != value)
                {
                    this.gluten = value;
                    this.NotifyPropertyChanged("Gluten");
                }
            }
        }
        public bool Soja {
            get { return this.soja; }
            set
            {
                if (this.soja != value)
                {
                    this.soja = value;
                    this.NotifyPropertyChanged("Soja");
                }
            }
        }
        public bool Leche {
            get { return this.leche; }
            set
            {
                if (this.leche != value)
                {
                    this.leche = value;
                    this.NotifyPropertyChanged("Leche");
                }
            }
        }
        public bool Sulfitos {
            get { return this.sulfitos; }
            set
            {
                if (this.sulfitos != value)
                {
                    this.sulfitos = value;
                    this.NotifyPropertyChanged("Sulfitos");
                }
            }
        }

        public Plato(string nombre, string imagen, string tipo, bool gluten, bool soja, bool leche, bool sulfitos)
        {
            Nombre = nombre;
            Imagen = imagen;
            Tipo = tipo;
            Gluten = gluten;
            Soja = soja;
            Leche = leche;
            Sulfitos = sulfitos;
        }

        public Plato()
        {
        }

        public static List<Plato> GetSamples(string rutaImagenes)
        {
            List<Plato> lista = new List<Plato>();

            lista.Add(new Plato("Hamburguesa", Path.Combine(rutaImagenes, @"burguer.jpg"), "Americana", true, false, true, true));
            lista.Add(new Plato("Dumplings", Path.Combine(rutaImagenes, @"dumplings.jpg"), "China", true, true, false, false));
            lista.Add(new Plato("Tacos", Path.Combine(rutaImagenes, @"tacos.jpg"), "Mexicana", true, false, false, true));
            lista.Add(new Plato("Cerdo agridulce", Path.Combine(rutaImagenes, @"cerdoagridulce.jpg"), "China", true, true, false, true));
            lista.Add(new Plato("Hot dogs", Path.Combine(rutaImagenes, @"hotdog.jpg"), "Americana", true, true, true, true));
            lista.Add(new Plato("Fajitas", Path.Combine(rutaImagenes, @"fajitas.jpg"), "Mexicana", true, false, false, true));

            return lista;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (gluten)
            {

               return DesignerSerializationVisibility.Visible;
            }

            return DesignerSerializationVisibility.Hidden;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
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
