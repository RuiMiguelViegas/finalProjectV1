using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Firebase;
using Firebase.Auth;
using finalProjectV1;



namespace final_Project.Droid
{
    [Activity(Label = "InstaFood", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static FirebaseAuth FirebaseAuthInstance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // Initialize Firebase
            InitializeFirebase();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitializeFirebase()
        {
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:797582406718:android:6693cf0481379b14a1cd6f")
                .SetApiKey("AIzaSyDZTCfg7RjTA6TCRwwZNeRO8ndBnbf9yNI")
                .SetDatabaseUrl("https://finalproject-f2591-default-rtdb.europe-west1.firebasedatabase.app/")
                .SetStorageBucket("finalproject-f2591.appspot.com")
                .Build();

            FirebaseApp.InitializeApp(Application.Context, options);
            FirebaseAuthInstance = FirebaseAuth.Instance;
        }
    }
}
