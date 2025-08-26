using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace LoanCalculatorSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        private double _totalAmountPayable;

        public double TotalAmountPayable
        {
            get { return _totalAmountPayable; }
            set
            {
                _totalAmountPayable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalAmountPayable)));
            }
        }

        public ObservableCollection<EMIModel> EmiData { get; set; }
        public ObservableCollection<Model> LoanStatusData { get; set; }

        public ObservableCollection<MonthlyDetails> MonntlyLoanStatusData = new ObservableCollection<MonthlyDetails>();    

        public ViewModel() 
        {
            EmiData = new ObservableCollection<EMIModel>();
            LoanStatusData = new ObservableCollection<Model>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
