using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;

namespace MobileApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong).SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            LinearLayout layoutHome = FindViewById<LinearLayout>(Resource.Id.layout_home);
            LinearLayout layoutFavs = FindViewById<LinearLayout>(Resource.Id.layout_favs);
            LinearLayout layoutOffers = FindViewById<LinearLayout>(Resource.Id.layout_offers);
            LinearLayout layoutCreateOffer = FindViewById<LinearLayout>(Resource.Id.layout_createOffer);
            LinearLayout layoutAccount = FindViewById<LinearLayout>(Resource.Id.layout_account);

            layoutHome.Visibility = ViewStates.Invisible;
            layoutFavs.Visibility = ViewStates.Invisible;
            layoutOffers.Visibility = ViewStates.Invisible;
            layoutCreateOffer.Visibility = ViewStates.Invisible;
            layoutAccount.Visibility = ViewStates.Invisible;

            if (id == Resource.Id.nav_home)
                layoutHome.Visibility = ViewStates.Visible;
            else if (id == Resource.Id.nav_favs)
                layoutFavs.Visibility = ViewStates.Visible;
            else if (id == Resource.Id.nav_offers)
                layoutOffers.Visibility = ViewStates.Visible;
            else if (id == Resource.Id.nav_createOffer)
                layoutCreateOffer.Visibility = ViewStates.Visible;
            else if (id == Resource.Id.nav_account)
                layoutAccount.Visibility = ViewStates.Visible;
            else if (id == Resource.Id.nav_loginOut)
            { }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}