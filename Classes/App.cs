using XamarinDeveloper.Model;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using Android.App;

namespace XamarinDeveloper.Classes
{
    // this class opens first, when application launches.
    public partial  class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    // First time initialization
                    // define NavigationService variable for register activity classes in 
                    // in simpleIon by assigne ViewModelLocator.cs keys for navigation into them
                    var nav = new NavigationService();
                    nav.Configure(
                        ViewModelLocator.WomenPageKey,
                        typeof(WomenQuestion));
                    nav.Configure(
                        ViewModelLocator.UserInformationPageKey,
                        typeof(UserInformationActivity));
                    nav.Configure(
                        ViewModelLocator.MenPageKey,
                        typeof(MenQuestionsActivity));
                                      
                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    // Register every view model class in simpleIoc
                    SimpleIoc.Default.Register<WomenQuestionViewModel>();
                    SimpleIoc.Default.Register<UserInformationViewModel>();
                    SimpleIoc.Default.Register<MenQuestionViewModel>();
                    SimpleIoc.Default.Register<IDialogService, DialogService>();

                    _locator = new ViewModelLocator();
                }

                return _locator;
            }
        }
    }
}