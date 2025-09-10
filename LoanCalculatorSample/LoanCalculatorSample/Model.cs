using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace LoanCalculatorSample
{
    public class MonthlyDetails
    {
        public DateTime Month {  get; set; }
        public double Payments { get; set; }
        public double InterestPaid { get; set; }
        public double PrincipalPaid { get; set; }
        public double BalanceAmount { get; set; }

    }

    public class EMIModel
    {
        public string XValue { get; set; }
        public double YValue { get; set; }

        public EMIModel(string xValue, double yValue)
        {
            XValue = xValue;
            YValue = yValue;
        }
    }

    public class Model
    {
        public DateTime Years {  get; set; }
        public double Payments { get; set; }
        public double InterestPaid { get; set; }
        public double PrincipalPaid { get; set; }
        public double BalanceAmount { get; set; }

        public ObservableCollection<MonthlyDetails> MonthlyLoanDetails { get; set; }
       

        public Model(DateTime years,double payments,double interestPaid,double principalPaid,double balanceAmount, ObservableCollection<MonthlyDetails> monthlyDetails)
        {
            Years = years;
            Payments = payments;
            InterestPaid = interestPaid;
            PrincipalPaid = principalPaid;
            BalanceAmount = balanceAmount;
            MonthlyLoanDetails = monthlyDetails;
        }  
    }
}
