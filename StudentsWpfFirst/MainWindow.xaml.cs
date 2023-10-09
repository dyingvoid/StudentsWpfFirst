using System;
using System.Windows;

namespace StudentsWpfFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isNegative = IsNegative();

            if (isNegative)
            {
                LabelError.Content = MakeErrorMessage();
            }
            else
            {
                LabelError.Content = "";
                decimal resultDiscount = CalculateDiscountRubles(Price, Discount);
                ResultPrice.Text = (Price - resultDiscount).ToString();
                ResultDiscount.Text = resultDiscount.ToString();
            }
        }

        private decimal CalculateDiscountRubles1(decimal price1, decimal price2)
        {
            return price2 - price1;
        }

        private decimal CalculateDiscountRubles(decimal price, decimal discount)
        {
            return price * (discount / 100);
        }

    private bool IsNegative()
        {
            return Math.Sign(Price) == -1 || 
                   Math.Sign(Discount) == -1;
        }

        private string MakeErrorMessage()
        {
            string error = "Ошибки: ";
            
            if (Math.Sign(Price) == -1)
                error += "цена отрицательная; ";
            if (Math.Sign(Discount) == -1)
                error += "скидка отрицательная; ";

            return error;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}