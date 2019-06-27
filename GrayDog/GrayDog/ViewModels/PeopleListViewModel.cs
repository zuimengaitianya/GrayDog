using GrayDog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace GrayDog.ViewModels
{
    public class PeopleListViewModel : BaseViewModel
    {
        public ObservableCollection<User> users { get; set; }
        //public Command<object sender, SelectedItemChangedEventArgs args> ItemSelected { get; set; }
        public PeopleListViewModel()
        {
            users = new ObservableCollection<User>();
            InitData();
        }

        private void InitData()
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    users.Add(new User()
                    {
                        ID = i,
                        Name = "anlong" + i,
                        Age = 10 + i,
                        ImagUrl = "cramer_40lm35.png"
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
