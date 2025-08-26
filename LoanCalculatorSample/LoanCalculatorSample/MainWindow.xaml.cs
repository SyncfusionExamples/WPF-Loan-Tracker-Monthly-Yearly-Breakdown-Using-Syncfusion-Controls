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
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = viewModel.LoanStatusData;

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
            loanPeriod = (long)e.NewValue;
            CalculateLoan();
        }

        private void CalculateLoan()
        {
            double principal = principleAmount;
            double annualInterestRate = interestAmount;
            int tenureYears = (int)loanPeriod;
            int totalMonths = tenureYears * 12;
            double monthlyRate = annualInterestRate / (12 * 100);

            double emi = principal * monthlyRate * Math.Pow(1 + monthlyRate, totalMonths) /
                         (Math.Pow(1 + monthlyRate, totalMonths) - 1);

            if (!double.IsNaN(emi))
            {
                double balance = principal;

                DateTime startDate = DateTime.Now;

                viewModel.LoanStatusData.Clear();

                for (int y = 0; y <= tenureYears; y++)
                {
                    double yearlyPrincipal = 0;
                    double yearlyInterest = 0;
                    double yearlyEMI = 0;

                    var currentYear = startDate.AddYears(y).Year;

                    int startMonth = (y == 1) ? DateTime.Now.Month : 1;
                    int totalMonth = 12 - (startMonth - 1);

                    viewModel.MonntlyLoanStatusData.Clear();
                    for (int m = 0; m < 12; m++)
                    {

                        int monthIndex = (y * 12) + m;
                        if (monthIndex >= totalMonths)
                            break;

                        double interest = balance * monthlyRate;
                        double principalPaid = emi - interest;
                        balance -= principalPaid;

                        yearlyPrincipal += principalPaid;
                        yearlyInterest += interest;
                        yearlyEMI += emi;
                        viewModel.MonntlyLoanStatusData.Add(new MonthlyDetails() { Month = new DateTime(startDate.Year, startDate.Month, startDate.Day), Payments = emi, PrincipalPaid = principalPaid
                            , InterestPaid = interest, BalanceAmount = balance });
                    }

                    viewModel.LoanStatusData.Add(new Model(

                        new DateTime(currentYear, 1, 1),
                        yearlyEMI,
                       Math.Round(yearlyInterest, 2),
                        Math.Round(yearlyPrincipal, 2),
                        Math.Round(balance, 2),
                       viewModel.MonntlyLoanStatusData = GetMonntlyLoanStatusData(startDate)

                    ));

                    //year = year.AddMonths(totalMonth);                   
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

        private ObservableCollection<MonthlyDetails> GetMonntlyLoanStatusData(DateTime year)
        {
           ObservableCollection<MonthlyDetails> monthlyDetails = new ObservableCollection<MonthlyDetails>();

            
            foreach (var monthData in viewModel.MonntlyLoanStatusData)
            {
                if(monthData.Month.Year == year.Year)
                {
                    monthlyDetails.Add(monthData);
                }
            }

            return monthlyDetails;
        }
    }
}