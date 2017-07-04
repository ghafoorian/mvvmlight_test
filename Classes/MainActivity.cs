using Android.App;
using Android.Widget;
using Android.OS;
using XamarinDeveloper.Model;
using GalaSoft.MvvmLight.Helpers;
using XamarinDeveloper.Helper;
using XamarinDeveloper.Classes;
using System;

namespace XamarinDeveloper
{
    // this class is first page and launcher activity 
    // and in this, user enter phone number and gender type.
    [Activity(Label = "XamarinDeveloper", MainLauncher = true)]
    public partial class MainActivity : BaseActivity
    {
        // define variables for Main.axml views
        // bindings variables are for binding views and MainViewModel.cs properties.
        private Binding<string, string> mPhoneBinding;
        private Binding<string, string> mGenderBinding;
        private Spinner mGenderSpinner;
        private EditText mPhoneNumber;
        private Button mNextBtn;
        private static bool _initialized;
        private EditText mGenderType;
        private string newGender;

        //assigne above views to Main.axml
        public EditText PhoneNumberText
        {
            get
            {
                return mPhoneNumber
                       ?? (mPhoneNumber = FindViewById<EditText>(Resource.Id.phone_number));
            }
        }

        public Spinner GenderSpinner
        {
            get
            {
                return mGenderSpinner ??
                    (mGenderSpinner = FindViewById<Spinner>(Resource.Id.gender_spinner));
            }
        }       
        public Button ContinueButton
        {
            get
            {
                return mNextBtn ??
                    (mNextBtn = FindViewById<Button>(Resource.Id.next_btn));
            }
        }
        // definding MainView for connect this activity views and MainViewModel.cs
        public MainViewModel MainView
        {
            get
            {
                return App.Locator.Main;
            }
            set { }
        }       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
             SetContentView (Resource.Layout.Main);        
            
            // binding views and default mode is TwoWay
            mPhoneBinding = this.SetBinding(
                () => MainView.PhoneNumber,
                () => PhoneNumberText.Text
                , BindingMode.TwoWay);
            // set value for Gender in MainViewMode
            MainView.Gender = newGender;
            // when next button clicked call SaveDataCommand  methode in MainViewMode.cs and send data to other activity nd navigates to it.
            ContinueButton.SetCommand(
                "Click",
               MainView.SaveDataCommand);
             // get spinner content that user seleced and assign it to MainViewModel.Gender property
              GenderSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            // set spinner items from Resource
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.genders_array, Android.Resource.Layout.SimpleExpandableListItem1);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
           GenderSpinner.Adapter = adapter;

            
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            newGender = string.Format(spinner.GetItemAtPosition(e.Position).ToString());
            MainView.Gender = newGender;                 
        }
    }
}

