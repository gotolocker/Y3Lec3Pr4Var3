using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Y3Lec3Pr4Var3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Human somebody;
        private void btnApplyChanges_Click(object sender, RoutedEventArgs e)
        {

            if (somebody == null)
            {
                somebody = new Human();
                btnApplyChanges.Content = "Изменить";
            }
            if (!string.IsNullOrWhiteSpace(tbName.Text)) somebody.Name = tbName.Text;
            if (!string.IsNullOrWhiteSpace(tbAge.Text) && int.TryParse(tbAge.Text, out int age)) somebody.Age = age;

            char gender = ' ';
            if (rbGenderM.IsChecked == true) gender = 'M';
            else if (rbGenderF.IsChecked == true) gender = 'F';

            if (gender != ' ') somebody.Gender = gender;
            if (!string.IsNullOrWhiteSpace(tbWeight.Text) && int.TryParse(tbWeight.Text, out int weight)) somebody.Weight = weight;

            DataContext = null;
            DataContext = somebody;
        }

        class Human
        {
            int _age;
            string _name = "Default";
            char _gender = 'M';
            int _weight;

            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    if (value >= 0)
                    {
                        _age = value;
                    }
                    else
                    {
                        throw new();
                    }
                }
            }

            public int Weight
            {
                get
                {
                    return _weight;
                }
                set
                {
                    if (value >= 0)
                    {
                        _weight = value;
                    }
                    else
                    {
                        throw new();
                    }
                }
            }
            public char Gender
            {
                get
                {
                    return _gender;
                }
                set
                {
                    if (value == 'M' || value == 'F')
                    {
                        _gender = value;
                    }
                    else
                    {
                        throw new("Wrong Value");
                    }
                }
            }

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;  
                }
            }

            public Human()
            {

            }
            public Human(string name)
            {
                Name = name;
            }
            public Human(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public Human(string name, int age, char gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }
            public Human(string name, int age, char gender, int weight)
            {
                Name = name;
                Age = age;
                Gender = gender;
                Weight = weight;
            }

            public void SetParams(int age)
            {
                Age = age;
            }
            public void SetParams(string name)
            {
                Name = name;
            }
            /// <param name="gender">может принимать только значения M или F</param>
            public void SetParams(char gender)
            {
                Gender = gender;
            }

            public void SetParams(int age, string name)
            {
                Age = age;
                Name = name;
            }

            /// <param name="gender">может принимать только значения M или F</param>
            public void SetParams(int age, string name, char gender)
            {
                Age = age;
                Name = name;
                Gender = gender;
            }

            /// <param name="gender">может принимать только значения M или F</param>
            public void SetParams(int age, string name, char gender, int weight)
            {
                Age = age;
                Name = name;
                Gender = gender;
                Weight = weight;
            }
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Захаров Никита Романович ИСП-31" +
                "\nПрактическая работа №4" +
                "\nСоздать класс Man (человек), с полями: имя, возраст, пол и вес. Создать необходимые методы и свойства. Создать перегруженные методы SetParams, для установки параметров человека.");
        }

        private void btnDemonstartor_Click(object sender, RoutedEventArgs e)
        {
            if (somebody == null) somebody = new();

            char gender = ' ';
            if (rbGenderM.IsChecked == true) gender = 'M';
            else if (rbGenderF.IsChecked == true) gender = 'F';

            if (!string.IsNullOrWhiteSpace(tbName.Text) && !string.IsNullOrWhiteSpace(tbAge.Text) && int.TryParse(tbAge.Text, out int age)
                && gender != ' ' && !string.IsNullOrWhiteSpace(tbWeight.Text) && int.TryParse(tbWeight.Text, out int weight))
            {
                somebody.SetParams(age, tbName.Text, gender, weight);
            }

            DataContext = null;
            DataContext = somebody;
        }

        private void tbAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbAge.Text.Length > 3) lAge2Big.Visibility = Visibility.Visible;
            else lAge2Big.Visibility = Visibility.Collapsed;
        }
    }
}