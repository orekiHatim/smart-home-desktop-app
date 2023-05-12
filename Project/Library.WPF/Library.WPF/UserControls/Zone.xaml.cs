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
    /// Interaction logic for Zone.xaml
    /// </summary>
    public partial class Zone : UserControl
    {
        public Zone()
        {
            InitializeComponent();
        }


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Zone));


        public string Type1
        {
            get { return (string)GetValue(Type1Property); }
            set { SetValue(Type1Property, value); }
        }

        public static readonly DependencyProperty Type1Property = DependencyProperty.Register("Type1", typeof(string), typeof(Zone));


        public string Type2
        {
            get { return (string)GetValue(Type2Property); }
            set { SetValue(Type2Property, value); }
        }

        public static readonly DependencyProperty Type2Property = DependencyProperty.Register("Type2", typeof(string), typeof(Zone));

        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(string), typeof(Zone));

        public string Kind
        {
            get { return (string)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public static readonly DependencyProperty KindProperty = DependencyProperty.Register("Kind", typeof(string), typeof(Zone));

        public string TempTitle
        {
            get { return (string)GetValue(TempTitleProperty); }
            set { SetValue(TempTitleProperty, value); }
        }

        public static readonly DependencyProperty TempTitleProperty = DependencyProperty.Register("TempTitle", typeof(string), typeof(Zone));
    }
}
