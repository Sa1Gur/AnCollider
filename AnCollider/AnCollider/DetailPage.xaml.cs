using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ancollider
{
    public partial class DetailPage : ContentPage
    {
        List<DataItem> listImage = new List<DataItem>{
            new DataItem{ ImageUrl = $"https://static.tildacdn.com/tild6466-6264-4131-a633-383363623436/green-frog.jpg", Name = $"#1 Лягушка" },
            new DataItem{ ImageUrl = $"https://static.tildacdn.com/tild3732-3335-4166-b764-613236623630/cayman.jpg", Name = $"#2 Кайман" },
            new DataItem{ ImageUrl = $"https://static.tildacdn.com/tild3630-6636-4137-b031-363661343539/crabs.jpg", Name = $"#3 УДАРНАЯ ВОЛНА" },
            new DataItem{ ImageUrl = $"https://static.tildacdn.com/tild3238-3539-4731-a132-666363346564/_-_.jpg", Name = $"#4 УДАРНАЯ ВОЛНА"},
            new DataItem{ ImageUrl = $"https://static.tildacdn.com/tild3735-6130-4138-a439-373436333933/2f.jpg", Name = $"#4 УДАРНАЯ ВОЛНА"}
                  };

        Label label;
        Image image;

        public PopupLayout _PopUpLayout = new PopupLayout();
        StackLayout PopUp;
        public DetailPage()
        {
            InitializeComponent();

            image = new Image()
            {
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                _PopUpLayout.DismissPopup();
            };
            image.GestureRecognizers.Add(tapGestureRecognizer);

            label = new Label()
            {
                HeightRequest = 100,
                WidthRequest = 200,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
            };

            //MainListView.ItemAppearing += MainListView_ItemAppearing;
            MainListView.ItemsSource = listImage;

            _PopUpLayout.Content = this.Content;
            Content = _PopUpLayout;

            PopUp = new StackLayout
            {
                WidthRequest = 400, // Important, the Popup hast to have a size to be showed
                HeightRequest = 400,
                BackgroundColor = Color.White, // for Android and WP
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    image,
                    label
                }
            };
        }

        private void MainListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            sender.ToString();
            e.Item.ToString();
            //throw new System.NotImplementedException();
        }

        void MainListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as DataItem;

            if (_PopUpLayout.IsPopupActive)
            {
                _PopUpLayout.DismissPopup();
            }
            else
            {
                image.Source = item.ImageUrl;
                //_PopUpLayout.HeightRequest = image.Height;
                label.Text = item.Name;
                _PopUpLayout.ShowPopup(PopUp);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (_PopUpLayout.IsPopupActive)
            {
                _PopUpLayout.DismissPopup();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
