

using JoyOfFastDelivery.Models;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace JoyOfFastDelivery.Views
{
    public partial class AddAddressPage : ContentPage
    {
        public List<Address> Addresses { get; set; }
        public event EventHandler<Address> AddressAdded;
        public ICommand GuardarDireccionCommand { get; set; }


        public AddAddressPage(List<Address> addressesList)
        {
            InitializeComponent();
            Addresses = addressesList ?? new List<Address>();
            BindingContext = this;
        }

        private void SaveAddress_Clicked(object sender, EventArgs e)
        {
            string enteredLocation = locationEntry.Text;
            string reference = referenceEntry.Text;

            // Dodaj novu adresu u listu
            Address newAddress = new Address { Location = enteredLocation, Reference = reference };
            Addresses.Add(newAddress);

            // Pokreni dogaðaj kako bi obavestio StoresPage o dodatoj adresi
            AddressAdded?.Invoke(this, newAddress);

            // Prazni polja nakon dodavanja adrese
            locationEntry.Text = string.Empty;
            referenceEntry.Text = string.Empty;

            // Zatvori trenutnu stranicu nakon dodavanja adrese
            Navigation.PopAsync();
        }
    }
}

