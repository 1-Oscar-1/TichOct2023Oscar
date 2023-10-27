using ADOWinForms.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ADOWinForms.ADO;

namespace ADOWinForms
{
    public partial class frmEstatusAlumnos : Form
    {
        public static string[] btnGEText = {"Guardar", "Editar", "Eliminar"};
        // Lista de datos
        public static List<EstatusAlumno> listEstatus = new List<EstatusAlumno>();
        // conection
        public static string _cnnString = ConfigurationManager.ConnectionStrings["dbTichConection"].ConnectionString;
        // Se traen los metodos
        ADOEstatusAlumno metodos = new ADOEstatusAlumno();
        public frmEstatusAlumnos()
        {
            InitializeComponent();
        }
        private void frmEstatusAlumnos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            listEstatus = metodos.Consultar();

            // Se carga el comboBox
            comboBox.DataSource = listEstatus.ToArray();
            comboBox.DisplayMember = "nombre";
            comboBox.ValueMember = "id";

            // Se carga el dataGridView
            dataGridView.DataSource = listEstatus.ToArray();
        }
        public void FinalizarProceso()
        {
            // Se oculta el panel
            panel.Visible = false;

            // Se desactivan los botones principales
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;

            // Se limpian los textBox
            textBoxNombre.Clear();
            textBoxClave.Clear();
            textBoxId.Clear();

            // Se visualizan los id
            textBoxId.Visible = true;
            label3.Visible = true;

            // Se desactivan los botones
            textBoxClave.Enabled = true;
            textBoxId.Enabled = true;
            textBoxNombre.Enabled = true;

            // Se vuelven a cargar los datos
            CargarDatos();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Se visualiza el panel
            panel.Visible = true;
            
            // Se desactivan los botones principales
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            // Se le agregar valor a eliminar
            btnGuardarEliminar.Text = btnGEText[0];
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Se oculta el panel
            panel.Visible = false;

            // Se desactivan los botones principales
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;

            // Se limpian los textBox
            textBoxNombre.Clear();
            textBoxClave.Clear();
            textBoxId.Clear();

            // Se activa el id
            textBoxId.Visible = true;
            label3.Visible = true;

            // Se desactivan los botones
            textBoxClave.Enabled = true;
            textBoxId.Enabled = true;
            textBoxNombre.Enabled = true;
        }

        private void btnGuardarEliminar_Click(object sender, EventArgs e)
        {
            switch (btnGuardarEliminar.Text)
            {
                case "Guardar":
                    metodos.Agregar(new EstatusAlumno(Convert.ToInt32(textBoxId.Text), textBoxClave.Text.ToUpper(), textBoxNombre.Text));
                    break;
                case "Editar":
                    int idSeleccionado = (int)comboBox.SelectedValue;
                    metodos.Actualizar(new EstatusAlumno(idSeleccionado, textBoxClave.Text.ToString().ToUpper(), textBoxNombre.Text.ToString()));
                    break;
                case "Eliminar":
                    int idEliminar = (int)comboBox.SelectedValue;
                    metodos.Eliminar(idEliminar);
                    break;
                default:
                    break;
            }

            FinalizarProceso();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Se visualiza el panel
            panel.Visible = true;

            // Se desactivan los botones principales
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            // Se le agregar valor a eliminar
            btnGuardarEliminar.Text = btnGEText[1];

            // Se oculta el id
            textBoxId.Visible = false;
            label3.Visible = false;

            // Se muestran los datos
            EstatusAlumno estatus = (EstatusAlumno)comboBox.SelectedItem;
            textBoxClave.Text = estatus.clave.Trim();
            textBoxNombre.Text = estatus.nombre.Trim();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Se visualiza el panel
            panel.Visible = true;

            // Se desactivan los botones principales
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            // Se le agregar valor a eliminar
            btnGuardarEliminar.Text = btnGEText[2];

            // Se muestran los datos
            EstatusAlumno estatus = (EstatusAlumno)comboBox.SelectedItem;
            textBoxClave.Text = estatus.clave.Trim();
            textBoxNombre.Text = estatus.nombre.Trim();
            textBoxId.Text = estatus.id.ToString();

            // Se desactivan los botones
            textBoxClave.Enabled = false;
            textBoxId.Enabled = false;
            textBoxNombre.Enabled = false;
        }
    }
}
