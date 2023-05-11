using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        public InsertWindow()
        {
            InitializeComponent();
            RecuperarCursos();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Shared.CONNECTION_STRING);
                //Creamos el comando con nuestra consulta
                SqlCommand cmd = new SqlCommand("INSERT INTO Alumno (Nombre, IdCurso, Edad) VALUES (@Nombre, @IdCurso, @Edad)", conn);
                //Abrimos conexion
                conn.Open();
                //Incluimos los parametros que en la consulta se representa con @ antes del nombre.
                cmd.Parameters.Add(new SqlParameter("Nombre", txtNombre.Text));
                cmd.Parameters.Add(new SqlParameter("IdCurso", comboCurso.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("Edad", txtEdad.Text));
                //Ejecutamos la consulta
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Algo salio mal " + ex.Message);
            }
        }

        public void RecuperarCursos()
        {
            try
            {
                //Creamos una lista donde se guardan todas las filas recuperadas
                List<Curso> alumnos = new List<Curso>();
                //Creamos la cadena de conexion SQLConnection es especifica para SQL Server
                SqlConnection conn = new SqlConnection(Shared.CONNECTION_STRING);
                //Creamos el comando con nuestra consulta
                SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Curso", conn);
                //Abrimos conexion
                conn.Open();
                //Creamos un dataReader
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        alumnos.Add(new Curso
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }
                }
                //Asignamos la lista generada hacía nuestro elemento ListBox en la interfaz gráfica
                comboCurso.ItemsSource = alumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message);
            }

        }
    }


}
