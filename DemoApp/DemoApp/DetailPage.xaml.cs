using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ancollider
{
    public partial class DetailPage : ContentPage
    {
        List<DataItem> listImage = new List<DataItem>{
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/svet.jpg", Name = $"#1 СВЕТ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/ehlektromagnitnyj_impuls.jpg", Name = $"#2 ИМПУЛЬС" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/udarnaja_volna.jpg", Name = $"#3 УДАРНАЯ ВОЛНА" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/pronikajushhaja_radiacija.jpg", Name = $"#4 ПРОНИКАЮЩАЯ РАДИАЦИЯ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/killian.jpg", Name = $"#5 КИЛЛИАН ТРИТИХ\"Б\".ЧАСТЬ I" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/borshhevik.jpg", Name = $"#6 БОРЩЕВИК ТРИТИХ\"Б\".ЧАСТЬ II" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/lambert.jpg", Name = $"#7 ЛАМБЕРТ ТРИТИХ\"Б\".ЧАСТЬ III" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/jokhan.jpg", Name = $"#8 ЙОХАН" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/30.jpg", Name = $"#9 ЛЕНСКИЕ СТОЛБЫ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/geometrija.jpg", Name = $"#10 ГЕОМЕТРИЯ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/1-Moskva.jpg", Name = $"#11 МОСКВА" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/2-October.jpg", Name = $"#12 ОКТЯБРЬ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/3-Dinamo.jpg", Name = $"#13 ДИНАМО" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/4-Donskie_baths.jpg", Name = $"#14 ДОНСКИЕ БАНИ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/5-Factory-kitchen.jpg", Name = $"#15 ФАБРИКА-КУХНЯ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/6-Factory_Union.jpg", Name = $"#16 ФАБРИКА СОЮЗ" },
new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/7-Zoe_and_Alexander_Kosmodemyanskiy_School.jpg", Name = $"#17 ШКОЛА ЗОИ" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/8-ZIL.jpg", Name = $"#18 ЗИЛ" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/9-Stroybyuro.jpg", Name = $"#19 СТРОЙБЮРО" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/10-ATS.jpg", Name = $"#20 АТС" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/lizard.jpg", Name = $"#21 ЯЩЕРИЦА" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/blue-frogs.jpg", Name = $" #22 СИНИЕ ЛЯГУШКИ" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/cayman.jpg", Name = $"#23 КАЙМАНОВАЯ АКУЛА" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/green-frog.jpg", Name = $"#24 ЗЕЛЁНАЯ ЛЯГУШКА" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/turtle.jpg", Name = $"#25 ЧЕРЕПАХА" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/crabs.jpg", Name = $"#26 ТРИЛОБИТЫ" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/ancient-fish-1.jpg", Name = $"#27 ДРЕВНЯЯ РЫБА ДИПТИХ.ЧАСТЬ I" },
  new DataItem{ ImageUrl = $"http://702013750.uweb.ru/gallery/ancient-fish-2.jpg", Name = $"#28 ДРЕВНЯЯ РЫБА ДИПТИХ.ЧАСТЬ II" }
                  };

        Label label;
        Image image;
        //Button button;

        public PopupLayout _PopUpLayout = new PopupLayout();
        StackLayout PopUp;
        public DetailPage()
        {
            InitializeComponent();

            //button = new Button()
            //{
            //    Text = "X",
            //    TextColor = Color.Black
            //};
            //button.Clicked += Button_Clicked;
            
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
                    //button,
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
