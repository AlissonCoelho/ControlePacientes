using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_POO.Classes;

namespace Trabalho_POO.Formularios
{
    public partial class AddPaciente : Form
    {
        Paciente MeuPaciente; //Cria uma instância da classe Paciente 
        public AddPaciente()
        {
            InitializeComponent();
        }

        private void botSalvarClient_Click(object sender, EventArgs e)
        {
            Verificar(); //Chama a função "verificar"
        }

        private bool SalvarPaciente()
        {
            //se algum campo não for preenchido
            if (texNome.Text == "" || texLogra.Text == "" || texNum.Text == "" || texCidade.Text == ""
                || texBairro.Text == "" || texEstado.Text == "" || texTel.Text == "" || texEmail.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Preencher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            long verific1;
            //campo "Numero" somente com numeros
            if (!long.TryParse(texNum.Text, out verific1))
            {
                MessageBox.Show("Preencher campo 'Número' somente com números", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //campo "Telefone" com 14 ou 15 caracteres
            if (texTel.Text.Length != 14 && texTel.Text.Length != 15)
            {
                MessageBox.Show("Preencher campo 'Telefone': '(xx) xxxx-xxxx'", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            int Dia;
            int Mes;
            int Ano;
            DateTime Nascimento;
            try
            {
                Dia = Convert.ToInt16(texNascimento.Text.Substring(0, 2));
                Mes = Convert.ToInt16(texNascimento.Text.Substring(3, 2));
                Ano = Convert.ToInt16(texNascimento.Text.Substring(6, 4));
                Nascimento = new DateTime(Ano, Mes, Dia);

            }
            //caso a data não esteja em formato correto
            catch (Exception e)
            {
                MessageBox.Show("Preencher campo 'Nascimento' no formato DD/MM/AAAA", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            MeuPaciente = new Paciente();
            MeuPaciente.Codigo = Geral<Paciente>.GerarCodigo("Paciente", "PC");
            MeuPaciente.Nome = texNome.Text;
            MeuPaciente.Logradouro = texLogra.Text;
            MeuPaciente.Numero = texNum.Text;
            MeuPaciente.Cidade = texCidade.Text;
            MeuPaciente.Bairro = texBairro.Text;
            MeuPaciente.Estado = texEstado.Text;
            MeuPaciente.Telefone = texTel.Text;
            MeuPaciente.Email = texEmail.Text;
            MeuPaciente.Nascimento = Nascimento;


            //Ocorre quando dentro da Função "AdicionarElemento" se encontra algum erro
            if (Geral<Paciente>.AdicionarElemento("Paciente", MeuPaciente) == false)
            {
                MessageBox.Show("Falha ao cadastrar Paciente", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            return true;
        }

        //Ocorre quando pressiona enter dentro do textbox "Nascimento"
        private void texNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Verificar();
            }
        }

        private void Verificar()
        {
            //Se retornar true
            if (SalvarPaciente())
            {
                MessageBox.Show("Paciente Salvo", "Ok", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
                //gerar relatório 
                Relatorio MeuRelatorio = new Relatorio();
                //Dados a serem salvos  no arquivo Relatorio
                MeuRelatorio.Evento = "Paciente Cadastrado";
                MeuRelatorio.Informações = $"Paciente de código {MeuPaciente.Codigo} e nome { MeuPaciente.Nome} cadastrado";
                MeuRelatorio.Data = DateTime.Now;
                MeuRelatorio.Data = new DateTime(MeuRelatorio.Data.Year, MeuRelatorio.Data.Month, MeuRelatorio.Data.Day,
                                             MeuRelatorio.Data.Hour, MeuRelatorio.Data.Minute, MeuRelatorio.Data.Second);

                //Adiciona elememto no arquivo relatorio
                Geral<Relatorio>.AdicionarElemento("Relatorio", MeuRelatorio);
            }
        }
    }
}
