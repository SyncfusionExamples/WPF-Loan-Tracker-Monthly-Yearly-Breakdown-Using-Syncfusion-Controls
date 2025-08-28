using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoanCalculatorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double principleAmount;
        double interestAmount;
        double loanPeriod;
        DateTime selectedDate;
        string periodType;

        ObservableCollection<MonthlyDetails> months;

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = viewModel.LoanStatusData;
            months = new ObservableCollection<MonthlyDetails>();

        }

        private void DoubleUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            principleAmount = (double)e.NewValue;
            CalculateLoan();
        }

        private void DoubleUpDown_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            interestAmount = (double)e.NewValue;
            CalculateLoan();
        }

        private void IntegerTextBox_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {           
            loanPeriod = (long)e.NewValue > 40 ? 40 : (long)e.NewValue;
            CalculateLoan();
        }

        private void datePicker_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            selectedDate = (DateTime)e.NewValue;
            CalculateLoan();
        }

        private void CalculateLoan()
        {
            double principal = principleAmount;
            double annualInterestRate = interestAmount;
            int tenureYears = (int)loanPeriod;
            int totalMonths = 0;
            if (periodType== "Year")
            {
                totalMonths = tenureYears * 12;
            }
            else
            {
                totalMonths = tenureYears;
            }

            double monthlyRate = annualInterestRate / (12 * 100);

            double emi = principal * monthlyRate * Math.Pow(1 + monthlyRate, totalMonths) /
                         (Math.Pow(1 + monthlyRate, totalMonths) - 1);

            if (!double.IsNaN(emi))
            {
                double balance = principal;
                double balanceAmount = balance;

                DateTime startDate = selectedDate;
               
                viewModel.LoanStatusData.Clear();
                months.Clear();
                for (int i = 1; i <= totalMonths; i++)
                {
                    double interest = balanceAmount * monthlyRate;
                    double principalPaid = emi - interest;

                    balanceAmount = balanceAmount - principalPaid;

                    months.Add(new MonthlyDetails()
                    {
                        Month = new DateTime(startDate.Year, startDate.Month, startDate.Day),
                        Payments = emi,
                        PrincipalPaid = principalPaid,
                        InterestPaid = interest,
                        BalanceAmount = balanceAmount
                    });

                    startDate = startDate.AddMonths(1);
                }

                var groupedByYear = months.GroupBy(m => m.Month.Year);


                foreach (var yearGroup in groupedByYear)
                {
                    double yearlyPrincipal = yearGroup.Sum(m => m.PrincipalPaid);
                    double yearlyInterest = yearGroup.Sum(m => m.InterestPaid);
                    double yearlyEMI = yearGroup.Sum(m => m.Payments);
                    double yearEndBalance = yearGroup.Last().BalanceAmount;

                    viewModel.LoanStatusData.Add(new Model(

                        new DateTime(yearGroup.Key, 1, 1),
                        yearlyEMI,
                        Math.Round(yearlyPrincipal, 2),
                        Math.Round(yearlyInterest, 2),
                        Math.Round(yearEndBalance, 2),
                        viewModel.MonntlyLoanStatusData = GetMonntlyLoanStatusData(yearGroup.Key)
                        ));   
                }

               
                // For doughnut chart
                double totalInterest = (emi * totalMonths) - principal;
                double totalAmount = principal + totalInterest;

                label.Content = "$" + emi.ToString("F2");
                viewLabel.Content = "$" + totalAmount.ToString("F2");

                viewModel.EmiData.Clear();
                viewModel.EmiData.Add(new EMIModel("PrincipalAmount", principal));
                viewModel.EmiData.Add(new EMIModel("TotalInterest", totalInterest));
            }
        }
        
        

        private ObservableCollection<MonthlyDetails> GetMonntlyLoanStatusData(int key)
        {
           ObservableCollection<MonthlyDetails> monthlyDetails = new ObservableCollection<MonthlyDetails>();

            foreach (var monthData in months)
            {
                if(monthData.Month.Year == key)
                {
                    monthlyDetails.Add(monthData);
                }
            }

            return monthlyDetails;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if(comboBox.SelectedIndex == 0)
                {
                    periodType = "Year";
                }
                else
                {
                    periodType = "Month";
                }
            }

            CalculateLoan();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox combobox && combobox.SelectedIndex == 0)
            {
                SfSkinManager.SetTheme(this, new FluentTheme { ThemeName = "FluentLight", HoverEffectMode = HoverEffect.Border });
                viewModel.UpDownForeground = Brushes.Black;
                viewModel.UpDownBackground = Brushes.White;
            }
            else
            {
                SfSkinManager.SetTheme(this, new FluentTheme { ThemeName = "FluentDark", HoverEffectMode = HoverEffect.Border });
                viewModel.UpDownForeground = Brushes.White;
                viewModel.UpDownBackground = Brushes.Black;
            }
        }
    }
}