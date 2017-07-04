using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace XamarinDeveloper.Helper
{
    
    public class BaseActivity : ActivityBase
    {
        public NavigationService GlobalNavigation
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }
    }
}