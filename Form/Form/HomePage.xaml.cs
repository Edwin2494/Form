using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Form
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
      
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void BSave_Clicked(object sender, EventArgs e)
        {
            var Nombre = TNombre.Text;

            if (!String.IsNullOrEmpty(Nombre))
            {
                var User = new UserModel { Name = Nombre };
                Intent inten = new Intent(this, new UserPage());
                inten.PutObject("User", User);
                inten.StartIntent();
            }
        }
    }
}
