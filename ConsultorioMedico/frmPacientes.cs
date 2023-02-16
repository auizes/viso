using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//Importando para janela do prejetoa biblioteca dos correios
using Correios.NET;

namespace ConsultorioMedico
{
    public partial class frmPacientes : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);


        public void desabilitarCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            mskCPF.Enabled = false;
            mskTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
        }

        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;
            txtNome.Focus();
        }

        public void LimparCampos()
        {
            txtNome.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text= "";
            mskCEP.Text = "";
            mskCPF.Text = "";
            mskTelefone.Text = "";
            cbbEstado.Text = "";
        }


        //Método para carregar a comboBox estado
        public void CarregarComboBox()
        {
            cbbEstado.Items.Add("");
            cbbEstado.Items.Add("SP");
            cbbEstado.Items.Add("RJ");
            cbbEstado.Items.Add("BH");
            cbbEstado.Items.Add("SC");
            cbbEstado.Items.Add("RN");

        }

        //Contrutor da classe

        public frmPacientes()
        {
            InitializeComponent();
            desabilitarCampos();
            CarregarComboBox();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //executando o metodo verificarCampo
            verificarCampo();
        }

        //crinado o metodo para verificar campo vazio
        public void verificarCampo()
        {
            //if (txtNome.Text == "")
            //{
            //    MessageBox.Show("Favor inserir valores");
            //}
            //else if (txtEmail.Text == "")
            //{
            //    MessageBox.Show("Favor inserir valores");
            //}

            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")
                || mskTelefone.Text.Equals("(  )      -")
                || mskCPF.Text.Equals("   .   .   -")
                || txtEndereco.Text.Equals("") || mskCEP.Text.Equals("     -")
                || txtBairro.Text.Equals("") || txtCidade.Text.Equals("")
                || cbbEstado.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores!!!", "Menssagem do sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNome.Focus();
            }
            else
            {
                MessageBox.Show("Cadastrado com sucesso!!!",
                    "messagem do Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                    desabilitarCampos();
                    LimparCampos();

            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtNome.Focus();
        }

        private void btnCarregaendereco_Click(object sender, EventArgs e)
        {
            
        }

        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
