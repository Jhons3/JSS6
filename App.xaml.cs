using JSS6.Utils;

namespace JSS6
{
    public partial class App : Application
    {
        public static EstudianteRepository EstudianteRepo { get; set; }
        public App(EstudianteRepository estudianteRepository)
        {
            InitializeComponent();

            MainPage = new Views.EstudiantePage();
            EstudianteRepo = estudianteRepository;
        }
    }
}
