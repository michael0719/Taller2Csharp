using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Taller2CShap2
{
    public partial class Form1 : Form
    {
        ClsAlumnos objAlumnos = null;
        ClsAlumnosData objAlumnosData = null;
        DataTable Dtt = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            objAlumnos = new ClsAlumnos();
            objAlumnos.opc = 1;
            objAlumnosData = new ClsAlumnosData(objAlumnos);
            Dtt = new DataTable();
            Dtt = objAlumnosData.Listar();
            if (Dtt.Rows.Count > 0)
            {
                Dgvalumnos.DataSource = Dtt;
            }
        }

        private void Guardar()
        {
            int Op = 0;
            if (cbgrado.SelectedItem.ToString() == "Primero")
            {
                Op = 1;
            }else if(cbgrado.SelectedItem.ToString() == "Segundo")
            {
                Op = 2;
            }
            else if (cbgrado.SelectedItem.ToString() == "Tercero")
            {
                Op = 3;
            }
            else if (cbgrado.SelectedItem.ToString() == "Cuarto")
            {
                Op = 4;
            }
            else if (cbgrado.SelectedItem.ToString() == "Quinto")
            {
                Op = 5;
            }
            if (Op != 0)
            {
                objAlumnos = new ClsAlumnos();
                objAlumnos.opc = 2;
                objAlumnos.Nuip = Convert.ToSByte(txtnuip.Text);
                objAlumnos.Nombre = txtnombre.Text;
                objAlumnos.apellido = txtApellido.Text;
                objAlumnos.Edad = Convert.ToSByte(txtEdad.Text);
                objAlumnos.Grado =Convert.ToSByte(Op);
                objAlumnosData = new ClsAlumnosData(objAlumnos);
                objAlumnosData.GuardarDatos();
                MessageBox.Show("La informacion del alumno se guardo exitosamente","Mensaje");
            }
            else
            {
                MessageBox.Show("Elija un grado");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            btnEliminar.Enabled = false; 
            LimpiarCampos();
            txtnuip.Focus();
           
        }

        private void Dgvalumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtnuip.Text = Dgvalumnos.Rows[Dgvalumnos.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = Dgvalumnos.Rows[Dgvalumnos.CurrentRow.Index].Cells[1].Value.ToString();
            txtApellido.Text = Dgvalumnos.Rows[Dgvalumnos.CurrentRow.Index].Cells[2].Value.ToString();
            txtEdad.Text = Dgvalumnos.Rows[Dgvalumnos.CurrentRow.Index].Cells[3].Value.ToString();
            cbgrado.Text = Dgvalumnos.Rows[Dgvalumnos.CurrentRow.Index].Cells[4].Value.ToString();
            cbgrado.Enabled = false;
            txtnombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEdad.Enabled = false;
            txtnuip.Enabled = false;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        public void Eliminar()
        {
            objAlumnos = new ClsAlumnos();
            objAlumnos.opc = 3;
            objAlumnos.Nuip = Convert.ToInt16(txtnuip.Text);
            objAlumnosData = new ClsAlumnosData(objAlumnos);
            objAlumnosData.EliminarDatos();
            MessageBox.Show("Alumno eliminado","Mensaje");
        }

        public void LimpiarCampos()
        {
            txtnuip.Clear();
            txtnombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            cbgrado.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            LimpiarCampos();
            txtnuip.Focus();
            btnGuardar.Enabled = true;
            txtnuip.Enabled = true;
            txtnombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEdad.Enabled = true;
            cbgrado.Enabled = true;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            Listar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Listar();
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            txtnuip.Enabled = true;
            txtnombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEdad.Enabled = true;
            cbgrado.Enabled = true;
            txtnuip.Focus();
        }
    }
}
