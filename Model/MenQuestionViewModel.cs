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
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

namespace XamarinDeveloper.Model
{
    public class MenQuestionViewModel : ViewModelBase
    {
        // this part make connect between MenQuestionsActivity.cs and this class.
        private string mJobCommand;
        private string mMilitaryStatusCommand;
        private RelayCommand mConfirmeDataCommand;

        public string JobSubject
        {
            get
            {
                return mJobCommand;
            }
            set
            {
                mJobCommand = value;
                RaisePropertyChanged("JobSubject");
            }
        }
        public string MilitaryStatusCommand
        {
            get
            {
                return mMilitaryStatusCommand;
            }
            set
            {
                mMilitaryStatusCommand = value;
                RaisePropertyChanged("MilitaryStatusCommand");
            }
        }
        // here JobSubject and MilitaryStatusCommand are sending to UserIformationActivity.cs
        public RelayCommand ConfirmeDataCommand
        {
            get
            {
                return mConfirmeDataCommand
                       ?? (mConfirmeDataCommand = new RelayCommand(
                           () =>
                           {
                               // send newList that contains JobSubject and MilitaryStatusCommand to other UserIformationActivity.cs
                               List<string> newList = new List<string>();
                               newList.Add(JobSubject);
                               newList.Add(MilitaryStatusCommand);

                               // nav is a variable for navigate from MenQuestionsActivity.cs to other.
                               var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                               nav.NavigateTo(ViewModelLocator.UserInformationPageKey, newList);

                           }));
            }
        }
    }
}