using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticaCRUD.Clases;

namespace PracticaCRUD
{
    public partial class estudiantepersonalizado : UserControl
    {
        Estudiante es = new Estudiante();
        Transacciones t = new Transacciones();

        public estudiantepersonalizado()
        {
            InitializeComponent();
            cargar();
        }

        private void cargar()
        {
            this.dgTabla.DataSource = t.consultar("Estudiante");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            set();
            if (t.insertar("Estudiante", this.es))
            {
                MessageBox.Show("Datos guardados");
                cargar();
            }
            else
            {
                MessageBox.Show("error al guardar");
            }


        }
        private void set()
        {
            this.es.matricula = int.Parse(txtMatricula.Text);
            this.es.nombre = txtNombre.Text;
            this.es.apellidos = txtApellidos.Text;
            this.es.direccion = txtDomicilio.Text;
            int indice = cboSexo.SelectedIndex;
            //this.es.sexo= int.Parse(cboSexo.Items[indice].ToString());
            this.es.sexo = cboSexo.Items[indice].ToString();
            this.es.edad = int.Parse(txtEdad.Text);
        }
    }
}