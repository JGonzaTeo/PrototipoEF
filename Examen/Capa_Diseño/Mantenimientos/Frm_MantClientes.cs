using Capa_Diseño.Consulta;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Diseño.Mantenimientos
{
    public partial class Frm_MantClientes : Form
    {

        Logica logic = new Logica();
        string scampo;
        public Frm_MantClientes()
        {
            InitializeComponent();
            scampo = logic.siguiente("clientes", "codigo_cliente");
            Txt_Codigo.Text = scampo;
            bloquearTXT();
        }
        void bloquearTXT()
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, Txt_direccion, Txt_Telefono, Txt_nit, Txt_Telefono, Txt_vendedor }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = false;
            }
            //COMBO QUE USARAN 
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            for (int i = 0; i < comboBox.Length; i++)
            {
                comboBox[i].Enabled = false;
            }
        }
        private int validarTXT(TextBox[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (string.IsNullOrEmpty(list[i].Text))
                {
                    MessageBox.Show("Debe completar la informacion en el campo " + list[i].Name);
                    return 0;
                }
            }
            return 1;
        }
        void limpiarTXT(TextBox[] txtBox, ComboBox[] comboBo)
        {
            //Aqui se limpian los txt
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Text = "";
            }
            //Aqui colocamos el siguiente codigo de la tabla y su llave primaria 
            scampo = logic.siguiente("aulas", "codigo_aula");
            Txt_Codigo.Text = scampo;
            if (Cbo_estado.Text != "")
            {
                Cbo_estado.Text = "Activo";
            }
            else
            {
                Cbo_estado.Text = "Inactico";
            }
        }
        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, Txt_direccion, Txt_Telefono, Txt_nit, Txt_Telefono, Txt_vendedor }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = true;
            }
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            for (int i = 0; i < comboBox.Length; i++)
            {
                comboBox[i].Enabled = true;
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            //COMBO QUE USARAN 
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre,Txt_direccion,Txt_Telefono,Txt_nit,Txt_Telefono,Txt_vendedor }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            if (validarTXT(txtBox) == 0)
                return;
            else
            {
                if (Cbo_estado.Text == "Activo")
                {
                    Cbo_estado.Text = "1";
                }
                else
                {
                    Cbo_estado.Text = "0";
                }
                //Aqui se declara la tabla donde se ira a modificar y en el segundoa arreglo, se debe de colocar los nombre de los campos.
                string[] valores = { "clientes", Txt_Codigo.Text, Txt_nombre.Text,Txt_direccion.Text,Txt_nit.Text,Txt_Telefono.Text,Txt_vendedor.Text, Cbo_estado.Text };
                string[] campos = { "codigo_cliente", "nombre_cliente", "direccion_cliente", "nit_cliente", "telefono_cliente", "codigo_vendedor", "estatus_cliente" };
                if (logic.Modificar(valores, campos) == null)
                    MessageBox.Show("Ocurrio un error al modificar los datos.");
                else
                {
                    MessageBox.Show("Datos modificados exitosamente.");
                    limpiarTXT(txtBox, comboBox); //Si usamos combo, debemos de enviarselo aqui a la funcion y declarar a la funcion que recibe
                    bloquearTXT();
                }
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            //Primero debemos de validar si los txt vienen vacios
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
                                                  //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
                                                  //Primero debemos de validar si los txt vienen vacios
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, Txt_direccion, Txt_Telefono, Txt_nit, Txt_Telefono, Txt_vendedor }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            if (validarTXT(txtBox) == 0)
                return;
            else
            {
                if (Cbo_estado.Text == "Activo")
                {
                    Cbo_estado.Text = "1";
                }
                else
                {
                    Cbo_estado.Text = "0";
                }
                //Aqui se declara la tabla donde se ira a insertar y los txt que se guardaran en el orden de la tabla
                string[] valores = { "clientes", Txt_Codigo.Text, Txt_nombre.Text, Txt_direccion.Text, Txt_nit.Text, Txt_Telefono.Text, Txt_vendedor.Text, Cbo_estado.Text };
                if (logic.Insertar(valores) == null)
                    MessageBox.Show("Ocurrio un error al guardar los datos.");
                else
                {
                    MessageBox.Show("Datos guardados exitosamente.");
                    limpiarTXT(txtBox, comboBox); //Si usamos combo, debemos de enviarselo aqui a la funcion y declarar a la funcion que recibe
                    bloquearTXT();
                }
            }
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            //COMBO QUE USARAN 
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
                                                  //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
                                                  //Primero debemos de validar si los txt vienen vacios
            TextBox[] txtBox = { Txt_Codigo, Txt_nombre, Txt_direccion, Txt_Telefono, Txt_nit, Txt_Telefono, Txt_vendedor }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            string[] valores = { "clientes", Txt_Codigo.Text, "codigo_cliente" };
            if (logic.Eliminar(valores) == null)
                MessageBox.Show("Ocurrio un error al borrar los datos.");
            else
            {
                MessageBox.Show("Datos eliminados exitosamente.");
                limpiarTXT(txtBox, comboBox); //Si usamos combo, debemos de enviarselo aqui a la funcion y declarar a la funcion que recibe
                bloquearTXT();
            }
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            Frm_consultacliente curriculum = new Frm_consultacliente();
            curriculum.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Frmconsultavendedor curriculum = new Frmconsultavendedor();
            curriculum.ShowDialog();

            if (curriculum.DialogResult == DialogResult.OK)
            {
                Txt_vendedor.Text = curriculum.Dgv_consulta.Rows[curriculum.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();

            }
        }
    }
}
