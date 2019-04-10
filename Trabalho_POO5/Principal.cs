using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_POO;
using Trabalho_POO.Classes;
using Trabalho_POO.Formularios;

namespace Trabalho_POO
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            AtualizarDadaGridPacientes(); //Ao iniciar o form, chama a função para atualizar o DGV de Pacientes.
            AtualizarDadaGridConsulta(); //Ao iniciar o form, chama a função para atualizar o DGV de Consultas.
            AtualizarDadaGridRelatorio(); //Ao iniciar o form, chama a função para atualizar o DGV de Relatório.
        }

        //Ao clicar no botão "Novo Paciente".
        private void butNewPaciente_Click(object sender, EventArgs e)
        {
            AddPaciente FormAddPaciente = new AddPaciente(); //Cria uma intância para acessar o form "AddPaciente".
            FormAddPaciente.ShowDialog(); //Exibe o formulário "AddPaciente".
            AtualizarDadaGridPacientes(); //Chama a função para atualizar o DGV de Pacientes.
        }

        //Função para atualizar o Data Grid View Pacientes.
        public void AtualizarDadaGridPacientes()
        {
            bindingSourcePaciente.DataSource = Geral<Paciente>.DesserializarXML("Paciente", null);
            //Chama a função para desserializar o XML recebendo como parâmetro o nome do arquivo
            //com isso retorna uma list que será exibida no DataSource do DGV Pacientes.
        }

        //Função para atualizar o Data Grid View Consulta.
        public void AtualizarDadaGridConsulta()
        {
            bindingSourceConsultas.DataSource = Geral<Consulta>.DesserializarXML("Consulta", null);
            //Chama a função para desserializar o XML recebendo como parâmetro o nome do arquivo
            //com isso retorna uma list que será exibida no DataSource do DGV Consulta.
        }

        //Função para atualizar o Data Grid View Relatório.
        public void AtualizarDadaGridRelatorio()
        {
            bindingSourceRelatorio.DataSource = Geral<Relatorio>.DesserializarXML("Relatorio", null);
            //Chama a função para desserializar o XML recebendo como parâmetro o nome do arquivo
            //com isso retorna uma list que será exibida no DataSource do DGV Relatorio.
        }

        //Ao clicar no botão "Nova Consulta".
        private void butNewConsulta_Click(object sender, EventArgs e)
        {
            AddConsulta FormAddConsulta = new AddConsulta(); //Cria uma intância para acessar o form "AddConsulta".
            FormAddConsulta.ShowDialog(); //Exibe o formulário "AddConsulta".
            AtualizarDadaGridConsulta(); //Chama a função para atualizar o DGV Consulta.
        }

        //Ao clicar em qualquer aba do TabControl.
        private void tabContro_Click(object sender, EventArgs e)
        {
            //Atualiza os três DGVs.
            AtualizarDadaGridRelatorio();
            AtualizarDadaGridConsulta();
            AtualizarDadaGridPacientes();
        }

        //Ao clicar no botão "Deletar Paciente".
        private void butDelPaciente_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja deletar permanentemente o paciente?", "Deletar Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //Exibe um MessageBox com opção "Sim" ou "Não".

            if (confirm.ToString().ToUpper() == "YES") //Se clicar em "Sim".
            {
                if (Geral<Paciente>.Deletar("Paciente", dataGridViewPaciente.CurrentRow.Cells[0].Value.ToString()))
                //Chama a função Deletar, passando como parâmetro o nome do arquivo e o código do paciente, presente na primeira célula da linha atual no DGV.
                {
                    //A função deletar retorna um bool, se for "true"...
                    MessageBox.Show("Paciente Deletado com sucesso!", "Deletar Paciente", //Exibe a MessageBox confirmando a exclusão.
                        MessageBoxButtons.OK, MessageBoxIcon.None);

                    //E gera um relatório. 
                    Relatorio MeuRelatorio = new Relatorio(); //Cria uma instância para acessar a classe "Relatório".
                    MeuRelatorio.Evento = "Paciente Deletado"; //Escreve na variável "Evento".
                    MeuRelatorio.Informações = $"Paciente de código {dataGridViewPaciente.CurrentRow.Cells[0].Value.ToString()} e nome {dataGridViewPaciente.CurrentRow.Cells[1].Value.ToString()} Deletado";
                    //Escreve na variável "Informações".
                    MeuRelatorio.Data = DateTime.Now;
                    MeuRelatorio.Data = new DateTime(MeuRelatorio.Data.Year, MeuRelatorio.Data.Month, MeuRelatorio.Data.Day,
                                                 MeuRelatorio.Data.Hour, MeuRelatorio.Data.Minute, MeuRelatorio.Data.Second);
                    //Escreve na variável "Data" o ano, mes, dia, hora, minuto e segundo de quando ocorreu a ação. 

                    //Adiciona elememto no arquivo relatorio.
                    Geral<Relatorio>.AdicionarElemento("Relatorio", MeuRelatorio);
                    AtualizarDadaGridPacientes();
                }
                else
                    //Se for "false", apenas atualiza o DGV Pacientes.
                    AtualizarDadaGridPacientes();
            }
        }

        //Ao clicar no botão "Editar Paciente".
        private void butEditPaciente_Click(object sender, EventArgs e)
        {
            Paciente AtualPaciente = new Paciente(); //Cria uma instância da classe "Paciente".
            AtualPaciente.Codigo = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[0].Value;
            AtualPaciente.Nome = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[1].Value;
            AtualPaciente.Logradouro = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[2].Value;
            AtualPaciente.Numero = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[3].Value;
            AtualPaciente.Cidade = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[4].Value;
            AtualPaciente.Bairro = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[5].Value;
            AtualPaciente.Estado = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[6].Value;
            AtualPaciente.Telefone = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[7].Value;
            AtualPaciente.Email = (string)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[8].Value;
            AtualPaciente.Nascimento = (DateTime)dataGridViewPaciente.Rows[dataGridViewPaciente.SelectedCells[0].RowIndex].Cells[9].Value;
            //Joga em todas as váriáveis acima, as respectivas informações presentes no DGV, na linha selecionada.

            EditarPaciente FormEditarPaciente = new EditarPaciente(AtualPaciente); //Cria uma instância para acessar o form "Editar Paciente", passando "AtualPaciente" como parâmetro.
            FormEditarPaciente.ShowDialog(); //Exibe o form "Editar Paciente".
            AtualizarDadaGridPacientes(); //Atualiza o DGV Pacientes.
        }

        //Ao Clicar no botão "Editar Consulta".
        private void button1_Click(object sender, EventArgs e)
        {
            Consulta AtualConsulta = new Consulta(); //Cria uma instância da classe "Consulta".
            AtualConsulta.Codigo = (string)dataGridViewConsultas.Rows[dataGridViewConsultas.SelectedCells[0].RowIndex].Cells[0].Value;
            AtualConsulta.Nome = (string)dataGridViewConsultas.Rows[dataGridViewConsultas.SelectedCells[0].RowIndex].Cells[1].Value;
            AtualConsulta.Data = (DateTime)dataGridViewConsultas.Rows[dataGridViewConsultas.SelectedCells[0].RowIndex].Cells[2].Value;
            AtualConsulta.Horario = (string)dataGridViewConsultas.Rows[dataGridViewConsultas.SelectedCells[0].RowIndex].Cells[3].Value;
            //Joga em todas as váriáveis acima, as respectivas informações presentes no DGV, na linha selecionada.

            EditarConsulta FormEditarConsulta = new EditarConsulta(AtualConsulta); //Cria uma instância para acessar o form "Editar Consulta", passando "AtualConsulta" como parâmetro.
            FormEditarConsulta.ShowDialog(); //Exibe o form "Editar Consulta".
            AtualizarDadaGridConsulta(); //Atualiza o DGV Consulta.
        }

        //Ao clicar no botão "Desmarcar Consulta".
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja desmarcar a consulta?", "Desmarcar consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //Exibe um MessageBox com opção "Sim" ou "Não".

            if (confirm.ToString().ToUpper() == "YES") //Se clicar em "Sim".
            {
                if (Geral<Consulta>.Deletar("Consulta", dataGridViewConsultas.CurrentRow.Cells[0].Value.ToString()))
                //Chama a função Deletar, passando como parâmetro o nome do arquivo e o código da consulta, presente na primeira célula da linha atual no DGV.
                {
                    //A função deletar retorna um bool, se for "true"...
                    MessageBox.Show("Consulta desmarcada com sucesso!", "Desmarcar Consulta", //Exibe a MessageBox confirmando a exclusão.
                        MessageBoxButtons.OK, MessageBoxIcon.None);

                    //E gera um relatório.
                    Relatorio MeuRelatorio = new Relatorio(); //Cria uma instância para acessar a classe "Relatório".
                    MeuRelatorio.Evento = "Consulta Desmarcada"; //Escreve na variável "Evento".
                    MeuRelatorio.Informações = $"Consulta de código {dataGridViewConsultas.CurrentRow.Cells[0].Value.ToString()} e paciente {dataGridViewConsultas.CurrentRow.Cells[1].Value.ToString()}, desmarcada.";
                    //Escreve na variável "Informações".
                    MeuRelatorio.Data = DateTime.Now;
                    MeuRelatorio.Data = new DateTime(MeuRelatorio.Data.Year, MeuRelatorio.Data.Month, MeuRelatorio.Data.Day,
                                                 MeuRelatorio.Data.Hour, MeuRelatorio.Data.Minute, MeuRelatorio.Data.Second);
                    //Escreve na variável "Data" o ano, mes, dia, hora, minuto e segundo de quando ocorreu a ação.

                    //Adiciona elememto no arquivo relatorio
                    Geral<Relatorio>.AdicionarElemento("Relatorio", MeuRelatorio);
                    AtualizarDadaGridConsulta();
                }
                else
                    //Se for "false", apenas atualiza o DGV Consulta.
                    AtualizarDadaGridConsulta();
            }
        }

        //Ao clicar no botão de pesquisar pacientes com ícone de lupa.
        private void button5_Click(object sender, EventArgs e)
        {
            if (texPesquisar.Text == "" || texPesquisar.Text == " ")
            //Se o usuário não digitar nada ou apenas um espaço no TextBox Pequisar.
            {
                AtualizarDadaGridPacientes();
                //Chama a função atualizar DGV Pacientes, para exibir todos os pacientes salvos.
            }
            else
            //Se não...
            {
                bindingSourcePaciente.DataSource = Geral<Paciente>.Pesquisar("Paciente", texPesquisar.Text);
                //Chama a função Pesquisar, pasando como parâmetro o nome do arquivo e oque o usuário digitou no TextBox Pesquisar.
                //A função retorna uma list, que será usada pelo DataSource para exibir o resultado no DGV Pacientes.
            }

        }

        //Ao clicar no botão de pesquisar consulta com ícone de lupa.
        private void BTNpesqCon_Click(object sender, EventArgs e)
        {

            if (texpesqCon.Text == "" || texpesqCon.Text == " ")
            //Se o usuário não digitar nada ou apenas um espaço no TextBox "PeqCon".
            {
                AtualizarDadaGridConsulta();
                //Chama a função atualizar DGV Pacientes, para exibir todas as consultas salvas.
            }
            else
            //Se não...
            {
                bindingSourceConsultas.DataSource = Geral<Consulta>.Pesquisar("Consulta", texpesqCon.Text);
                //Chama a função Pesquisar, pasando como parâmetro o nome do arquivo e oque o usuário digitou no TextBox "PesqCon".
                //A função retorna uma list, que será usada pelo DataSource para exibir o resultado no DGV Consulta.
            }
        }

        //Ao selecionar algum item do ComboBox filtrar em "Relatórios".
        private void CBXfiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBXfiltrar.Text == "Todos")
            //Se selecionar "Todos"...
            {
                AtualizarDadaGridRelatorio();
                //Chama a função atualizar DGV Relatorio, para exibir tudo.
            }
            else
            //Se selecionar qualquer outro item...
            {
                bindingSourceRelatorio.DataSource = Geral<Relatorio>.Pesquisar("Relatorio", CBXfiltrar.Text);
                //Chama a função Pesquisar, pasando como parâmetro o nome do arquivo e oque o usuário selecionou no "CBXfiltrar".
                //A função retorna uma list, que será usada pelo DataSource para exibir o resultado no DGV Relatorio.
            }

        }

        //Ao pressionar uma tecla específica dentro do TextBox "texPesquisar".
        private void texPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            //Se pressionar o "Enter".
            {
                //Basicamente ocorre o mesmo que clicar no botão de pesquisar pacientes.
                if (texPesquisar.Text == "" || texPesquisar.Text == " ")
                {
                    AtualizarDadaGridPacientes();
                }
                else
                {
                    bindingSourcePaciente.DataSource = Geral<Paciente>.Pesquisar("Paciente", texPesquisar.Text);
                }
            }
        }

        //Ao pressionar uma tecla específica dentro do TextBox "texpesqCon".
        private void texpesqCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            //Se pressionar o "Enter".
            {
                //Basicamente ocorre o mesmo que clicar no botão de pesquisar consulta.
                if (texpesqCon.Text == "" || texpesqCon.Text == " ")
                {
                    AtualizarDadaGridConsulta();
                }
                else
                {
                    bindingSourceConsultas.DataSource = Geral<Consulta>.Pesquisar("Consulta", texpesqCon.Text);
                }
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
