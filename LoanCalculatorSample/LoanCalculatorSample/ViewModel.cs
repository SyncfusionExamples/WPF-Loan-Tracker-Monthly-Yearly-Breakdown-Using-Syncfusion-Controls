using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace LoanCalculatorSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Brush foregroundBrush = Brushes.Black;
        private Brush backgroundBrush = Brushes.White;

        public Brush UpDownForeground 
        {
            get
            {
                return foregroundBrush;
            }
            set
            {
                foregroundBrush = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(UpDownForeground)));
            } 
        }

        public Brush UpDownBackground
        {
            get
            {
                return backgroundBrush;
            }
            set
            {
                backgroundBrush = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UpDownBackground)));
            }
        }

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
