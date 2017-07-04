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
using XamarinDeveloper.Helper;
using GalaSoft.MvvmLight.Helpers;
using XamarinDeveloper.Model;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

namespace XamarinDeveloper.Classes
{
    // when user sexuality is "male" MainActivity.cs call this activity
    [Activity(Label = "MenQuestions")]
    public partial class MenQuestionsActivity : BaseActivity
    {
        // define variables for men_questioans.axml views
        // bindings variables are for binding views and MenQuestionViewModel.cs properties.
        private Binding<string, string> mMenBinding;
        private Spinner mMilitarySpinner;
        private EditText mJob;
        private Button mConfirmeBtn;

        //assigne above views to men_questioans.axml
        public EditText Job
        {
            get
            {
                return mJob
                       ?? (mJob = FindViewById<EditText>(Resource.Id.job));
            }
        }

        public Spinner Military
        {
            get
            {
                return mMilitarySpinner ??
                    (mMilitarySpinner = FindViewById<Spinner>(Resource.Id.military_spinner));
            }
        }
        public Button Confirme
        {
            get
            {
                return mConfirmeBtn ??
                    (mConfirmeBtn = FindViewById<Button>(Resource.Id.confirme_data));
            }
        }
        // definding MenViewModel for connect this activity views and MenQuestionViewModel.cs
        public MenQuestionViewModel MenViewModel
        {
            get;
            set;
        }
        // this is for set UserInformationViewModel properties from this activity
        private UserInformationViewModel UInfoViewModel
        {
            get;
            set;
        }
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.men_questions);
            // put UInfoViewModel instance of UserInformationViewModel.cs
            UInfoViewModel = ServiceLocator.Current.GetInstance<UserInformationViewModel>();
            // in this pary get intent variable that was sent by MainActivity and set them for UInfoViewModel properties.
            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            var param = nav.GetAndRemoveParameter<List<string>>(Intent);           
            UInfoViewModel.GenderType = param[0];
            UInfoViewModel.PhoneNumber = param[1];
            // put MenViewModel instance of MenQuestionViewModel.cs
            MenViewModel = ServiceLocator.Current.GetInstance<MenQuestionViewModel>();
           // binding views
            mMenBinding = this.SetBinding(() => MenViewModel.JobSubject
                                , () => Job.Text
                                , BindingMode.TwoWay);
            // get spinner content that user seleced and assign it to MenViewModel.Gender property
            Military.ItemSelected += (sender,e)=>
            {
                var content = string.Format(Military.GetItemAtPosition(e.Position).ToString());
                MenViewModel.MilitaryStatusCommand = content;
            };
            // when Confirme button clicked call ConfirmeDataCommand  methode in MenViewModel.cs and send data to other activity and navigates to it.
            Confirme.SetCommand(
                "Click",
                MenViewModel.ConfirmeDataCommand);
            // set spinner items from resource
            var adapter = ArrayAdapter.CreateFromResource(
                   this, Resource.Array.military_array, Android.Resource.Layout.SimpleExpandableListItem1);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Military.Adapter = adapter;
        }
    }
}