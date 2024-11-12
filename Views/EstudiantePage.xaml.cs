using JSS6.Models;
using JSS6.Utils;
using MySql.Data.MySqlClient;

namespace JSS6.Views
{
    public partial class EstudiantePage : ContentPage  // Cambié el nombre a EstudiantePage
    {
        private MySqlConnection db;

        public EstudiantePage()  // También renombrado en el constructor
        {
            InitializeComponent();
            var fileAccessHelper = new FileAccessHelper();
            db = fileAccessHelper.GetConnection();
        }

        private void OnAgregarEstudianteClicked(object sender, EventArgs e)
        {
            var estudiante = new EstudianteModel
            {
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                Edad = int.Parse(EdadEntry.Text)
            };



            if (db.InsertarEstudiante(estudiante))  // Asegúrate de que InsertarEstudiante esté bien implementado
            {
                DisplayAlert("Éxito", "Estudiante agregado exitosamente", "OK");
            }
            else
            {
                DisplayAlert("Error", "No se pudo agregar el estudiante", "OK");
            }
        }
    }
}
