using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Renomeator
{
    public partial class Form1 : Form
    {
        private int contador;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            tbPath.Text = fbd.SelectedPath;
        }

        private void btnRenomear_Click(object sender, EventArgs e)
        {
            contador = 0;

            try
            {
                if (checkAcomAcento.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Á", "A");
                }
                if (checkEcomAcento.Checked)
                {
                    RenomearArquivos(tbPath.Text, "É", "E");
                }
                if (checkIcomAcento.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Í", "I");
                }
                if (checkOcomAcento.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Ó", "O");
                }
                if (checkUcomAcento.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Ú", "U");
                }
                if (checkCedilha.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Ç", "C");
                }
                if (checkAcomTio.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Ã", "A");
                }
                if (checkOcomTio.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Õ", "O");
                }
                if (checkEcomCircunflexo.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Ê", "E");
                }
                if (checkOcomCircunflexo.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Ô", "O");
                }
                if (checkAcomCrase.Checked)
                {
                    RenomearArquivos(tbPath.Text, "À", "A");
                }
                if (checkUcomTrema.Checked)
                {
                    RenomearArquivos(tbPath.Text, "Ü", "U");
                }
                if (checkHifen.Checked)
                {
                    RenomearArquivos(tbPath.Text, "-", "_");
                }

                if (contador > 0)
                {
                    MessageBox.Show(contador + " arquivos renomeados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Não existem arquivos a serem renomeados.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao renomear arquivos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void RenomearArquivos(string path, string oldChar_, string newChar_)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] arquivos = dirInfo.GetFiles();

            foreach (FileInfo f in arquivos)
            {
                if(f.Name.Contains(oldChar_) || f.Name.Contains(oldChar_.ToLower()))
                {
                    string nomeInicial = f.Name;
                    string nomeFinal = string.Empty;
                    nomeFinal = f.Name.Replace(oldChar_, newChar_).Replace(oldChar_.ToString().ToLower(), newChar_.ToString().ToLower());
                    Directory.Move(path + "\\" + nomeInicial, path + "\\" + nomeFinal);
                    contador++;
                }
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked)
            {
                foreach (Control c in groupBoxOpcoes.Controls)
                {
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control c in groupBoxOpcoes.Controls)
                {
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
        }
    }
}
