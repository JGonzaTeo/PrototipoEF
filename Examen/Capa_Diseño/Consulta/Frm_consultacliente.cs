﻿using Capa_Logica;
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

namespace Capa_Diseño.Consulta
{
    public partial class Frm_consultacliente : Form
    {
        Logica logic = new Logica();
        public Frm_consultacliente()
        {
            InitializeComponent();
            Dgv_consulta.Rows.Clear();
            MostrarConsulta();
        }

        public void MostrarConsulta()
        {
            OdbcDataReader mostrar = logic.consultacurso("clientes");
            try
            {
                while (mostrar.Read())
                {
                    Dgv_consulta.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5), mostrar.GetString(6));
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

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {

            if (Dgv_consulta.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
