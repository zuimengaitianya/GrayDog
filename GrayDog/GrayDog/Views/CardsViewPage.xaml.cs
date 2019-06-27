﻿using GrayDog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrayDog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardsViewPage : ContentPage
	{
		public CardsViewPage ()
		{
			InitializeComponent ();
            BindingContext = new PeopleListViewModel();
        }
	}
}