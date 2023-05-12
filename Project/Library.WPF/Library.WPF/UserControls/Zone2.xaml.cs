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
    /// Interaction logic for Zone2.xaml
    /// </summary>
    public partial class Zone2 : UserControl
    {
        public Zone2()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Zone2));

        public string Kind
        {
            get { return (string)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public static readonly DependencyProperty KindProperty = DependencyProperty.Register("Kind", typeof(string), typeof(Zone2));

        public string FTitle
        {
            get { return (string)GetValue(FiPropertyTitle); }
            set { SetValue(FiPropertyTitle, value); }
        }

        public static readonly DependencyProperty FiPropertyTitle = DependencyProperty.Register("FTitle", typeof(string), typeof(Zone2));

        public string STitle
        {
            get { return (string)GetValue(SPropertyTitle); }
            set { SetValue(SPropertyTitle, value); }
        }

        public static readonly DependencyProperty SPropertyTitle = DependencyProperty.Register("STitle", typeof(string), typeof(Zone2));

        public string FValue
        {
            get { return (string)GetValue(FiPropertyValue); }
            set { SetValue(FiPropertyValue, value); }
        }

        public static readonly DependencyProperty FiPropertyValue = DependencyProperty.Register("FValue", typeof(string), typeof(Zone2));

        public string SValue
        {
            get { return (string)GetValue(SPropertyValue); }
            set { SetValue(SPropertyValue, value); }
        }

        public static readonly DependencyProperty SPropertyValue = DependencyProperty.Register("SValue", typeof(string), typeof(Zone2));

    }
}
