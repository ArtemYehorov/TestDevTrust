using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TestDevTrust.Models;

namespace TestDevTrust.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private List<Person>? people;

        public MainWindowViewModel()
        {
            List<Person> _people = new()
            {
                new Person() { Name = "John Doe", Age = 32, Gender = "Male" },
                new Person() { Name = "Jane Doe", Age = 28, Gender = "Female" },
                new Person() { Name = "Jim Smith", Age = 40, Gender = "Male" },
                new Person() { Name = "Jessica Smith", Age = 35, Gender = "Female" },
                new Person() { Name = "Jackie Chan", Age = 45, Gender = "Male" }
            };
            people = _people;
        }

        public List<Person>? People
        {
            get => people;
            set
            {
                people = value;
                OnPropertyChanged(nameof(people));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DelegateCommand addPerson_Click;
        public ICommand AddPersonClick => addPerson_Click ??= new DelegateCommand(PerformAddPerson_Click);

        private void PerformAddPerson_Click()
        {
            var window = new AddPerson();
            if (window.ShowDialog().GetValueOrDefault())
            {
                try
                {
                    people.Add(new Person { Name = window.person.Name, Age = window.person.Age, Gender = window.person.Gender });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
