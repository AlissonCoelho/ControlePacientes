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
    public partial class EditarConsulta : Form
    {
        Consulta MConsulta; //Cria uma instância da classe Consulta
        Consulta ConsultaEdit;

        //É passado por parâmetro as informações presentes no DataGridView da linha selecionada
        public EditarConsulta(Consulta dados)
        {

            InitializeComponent();

            MConsulta = dados; 

            ObterNomes();
            //Exibe no Formulario "Editar Consultas" os dados passados por parâmetros
            texNome.Text = dados.Nome;
            texData.Text = string.Format("{0:dd/MM/yyyy}", dados.Data);
            texHorario.Text = dados.Horario;
        }

        public void ObterNomes()
        {
            //Desserializa arquivo xml e retorna uma lista com nomes 
            bindingSourceNome.DataSource = Geral<Paciente>.DesserializarXML("Paciente", null);
        }

        private bool SalvarConsulta()
        {
            //se algum campo não for preenchido
            if (texNome.Text == "" || texData.Text == "" || texHorario.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Preencher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

           
            int Dia;
            int Mes;
            int Ano;
            DateTime Dt;
            try
            {
                Dia = Convert.ToInt16(texData.Text.Substring(0, 2));
                Mes = Convert.ToInt16(texData.Text.Substring(3, 2));
                Ano = Convert.ToInt16(texData.Text.Substring(6, 4));
                Dt = new DateTime(Ano, Mes, Dia);

            }
            //caso a data não esteja em formato correto
            catch (Exception e)
            {
                MessageBox.Show("Preencher campo 'Data' no formato DD/MM/AAAA", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            
            ConsultaEdit = new Consulta();
            ConsultaEdit.Codigo = MConsulta.Codigo;
            ConsultaEdit.Nome = texNome.Text;
            ConsultaEdit.Data = Dt;
            ConsultaEdit.Horario = texHorario.Text;
           

            //Compara se os dados editados  são iguais aos antigos
            if (MConsulta == ConsultaEdit)
            {
                return false;
            }

            if (Geral<Consulta>.Editar("Consulta", ConsultaEdit, MConsulta) == false)
            {
                MessageBox.Show("Falha ao alterar Consulta", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            return true;
        }

        //Verifica e Salva em arquivo xml
        private void Verificar()
        {
            if (SalvarConsulta())
            {
                MessageBox.Show("Consulta Alterada", "Ok", MessageBoxButtons.OK, MessageBoxIcon.None);
                
            }
        }

        private void botSalvarClient_Click(object sender, EventArgs e)
        {
            Verificar();
            this.Close();
        }
    }
}
