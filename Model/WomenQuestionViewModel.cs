using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using Android.Content;

namespace XamarinDeveloper.Model
{
    public class WomenQuestionViewModel : ViewModelBase
    {
        // this part make connect between WomenQuestionsActivity.cs and this class.
        private string mEducationCommand;
        private string mAgeCommand;
        private RelayCommand mShowDataCommand;

        public string Education
        {
            get
            {
                return mEducationCommand;
            }
            set
            {
                mEducationCommand = value;
                RaisePropertyChanged("Education");
            }
        }
        public string Age
        {
            get
            {
                return mAgeCommand;
            }
            set
            {
                mAgeCommand = value;
                RaisePropertyChanged("Age");
            }
        }
        // here Education and Age are sending to UserIformationActivity.cs
        public RelayCommand ShowDataCommand
        {
            get
            {
                return mShowDataCommand
                       ?? (mShowDataCommand = new RelayCommand(
                           () =>
                           {
                               // send newList that contains JobSubject and MilitaryStatusCommand to other UserIformationActivity.cs                   
                               List<string> newList = new List<string>();
                               newList.Add(Education);
                               newList.Add(Age);
                               // nav is a variable for navigate from WomenQuestionsActivity.cs to other.
                               var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                               nav.NavigateTo(ViewModelLocator.UserInformationPageKey, newList);

                           }));
            }
        }

    }
}