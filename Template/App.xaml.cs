using Template.MVVM.Models;
using System.Windows;

namespace Template
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception is CustomException customException)
            {
                MessageBox.Show($"{customException.Message}\n {customException.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
            else
            {
                MessageBox.Show($"{e.Exception.Message}\n {e.Exception.InnerException?.Message}", "Fatal error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
