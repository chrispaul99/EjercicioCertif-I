using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIEjercicio
{
    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();
        }

        private void cargarListado()
        {
            this.lstAlumnos.DataSource = null;
            List<Alumno> alumnos = AlumnoBLL.List();
            lstAlumnos.DataSource = alumnos;
        }


        private void frmAlumno_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno a = new Alumno
                {
                    apellidos = txtApellido.Text.Trim(),
                    cedula = txtCedula.Text.Trim(),
                    nombres = txtNombre.Text.Trim(),
                    lugar_nacimiento = txtLugar.Text.Trim(),
                    sexo = rbMasculino.Checked ? "M" : "F",
                    fecha_nacimiento = dtpFecha.Value
                };
                AlumnoBLL.Create(a);
                cargarListado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}