using JoyOfFastDelivery.Models;

namespace JoyOfFastDelivery.Views;

public partial class StoresPage : ContentPage
{

    public List<Store> Stores { get; set; }
    public List<Address> Addresses { get; set; }
    //public Address CurrentAddress { get; set; }
    private double height = 0;
    private double width = 0;

    public StoresPage()
    {
        InitializeComponent();
        LoadData();
        BindingContext = this;
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        addressesList.TranslationY = height;
        this.width = width;
        this.height = height;
    }

    private void LoadData()
    {


        Stores = new List<Store>
          {
               new Store
               {
                    Id = 1,
                    Header = "header1.jpg",
                    Logo = "logo1a.jpg",
                    Name = "Naša kuæa",
                    DeliveryTime = "30 - 40 minuta",
                    Minimum = 50,
                    ServiceFee = 10,
                    Rating = 4.5
               },
               new Store
               {
                    Id = 2,
                    Header = "header2.jpg",
                    Logo = "logo2.jpg",
                    Name = "ADS restoran",
                    DeliveryTime = "30 - 50 minuta",
                    Minimum = 150,
                    ServiceFee = 5,
                    Rating = 4.8
               },
               new Store
               {
                    Id = 1,
                    Header = "header3.jpg",
                    Logo = "logo3.jpg",
                    Name = "Tiron",
                    DeliveryTime = "15 - 25 minuta",
                    Minimum = 250,
                    ServiceFee = 0,
                    Rating = 4.3
               },
               new Store
               {
                    Id = 1,
                    Header = "header4.jpg",
                    Logo = "logo4.jpg",
                    Name = "Medena Dolina",
                    DeliveryTime = "15 - 30 minuta",
                    Minimum = 100,
                    ServiceFee = 25,
                    Rating = 4.6
               },
               new Store
               {
                    Id = 1,
                    Header = "header5.jpg",
                    Logo = "logo5.jpg",
                    Name = "Oaza restoran",
                    DeliveryTime = "30 - 45 minuta",
                    Minimum = 5,
                    ServiceFee = 18,
                    Rating = 4.3
               },
          };

        lstStores.ItemsSource = Stores;

        Addresses = new List<Address>()
          {
               new Address { Location = "Desetnik", Reference = "" },
                new Address { Location = "Alije Izetbegoviæa", Reference = "" },
                new Address { Location = "Crkvice", Reference = "" },
                new Address { Location = "7. muslimanske brigade", Reference = "" },
                new Address { Location = "Zenica", Reference = "" },
                new Address { Location = "Crkvice", Reference = "" },
                new Address { Location = "Željeznièka bb", Reference = "" }
          };
        CurrentAddress.Text = Addresses.FirstOrDefault()?.Location;
        lstAddresses.ItemsSource = Addresses;
    }

    private bool isSearchingAddresses = false;

    private void SelectAddress_Clicked(object sender, EventArgs e)
    {
        if (!isSearchingAddresses)
        {
            addressesList.TranslateTo(0, height, 500, Easing.SinIn);
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        if (!isSearchingAddresses)
        {
            addressesList.TranslateTo(0, 0, 500, Easing.SinOut);
        }
    }
    private void Address_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var selectedAddress = (RadioButton)sender;
        CurrentAddress.Text = selectedAddress.Content.ToString();
        CurrentReference.Text = Addresses.FirstOrDefault(a => a.Location == selectedAddress.Content.ToString())?.Reference;
    }

    private void AddAddress_Clicked(object sender, EventArgs e)
    {
        var addAddressPage = new AddAddressPage(Addresses);
        addAddressPage.AddressAdded += (s, address) =>
        {
            Addresses.Add(address);

            CurrentAddress.Text = address.Location;
            CurrentReference.Text = address.Reference;

        };

        Navigation.PushAsync(addAddressPage);
    }

    private void lstStores_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Navigation.PushAsync(new StorePage());
    }
    private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue;

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            
            lstStores.ItemsSource = Stores;
        }
        else
        {
            
            var filteredStores = Stores.Where(store =>
                store.Name.ToLower().Contains(searchTerm.ToLower())
            ).ToList();

            lstStores.ItemsSource = filteredStores;
        }
    }
    private void SearchEntryAddress_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue;

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            lstAddresses.ItemsSource = Addresses;
        }
        else
        {
     
            var filteredAddress = Addresses.Where(address =>
                address.Location != null && address.Location.ToLower().Contains(searchTerm.ToLower())
            ).ToList();

            lstAddresses.ItemsSource = filteredAddress;
        }
    }





}