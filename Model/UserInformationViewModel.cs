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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace XamarinDeveloper.Model
{
    public class UserInformationViewModel : ViewModelBase
    {
        // this part make connect between UserInformationActivity.cs and this model class.
        private string mGenderTypeCommand;
        private string mPhoneNumberCommand;
        private string mAgeOrEmployeeCommand;
        private string mEducationOrmilitary;
        private string mAgeOrEmployeeLabelCommand;
        private string mEducationOrmilitaryLabel;
        private RelayCommand mCallCommand;               
        public string PhoneNumber
        {
            get
            {
                return mPhoneNumberCommand;
            }
            set
            {
                mPhoneNumberCommand = value;
                RaisePropertyChanged("PhoneNumber");
            }
        }
        public string GenderType
        {
            get
            {
                return mGenderTypeCommand;
            }
            set
            {
                mGenderTypeCommand = value;
                RaisePropertyChanged("GenderType");
            }
        }
        public string AgeOrEmployee
        {
            get
            {
                return mAgeOrEmployeeCommand;
            }
            set
            {
                mAgeOrEmployeeCommand = value;
                RaisePropertyChanged("AgeOrEmployee");
            }
        }
        public string AgeOrEmployeeLabel
        {
            get
            {
                // if Gendertype == Femal return Age string and else return Job string
                return (GenderType.Equals("Female"))? "Age:":"Job:";
            }
            
        }
        public string EducationOrMilitary
        {
            get
            {
                return mEducationOrmilitary;
            }
            set
            {
                mEducationOrmilitary = value;
                RaisePropertyChanged("EducationOrMilitary");
            }
        }
        public string EducationOrMilitaryLabel
        {
            get
            {
                // if Gendertype == Femal return Education level string and else return Military service status string
                return (GenderType.Equals("Female")) ? "Education level:" : "Military service status::";
            }
            set
            {
                mEducationOrmilitary = value;
                RaisePropertyChanged("EducationOrMilitary");
            }
        }
        
    }
}