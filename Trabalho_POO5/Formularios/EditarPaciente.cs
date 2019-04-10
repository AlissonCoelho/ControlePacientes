using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_POO.Classes;

namespace Trabalho_POO.Formularios
{
    public partial class EditarPaciente : Form
    {
        //Cria uma intância da classe paciente
        Paciente MeuPaciente; 
        Paciente PacienteEditado;

        //É passado por parâmetro as informações presentes no DataGridView da linha selecionada
        public EditarPaciente(Paciente dados)
        {
            InitializeComponent();

           MeuPaciente = dados;
            //Exibe no Formulario "Editar Paciente" os dados passados por parâmetros
            texNome.Text = dados.Nome ;
            texLogra.Text = dados.Logradouro ;
            texNum.Text = dados.Numero ;
            texCidade.Text = dados.Cidade  ;
            texBairro.Text = dados.Bairro  ;
            texEstado.Text = dados.Estado  ;
            texTel.Text = dados.Telefone  ;
            texEmail.Text = dados.Email ;
            texNascimento.Text = string.Format("{0:dd/MM/yyyy}", dados.Nascimento);



        }

        //Salvar Paciente
        private bool SalvarPaciente()
        {
            //algum campo não for preenchido
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
            //Caso a data não esteja em formato correto
            catch (Exception e)
            {
                MessageBox.Show("Preencher campo 'Nascimento' no formato DD/MM/AAAA", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            PacienteEditado = new Paciente();
            PacienteEditado.Codigo = MeuPaciente.Codigo;
            PacienteEditado.Nome = texNome.Text;
            PacienteEditado.Logradouro = texLogra.Text;
            PacienteEditado.Numero = texNum.Text;
            PacienteEditado.Cidade = texCidade.Text;
            PacienteEditado.Bairro = texBairro.Text;
            PacienteEditado.Estado = texEstado.Text;
            PacienteEditado.Telefone = texTel.Text;
            PacienteEditado.Email = texEmail.Text;
            PacienteEditado.Nascimento = Nascimento;

            //Compara se os dados editados  são iguais aos antigos
            if (MeuPaciente == PacienteEditado)
            {
                return false;
            }

            //Caso ocorra algum erro na execução da função "Editar"
            if (Geral<Paciente>.Editar("Paciente", PacienteEditado, MeuPaciente) == false)
            {
                MessageBox.Show("Falha ao editar Paciente", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        //Verifica e Salva em arquivo xml
        private void Verificar()
        {
            //Se a função "SalvarPaciente" retornar "true" exibe a mensagem:
            if (SalvarPaciente())
            {
                MessageBox.Show("Paciente Editado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.None);
             
            }
        }

        private void botSalvarClient_Click_1(object sender, EventArgs e)
        {
            Verificar();
            this.Close(); //Fecha o formulário
        }
    }
}
