using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using XamarinDeveloper.Model;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;

namespace XamarinDeveloper.Classes
{
    // after confrming data by user, in this activity data is shown
    [Activity(Label = "UserInformation")]
    public class UserInformationActivity : Activity
    {
        // define variables for user_information.axml views
        private TextView mGenderType;
        private TextView mAgeOrEmployee;
        private TextView mEducationOrMilitary;
        private TextView mAgeOrEmployeeLabel;
        private TextView mEducationOrMilitaryLabel;
        private TextView mPhoneNumber;
        private Button mCallBtn;
        private Binding<string, string> mBinding;

        //assigne views to user_information.axml
        public TextView GenderType
        {
            get
            {
                return mGenderType 
                   ?? (mGenderType = FindViewById<TextView>(Resource.Id.gender_type));
            }
        }
        public TextView AgeOrEmployee {
            get
            {
                return mAgeOrEmployee
                   ?? (mAgeOrEmployee = FindViewById<TextView>(Resource.Id.ageOremployee));
            }
        }
        public TextView AgeOrEmployeeLabel
        {
            get
            {
                return mAgeOrEmployeeLabel
                   ?? (mAgeOrEmployeeLabel = FindViewById<TextView>(Resource.Id.ageOremployee_label));
            }
        }
        public TextView EducationOrMilitary {
            get
            {
                return mEducationOrMilitary
                   ?? (mEducationOrMilitary = FindViewById<TextView>(Resource.Id.educationOrmilitary));
            }
        }
        public TextView EducationOrMilitaryLabel
        {
            get
            {
                return mEducationOrMilitaryLabel
                   ?? (mEducationOrMilitaryLabel = FindViewById<TextView>(Resource.Id.educationOrmilitary_label));
            }
        }
        public TextView PhoneNumber
        {
            get
            {
                return mPhoneNumber
                   ?? (mPhoneNumber = FindViewById<TextView>(Resource.Id.phoneNumber));
            }
        }

        public Button Call
        {
            get
            {
                return mCallBtn ??
                    (mCallBtn = FindViewById<Button>(Resource.Id.call));
            }
        }
        // this is for set value for UserInformationViewModel properties from here
        private UserInformationViewModel UserInfoViewModel
        {
            get;
            set;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.user_information);
            // put UserInfoViewModel instance of UserInformationViewModel.cs
            UserInfoViewModel = ServiceLocator.Current.GetInstance<UserInformationViewModel>();
            // here get intent variable that was sent by MenQuestionViewModel.cs or QuestionViewModel.cs and set them for UserInfoViewModel properties.
            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            var param = nav.GetAndRemoveParameter<List<string>>(Intent);          
            UserInfoViewModel.EducationOrMilitary = param[0];
            UserInfoViewModel.AgeOrEmployee = param[1];

            // binding views and UserInfoViewModel properties
            this.SetBinding(() => UserInfoViewModel.AgeOrEmployee
                                , () => AgeOrEmployee.Text
                                );
            this.SetBinding(() => UserInfoViewModel.EducationOrMilitary
                                , () => EducationOrMilitary.Text
                                );
            this.SetBinding(() => UserInfoViewModel.GenderType
                                , () => GenderType.Text
                                );
            this.SetBinding(() => UserInfoViewModel.PhoneNumber
                                , () => PhoneNumber.Text
                                );
            this.SetBinding(() => UserInfoViewModel.AgeOrEmployeeLabel
                               , () => AgeOrEmployeeLabel.Text
                               );
            this.SetBinding(() => UserInfoViewModel.EducationOrMilitaryLabel
                               , () => EducationOrMilitaryLabel.Text
                               );
            // when call button clicke, make calls by Intent.
            Call.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("tel:"+UserInfoViewModel.PhoneNumber);
                var intent = new Intent(Intent.ActionDial, uri);
               StartActivity(intent);
            };
        }
    }
}