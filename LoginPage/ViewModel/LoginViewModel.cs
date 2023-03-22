using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LoginPage.Model;
using LoginPage.ViewModel;
using Newtonsoft.Json;
using LoginPage.View;

namespace LoginPage.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        // fields
        private int _username;
        private int _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public int Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }
        public int Password
        {
            get { return _password; }
            set{ _password = value; OnPropertyChanged("Password"); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }


        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }







        // Commands
        public ICommand LoginCommand { get; set; }
        public ICommand RecoverPasswordCommand { get; }

        public ICommand ShowPasswordCommand { get; }

        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassword("",""));

        }

        private void ExecuteRecoverPassword(string username, string email)
        {
            throw new NotImplementedException();
        }



        // -----------------
/*
        public void ExecuteLoginCommand(object obj)
        {

            var isValidInput = Int32.TryParse(Username,out int custId);
            var temp = IsValidCustomer(custId);
            if (!IsValidCustomer(custId).Result|| !isValidInput)
            {
                //throw some error;
                ErrorMessage = "InValid UserName or Password";

            }
            else
            {
                //Proceed to login

                //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                //IsViewVisible = false;
                
                var Page2 = new InfoView(); //create your new form.
                Page2.Show(); //show the new form.
                 //only if you want to close the current form.


            }
            // LoadAllCustomer();



            //bool ValidLogin(string fName, string lName)
            //{
            //    if (Customer.firstName ! = )
            //        return false;
            //}


        }
*/

        public void ExecuteLoginCommand(object obj)
        {

           // var isValidInput = Int32.TryParse(Username, out int custId);
           var temp = IsValidCustomer(Username, Password);
            if (temp.Result.ToString() =="yes")
            {
                //throw some error;
                ErrorMessage = "InValid UserName or Password";

            }
            else
            {
                //Proceed to login


                var Page2 = new InfoView(); //create your new form.
                Page2.Show(); //show the new form.
                              //only if you want to close the current form.

            }
        }







        //async Task<bool> IsValidCustomer(int custId)
        //{
        //    //  List<Customer> customers = new List<Customer>();
        //    string url = $"https://localhost:7172/customer/validCustomer/{custId}";
        //    // make an API request 
        //    using (HttpClient client = new HttpClient())
        //    {

        //        var response = await Task.Run(() => client.GetAsync(url).Result);
        //        //  string json = await response.Content.ReadAsStringAsync();
        //        // deserilizin the json
        //        // customers = JsonConvert.DeserializeObject<List<Customer>>(json);
        //        if (response != null) return true;

        //    }
        //    return false;

        //}



        async Task<string> IsValidCustomer(int custId, int password)
        {
            string url = $"https://localhost:7172/customer/validCustomer/{custId}/{password}";
            // make an API request 
           // var response = "no";
            using (HttpClient client = new HttpClient())
            {
              // var response = client.GetAsync(url);
             //   response.Wait();
                //  var temp = JsonConvert.DeserializeObject(response);
                var response = await Task.Run(() => client.GetAsync(url).Result);
                string temp = await response.Content.ReadAsStringAsync();
                // deserilizin the json
              //  var customers = JsonConvert.DeserializeObject(response);
                if (temp != "no") return "yes";


            }
            return "no";

        }





        //bool validLogin(string username, string password)
        //{
        //    if(Customer.)
        //}
        //private void localModeBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Uri uri = new Uri("Page2.xaml", UriKind.Relative);
        //    this.NavigationService.Navigate(uri);
        //}
        private bool CanExecuteLoginCommand(object obj)
        {
            bool canExecute;
            /*
            if (Username != null && Password != null)
           {
                canExecute = true;
            }
            */
            if(IsValidCustomer(Username, Password).Result.ToString() == "yes")
            {
                canExecute = true;  
            }
            else
            {
                canExecute = false;
            }
            return canExecute;
        }



        // Query

        //public async void MakeQuery()
        //{
        //    var cities = await AccuWeatherHelper.GetCities(Query);

        //    Cities.Clear();
        //    foreach (City city in cities)
        //    {
        //        Cities.Add(city);
        //    }
        //}


    }
}
