using JoyOfFastDelivery.Enums;
using JoyOfFastDelivery.Models;

namespace JoyOfFastDelivery.Views;

public partial class ProductPage : ContentPage
{
     public Product CurrentProduct { get; set; }
     public List<BaseOptionsItem> AllOptions { get; set; } = new List<BaseOptionsItem>();
     public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
     public List<Extra> Extras { get; set; } = new List<Extra>();
     public List<OptionsGroup> Options { get; set; }
     int noPersons = 1;
     Random r = new Random();
     public ProductPage()
     {
          InitializeComponent();
          CurrentProduct = new Product { Id = 7, Name = "Hamburger", Image = "hamburguer.jpg", Description = "Hamburgercic, uzivajte u njemu :).", Price = 10 };
          LoadIngredients();
          LoadExtras();
          BindingContext = this;
     }

     private void LoadExtras()
     {

          Extras = new List<Extra>
          {
               new Extra
               {
                    options = new List<Option>
                    {                         
                         new Option
                         {
                              name = "Dodaci",
                              suboptions = new List<Suboption>
                              {
                                   new Suboption
                                   {
                                        Name = "Pomfrit",
                                        Rule = EnumRule.Min0_Max1
                                   }
                              }
                         },
                         new Option
                         {
                              name = "Gazirano piæe",
                              suboptions = new List<Suboption>
                              {
                                   new Suboption
                                   {
                                        Name = "Koka kola",
                                        Rule = EnumRule.Min0_Max1
                                   },
                                   new Suboption
                                   {
                                        Name = "Fanta",
                                        Rule = EnumRule.Min0_Max1
                                   },
                              }
                         },
                         new Option
                         {
                              name = "Sos",
                              suboptions = new List<Suboption>
                              {
                                   new Suboption
                                   {
                                        Name = "Tartar sos",
                                        Rule = EnumRule.Max
                                   },
                                   new Suboption
                                   {
                                        Name = "Italijanski sos",
                                        Rule = EnumRule.Max
                                   },
                              }
                         },
                    }
               }
          };

          foreach (var ingredient in Ingredients)
          {
               ingredient.GroupName = "Sastojci";
               ingredient.Rule = EnumRule.None;
               AllOptions.Add(ingredient);
          }


          foreach (var extra in Extras)
          {
               foreach (var option in extra.options)
               {
                    foreach (var suboption in option.suboptions)
                    {
                         suboption.GroupName = option.name;
                         if (option.min == 0 && option.max == 1)
                         {
                              suboption.Rule = EnumRule.Min0_Max1;
                         }
                         else if (option.min == 1 && option.max == 1)
                         {
                              suboption.Rule = EnumRule.Min1_Max1;
                         }
                         else if (option.max > 1)
                         {
                              suboption.Rule = EnumRule.Max;
                         }
                         //else if(option.min)
                         AllOptions.Add(suboption);
                    }
               }
          }

var grouped =  from o in AllOptions
               group o by o.GroupName
               into groups
               select new OptionsGroup(groups.Key, groups.ToList());

Options = new List<OptionsGroup>(grouped);
     }

     private void LoadIngredients()
     {
          Ingredients = new List<Ingredient>
          {
               new Ingredient
               {
                    Name = "Kiseli krastavci"
               },
               new Ingredient
               {
                    Name = "Luk"
               },
               new Ingredient
               {
                    Name = "Zelena salata"
               },
               new Ingredient
               {
                    Name = "Keèap"
               },
               new Ingredient
               {
                    Name = "Majonezica"
               },
          };

          foreach (var ingredient in Ingredients)
          {
               ingredient.IsSelected = true;
          }
     }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
          if (noPersons > 1)
          {
               noPersons--;
          }
          lblNoPerons.Text = noPersons.ToString();
          Add.Text = $"ADD {r.Next(0, 10000).ToString("KM")}";
     }

     private void btnPlus_Clicked(object sender, EventArgs e)
     {
          noPersons++;
          lblNoPerons.Text = noPersons.ToString();
          Add.Text = $"ADD {r.Next(0, 10000).ToString("KM")}";
     }


    private void Add_Clicked(object sender, EventArgs e)
    {
       
        ShoppingCart.Instance.AddToCart(CurrentProduct, noPersons);

       
        Navigation.PopAsync();
    }
}