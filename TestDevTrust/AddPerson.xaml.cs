using System;
using System.Windows;

namespace TestDevTrust
{

    public partial class AddPerson : Window
    {
        public Person person { get; set; } = null;
        public AddPerson()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (person is null) 
            {
                person = new Person()
                {
                    Name = "New People",
                    Age = 0,
                    Gender = "No"
                };
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
            PeopleName.Text = person.Name;
            PeopleAge.Text = person.Age.ToString();
            PeopleGender.Text = person.Gender;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (person is null) return;
            person.Name = PeopleName.Text;
            person.Age = Convert.ToInt32(PeopleAge.Text);
            person.Gender = PeopleGender.Text;
            this.DialogResult = true;
            this.Close();
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
