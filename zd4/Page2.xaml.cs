using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private Entry dollarEntry;
        private Label eurLabel;
        private DatePicker currentDatePicker;
        private Label dollarRateLabel;
        private Label euroRateLabel;

        public Page2()
        {
            Random rnd = new Random();
            InitializeComponent();
            var centralBankLabel = new Label
            {
                Text = "Центробанк РФ:"
            };

            dollarEntry = new Entry
            {
                Placeholder = "Введите сумму в долларах",
                Keyboard = Keyboard.Numeric
            };
            dollarRateLabel = new Label
            {
             
                Text = $"Курс USD: {rnd.Next(75,90)}.000"
            };

            euroRateLabel = new Label
            {
                Text = $"Курс EUR: {rnd.Next(80,105)}.000"
            };

            var currentDateLabel = new Label
            {
                Text = "Текущая дата:"
            };

            eurLabel = new Label();
            
            currentDatePicker = new DatePicker
            {
                Format = "d/M/yyyy",
                Date = DateTime.Today
            };
            dollarEntry.TextChanged += CalculateEur;
            Content = new StackLayout
            {
                Margin = new Thickness(2),
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            centralBankLabel,
                            new Grid
                            {
                                ColumnDefinitions =
                                {
                                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                                },
                                Children =
                                {
                                    { currentDateLabel, 1, 0 },
                                    { currentDatePicker, 1, 1 }
                                }
                            }
                        }
                    },
                    dollarRateLabel,
                    euroRateLabel,
                    dollarEntry,                  
                    eurLabel
                }
            };
        }
        private void CalculateEur(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(dollarEntry.Text, out double dollarAmount))
            {
                double euroAmount = dollarAmount * 1.075;
                eurLabel.Text = $"EUR {euroAmount:F3}";
            }
            else
            {
                eurLabel.Text = "Введите корректную сумму";
            }
        }


    }
}
