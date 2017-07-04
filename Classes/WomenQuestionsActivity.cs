using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using XamarinDeveloper.Model;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using XamarinDeveloper.Helper;
using GalaSoft.MvvmLight.Helpers;

namespace XamarinDeveloper.Classes
{
    // when user sexuality is "female" MainActivity.cs call this activity
    [Activity(Label = "WomenQuestion")]
    public partial class WomenQuestion : BaseActivity
    {
        // define variables for women_questioans.axml views
        // bindings variables are for binding views and WomenQuestionViewModel.cs properties.

        private EditText mEducation;
        private EditText mAge;
        private Button mShowUserData;
        private Binding<string, string> mWomenBinding;

        // definding WQViewModel for connect this activity views and WomenQuestionViewModel.cs
        public WomenQuestionViewModel WQViewModel
        {
            get;
            set;
        }
        // this is nesseceray for set UserInformationViewModel propertyies from this activity
        private UserInformationViewModel UiViewModel
        {
            get;
            set;
        }
        //assigne difiened views to women_questioans.axml
        public EditText Education
        {
            get
            {
                return mEducation
                       ?? (mEducation = FindViewById<EditText>(Resource.Id.education_edt));
            }
        }
        public EditText Age
        {
            get
            {
                return mAge
                       ?? (mAge = FindViewById<EditText>(Resource.Id.age_edt));
            }
        }
        public Button Confirme
                {
                    get
                    {
                        return mShowUserData
                            ?? (mShowUserData = FindViewById<Button>(Resource.Id.show_data_btn));
                    }
                }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.women_questions);

            // put UiViewModel instance of UserInformationViewModel.cs
            UiViewModel = ServiceLocator.Current.GetInstance<UserInformationViewModel>();
            // in this pary get intent variable that was sent by MainActivity and set them for UiViewModel properties.
            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            var param = nav.GetAndRemoveParameter<List<string>>(Intent);         
            UiViewModel.GenderType = param[0];
            UiViewModel.PhoneNumber = param[1];

            // put WQViewModel instance of WomenQuestionViewModel.cs
            WQViewModel = ServiceLocator.Current.GetInstance<WomenQuestionViewModel>();

            // binding views
            mWomenBinding = this.SetBinding(() => WQViewModel.Age
                                , () => Age.Text
                                , BindingMode.TwoWay );
            mWomenBinding = this.SetBinding(() => WQViewModel.Education
                                , () => Education.Text
                                , BindingMode.TwoWay);
            // when Confirme button clicked call ConfirmeDataCommand  methode in WomenQuestionViewModel.cs and send data to other activity and navigates to it.
            Confirme.SetCommand(
                "Click", 
                WQViewModel.ShowDataCommand);
        }
    }
}