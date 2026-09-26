using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _database;

        public static SQLiteDatabaseHelper Database
        {
            get
            {
                if (_database == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_minhascompras.db3");
                    _database = new SQLiteDatabaseHelper(path);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.ListaProdutos());
        }
    }
}