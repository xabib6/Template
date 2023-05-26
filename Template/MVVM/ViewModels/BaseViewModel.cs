using FontAwesome.Sharp;
using Template.MVVM.Models;

namespace Template.MVVM.ViewModels
{
    public class BaseViewModel : BaseNotifier
    {
        public string? Header { get; set; }
        public IconChar Icon { get; set; }
    }
}
