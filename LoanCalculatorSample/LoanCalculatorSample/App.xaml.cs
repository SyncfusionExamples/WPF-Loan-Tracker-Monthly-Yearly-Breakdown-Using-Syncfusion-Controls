using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LoanCalculatorSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SfSkinManager.ApplicationTheme = new FluentTheme { ThemeName = "FluentLight" };
        }
    }

}
