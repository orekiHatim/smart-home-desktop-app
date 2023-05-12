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

namespace Library.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for Equipement.xaml
    /// </summary>
    public partial class Equipement : UserControl
    {
        public Equipement()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Equipement));

        public string Type1
        {
            get { return (string)GetValue(Type1Property); }
            set { SetValue(Type1Property, value); }
        }

        public static readonly DependencyProperty Type1Property = DependencyProperty.Register("Type1", typeof(string), typeof(Equipement));

        public string Type2
        {
            get { return (string)GetValue(Type2Property); }
            set { SetValue(Type2Property, value); }
        }

        public static readonly DependencyProperty Type2Property = DependencyProperty.Register("Type2", typeof(string), typeof(Equipement));

        public string Kind
        {
            get { return (string)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public static readonly DependencyProperty KindProperty = DependencyProperty.Register("Kind", typeof(string), typeof(Equipement));

        public string Name0
        {
            get { return (string)GetValue(Name0Property); }
            set { SetValue(Name0Property, value); }
        }

        public static readonly DependencyProperty Name0Property = DependencyProperty.Register("Name0", typeof(string), typeof(Equipement));

        public string Type1Value
        {
            get { return (string)GetValue(Type1ValueProperty); }
            set { SetValue(Type1ValueProperty, value); }
        }

        public static readonly DependencyProperty Type1ValueProperty = DependencyProperty.Register("Type1Value", typeof(string), typeof(Equipement));

        public string Type2Value
        {
            get { return (string)GetValue(Type2ValueProperty); }
            set { SetValue(Type2ValueProperty, value); }
        }

        public static readonly DependencyProperty Type2ValueProperty = DependencyProperty.Register("Type2Value", typeof(string), typeof(Equipement));

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(Name0 == "Light")
            {
                int val = (int) Math.Floor(slider1.Value * 10);
                Byte toPass = (Byte) (val * 255 / 100);
                type1Icon.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, toPass));
            }
            type1Value.Text = "" + Math.Floor(slider1.Value * 10) + "%";
        }
    }
}
