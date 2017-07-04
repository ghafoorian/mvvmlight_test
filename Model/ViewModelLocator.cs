using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight;

namespace XamarinDeveloper.Model
{
    public class ViewModelLocator
    {
        public const string WomenPageKey = "WomenPage";
        public const string UserInformationPageKey = "UserInformationPage";
        public const string MenPageKey = "MenPage";
        // public const string UserInformationPageKey = "UserInformationPage";

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            
            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}