using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

namespace XamarinDeveloper.Model
{
    public class MainViewModel : ViewModelBase
    {
        // this properties are for make connect between MainActivity and this class.
        private string mPhoneNumberCommand;
        private RelayCommand mSaveDataCommand;
        static string mGenderCommand;

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
        public string Gender
        {
            get
            {
                return mGenderCommand;
            }
            set
            {
                mGenderCommand = value;
                RaisePropertyChanged("Gender");
            }
        }
        // in this command this model send data to WomenQuestions.cs or MenQuestions.cs by Intent and INavigationService
        public RelayCommand SaveDataCommand
        {
            get
            {
                return mSaveDataCommand
                       ?? (mSaveDataCommand = new RelayCommand(
                           () =>
                           {
                               // create list<string> for sending to other activities
                               List<string> newList = new List<string>();
                               newList.Add(Gender);
                               newList.Add(PhoneNumber);
                               var nav = ServiceLocator.Current.GetInstance<INavigationService>();

                               nav.NavigateTo((Gender.Equals("Female"))?ViewModelLocator.WomenPageKey:ViewModelLocator.MenPageKey,newList );
                          //     nav.NavigateTo(ViewModelLocator.SpecialQuestionsPageKey, Gender);

                           }));
            }
        }

    }
}