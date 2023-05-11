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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            RecuperarDatosConADONET();
          
          
        }

        public void RecuperarDatosConADONET()
        {
            try
            {
                //Creamos una lista donde se guardan todas las filas recuperadas
                List<Alumno> alumnos = new List<Alumno>();
                //Creamos la cadena de conexion SQLConnection es especifica para SQL Server
                SqlConnection conn = new SqlConnection(Shared.CONNECTION_STRING);
                //Creamos el comando con nuestra consulta
                SqlCommand cmd = new SqlCommand("SELECT a.Id, a.Nombre, b.Nombre as NombreCurso, a.Edad FROM Alumno a INNER JOIN Curso b ON a.IdCurso = b.Id", conn);
                //Abrimos conexion
                conn.Open();
                //Creamos un dataReader
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        alumnos.Add(new Alumno
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            NombreCurso = reader.GetString(2),
                            Edad = reader.GetInt32(3)
                        });
                    }
                }
                //Asignamos la lista generada hacía nuestro elemento ListBox en la interfaz gráfica
                myDataGrid.ItemsSource= alumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow insertWindow = new InsertWindow();
            insertWindow.Closed += InsertWindow_Closed;
            insertWindow.ShowDialog();

        }

        private void InsertWindow_Closed(object? sender, EventArgs e)
        {
            RecuperarDatosConADONET();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

            int id = ((Alumno)myDataGrid.SelectedItem).Id;
            UpdateWindow updateWindow = new UpdateWindow(id);
            updateWindow.Closed += InsertWindow_Closed;
            updateWindow.ShowDialog();


        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Alumno)myDataGrid.SelectedItem).Id;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro que deseas eliminar el registro?", "Confirmacion de borrado", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult.HasFlag(System.Windows.MessageBoxResult.Yes))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Shared.CONNECTION_STRING);
                    //Creamos el comando con nuestra consulta
                    SqlCommand cmd = new SqlCommand("DELETE FROM Alumno WHERE Id=@Id", conn);
                    //Abrimos conexion
                    conn.Open();
                    //Incluimos los parametros que en la consulta se representa con @ antes del nombre.
                    cmd.Parameters.Add(new SqlParameter("Id", id));
                    //Ejecutamos la consulta
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("El elemento ha sido eliminado");
                        RecuperarDatosConADONET();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Algo salio mal " + ex.Message);
                }
            }

        }
    }
}
