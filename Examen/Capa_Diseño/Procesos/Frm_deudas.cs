using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Diseño.Procesos
{
    public partial class Frm_deudas : Form
    {
        Logica logic = new Logica();
        public Frm_deudas()
        {
            InitializeComponent();
            MostrarConsulta1();
            MostrarConsulta2();

        }
        public void MostrarConsulta1()
        {
            OdbcDataReader mostrar = logic.consultacuentasconatbles1();
            try
            {
                while (mostrar.Read())
                {
                    //string s = mostrar.GetString(0) + mostrar.GetString(1) + mostrar.GetString(2);
                    //Console.WriteLine(s);
                    Dgv_Clientes.Refresh();
                    Dgv_Clientes.Rows.Add(mostrar.GetString(0), "0.00", mostrar.GetString(1));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void MostrarConsulta2()
        {
            OdbcDataReader mostrar = logic.consultacuentasconatbles2();
            try
            {
                while (mostrar.Read())
                {
                    //string s = mostrar.GetString(0) + mostrar.GetString(1) + mostrar.GetString(2);
                    //Console.WriteLine(s);
                    Dgv_Proveedor.Refresh();
                    Dgv_Proveedor.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), "0.00");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }


        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
