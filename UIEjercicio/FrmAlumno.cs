using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UIEjercicio
{
    public partial class FrmAlumno : Form
    {
        public FrmAlumno()
        {
            InitializeComponent();
        }

        private void FrmAlumno_Load(object sender, EventArgs e)
        {
            cargarListado();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno a = new Alumno();
                a.apellidos = txtapellido.Text.Trim();
                a.cedula = txtcedula.Text.Trim();
                a.nombres = txtnombre.Text.Trim();
                a.lugar_nacimiento = txtlugar.Text.Trim();
                a.sexo = rbmasculino.Checked ? "M" : "F";
                a.fecha_nacimiento = dtpfecha.Value;
                AlumnoBLL.Create(a);
                cargarListado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cargarListado()
        {
            dgvlistado.Rows.Clear();
            List<Alumno> alumnos = AlumnoBLL.List();
            dgvlistado.DataSource = alumnos;
        }
    }
}
