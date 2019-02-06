using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SQLiteSample
{
    public partial class DetailsPage : ContentPage
    {

        public DetailsPage(int contactID)
        {
            InitializeComponent();
            this.BindingContext = new DetailsViewModel(Navigation, contactID);
        }
    }
}