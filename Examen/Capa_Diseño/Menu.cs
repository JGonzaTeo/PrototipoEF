using Capa_Diseño.Mantenimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Diseño
{
    public partial class Menu : Form
    {
        private int childFormNumber = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        bool ventanacurso = false;
        Frm_Mantlineas curso = new Frm_Mantlineas();
        private void LineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantlineas);
            if (ventanacurso == false || frmC == null)
            {
                if (frmC == null)
                {
                    curso = new Frm_Mantlineas();
                }

                curso.MdiParent = this;
                curso.Show();
                Application.DoEvents();
                ventanacurso = true;
            }
            else
            {
                curso.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }

        }


        bool ventanacurso1 = false;
        Frm_Mantmarcas curso1 = new Frm_Mantmarcas();

        private void MarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantmarcas);
            if (ventanacurso1 == false || frmC == null)
            {
                if (frmC == null)
                {
                    curso1 = new Frm_Mantmarcas();
                }

                curso1.MdiParent = this;
                curso1.Show();
                Application.DoEvents();
                ventanacurso1 = true;
            }
            else
            {
                curso1.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanacurso2 = false;
        Frm_MantProducto curso2 = new Frm_MantProducto();
        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_MantProducto);
            if (ventanacurso2 == false || frmC == null)
            {
                if (frmC == null)
                {
                    curso2 = new Frm_MantProducto();
                }

                curso2.MdiParent = this;
                curso2.Show();
                Application.DoEvents();
                ventanacurso2 = true;
            }
            else
            {
                curso2.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }



        bool ventanacurso3 = false;
        Frm_MantClientes curso3 = new Frm_MantClientes();
        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_MantClientes);
            if (ventanacurso3 == false || frmC == null)
            {
                if (frmC == null)
                {
                    curso3 = new Frm_MantClientes();
                }

                curso3.MdiParent = this;
                curso3.Show();
                Application.DoEvents();
                ventanacurso3 = true;
            }
            else
            {
                curso3.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanacurso4 = false;
        Frm_Vendedores curso4 = new Frm_Vendedores();
        private void VendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Vendedores);
            if (ventanacurso4 == false || frmC == null)
            {
                if (frmC == null)
                {
                    curso4 = new Frm_Vendedores();
                }

                curso4.MdiParent = this;
                curso4.Show();
                Application.DoEvents();
                ventanacurso4 = true;
            }
            else
            {
                curso4.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
        bool ventanacurso5 = false;
        Frm_MantProveedores curso5 = new Frm_MantProveedores();
        private void ProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_MantProveedores);
            if (ventanacurso4 == false || frmC == null)
            {
                if (frmC == null)
                {
                    curso5 = new Frm_MantProveedores();
                }

                curso5.MdiParent = this;
                curso5.Show();
                Application.DoEvents();
                ventanacurso5 = true;
            }
            else
            {
                curso5.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
