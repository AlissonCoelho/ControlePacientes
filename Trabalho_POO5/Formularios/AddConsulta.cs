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
using System.Xml.Linq;

namespace Trabalho_POO.Formularios
{
    public partial class AddConsulta : Form
    {
        DateTime agora = DateTime.Now;
        string AnoNow;
        Consulta MinhaConsulta;
        public AddConsulta()
        {
            InitializeComponent();
            ObterNomes();
            AnoNow = Convert.ToString(agora.Year);
            //exibe o campo "texData" com o ano atual fixado
            texData.Text = $"  /  /{AnoNow}";
        }

        public void ObterNomes()
        {
            //Obtém os nomes contidos no arquivo xml "Paciente"
            bindingSourceNome.DataSource = Geral<Paciente>.DesserializarXML("Paciente", null);
        }

        private void botSalvarClient_Click(object sender, EventArgs e)
        {

            Verificar();
        }

        public bool SalvarConsultas()
        {
            //se algum campo não for preenchido
            if (texNome.Text == "" || texData.Text == $"  /  /{AnoNow}" || texHorario.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Preencher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            int Dia;
            int Mes;
            int Ano;
            int Hora;
            //Foi necessário criar duas variaves do tipo DateTime
            //será exibida no DataGrid
            DateTime DataConsulta;
            //Será usada para verificação na linha 81 - Data + horário
            DateTime DataConsulta2;

            DateTime agora = DateTime.Now;

            try
            {
                Dia = Convert.ToInt16(texData.Text.Substring(0, 2));
                Mes = Convert.ToInt16(texData.Text.Substring(3, 2));
                Ano = Convert.ToInt16(texData.Text.Substring(6, 4));
                Hora = Convert.ToInt16(texHorario.Text.Substring(0, 2));
                DataConsulta = new DateTime(Ano, Mes, Dia);
                DataConsulta2 = new DateTime(Ano, Mes, Dia, Hora, 0, 0);
            }
            //caso a data não esteja em formato correto
            catch (Exception e)
            {
                MessageBox.Show("Preencher campo 'Data' no formato DD/MM/AAAA", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            
            TimeSpan difTempo = DataConsulta2 - agora;
            //Verifica se a data marcada é maior que a data atual
            if (difTempo.TotalDays <= 0)
            {
                MessageBox.Show("Data tem que ser maior que data atual", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Desserializa arquivo xml " Consulta" para o tipo List
            List<Consulta> ConsultExistentes = Geral<Consulta>.DesserializarXML("Consulta", null);
            //Verifica se existe outra consulta marcada na mesma data e horário
            foreach (Consulta cs in ConsultExistentes)
            {
                if (cs.Data== DataConsulta && cs.Horario== texHorario.Text)
                {
                    MessageBox.Show("Horario já marcado", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            MinhaConsulta = new Consulta();
            MinhaConsulta.Codigo = Geral<Consulta>.GerarCodigo("Consulta", "CT");
            MinhaConsulta.Nome = texNome.Text;
            MinhaConsulta.Data = DataConsulta;
            MinhaConsulta.Horario = texHorario.Text;



            if (Geral<Consulta>.AdicionarElemento("Consulta", MinhaConsulta) == false)
            {
                MessageBox.Show("Falha ao marcar Consulta", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            return true;
        }

        //Ocorre quando o enter é pressionado dentro do texHorario
        private void texHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Verificar();
            }
        }

        private void Verificar()
        {
            //Se retornar true
            if (SalvarConsultas())
            {
                MessageBox.Show("Consulta Marcada", "Ok", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
                //Dados a serem salvos  no arquivo Relatorio
                Relatorio MeuRelatorio = new Relatorio();
                MeuRelatorio.Evento = "Consulta Marcada";
                MeuRelatorio.Informações = $"Consulta de código {MinhaConsulta.Codigo} marcada para o paciente {MinhaConsulta.Nome}" +
                    $" no dia {MinhaConsulta.Data.Day}/{MinhaConsulta.Data.Month}/{MinhaConsulta.Data.Year} às {MinhaConsulta.Horario}";
                MeuRelatorio.Data = DateTime.Now;
                MeuRelatorio.Data = new DateTime(MeuRelatorio.Data.Year, MeuRelatorio.Data.Month, MeuRelatorio.Data.Day,
                                             MeuRelatorio.Data.Hour, MeuRelatorio.Data.Minute, MeuRelatorio.Data.Second);

                //Adiciona elememto no arquivo relatorio
                Geral<Relatorio>.AdicionarElemento("Relatorio", MeuRelatorio);
            }

        }

        private void AddConsulta_Load(object sender, EventArgs e)
        {

        }
    }
}
