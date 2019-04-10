using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Trabalho_POO.Classes
{
    class Geral<T>
    {

        //Função para gerar o codigo de qualquer item.
        public static string GerarCodigo(string nomeArquivo, string sigla)
        {
            //obtem a leitura do arquivo
            //cada posição do vetor corresponde a uma linha do arquivo
            string[] lerCodigo = null;
            FileStream arq1 = new FileStream($"Codigos/{nomeArquivo}.txt", FileMode.OpenOrCreate);

            // declara instancia do StreamWriter 
            StreamReader ler = new StreamReader(arq1);

            //Variavel que recebe todo conteudo do arquivo
            string tudo = null;

            tudo = ler.ReadToEnd();

            if (tudo != null)
            {
                //'string[] resultado' recebe os valores pelo 'Split' de "/r"(tabulação)
                lerCodigo = tudo.Split('\r');

                //Cada vetor ainda fica com um "\n"(saltar linha) no inicio, aki é removido esse "\n"
                for (int i = 1; i < lerCodigo.Length; i++)
                {
                    lerCodigo[i] = lerCodigo[i].Remove(0, 1);
                }
            }
            //fecha a instancia do FileStream e  retorna a string[] com os valores
            arq1.Close();

            //Sigla é o inicio do codio:
            string codigo = sigla;

            //Declara codigo = 1
            // se a leitura do arquivo que contem o codigo for vazia, atribiu "1"
            int contCodigo = 1;

            //Verifica se a leitura é null ou vazia e screve codigo com valor "1" e 
            // cria o arquivo '.txt' escrito "2" dentro dele
            //obs o nome do arquivo será de acordo com o parametro 'string nomeArquivo' 
            //esse parametro é pasado na chamada da função

            if (lerCodigo == null || lerCodigo[0] == "")
            {
                codigo += ("000" + contCodigo);
                contCodigo++;

                StreamWriter escreve = null;
                //declara instancia do FileStream, obtem o path no parametro da chamada da função
                arq1 = new FileStream($"Codigos/{nomeArquivo}.txt", FileMode.OpenOrCreate);

                //faz uma leitura do arquivo para ir ao fina do arquivo e assim nhão sobreescrever nenhum dado
                ler = new StreamReader(arq1);
                ler.ReadToEnd();

                // declara instancia do StreamWriter 
                escreve = new StreamWriter(arq1);

                //obtem o texto no parametro da chamada da função
                escreve.WriteLine(Convert.ToString(contCodigo));
                escreve.Close();
            }

            //Se leitura estiver con erro retora a mensagem do erro n vetor de indice '0'
            //um posivel erro seria não ter o camiho do arquivo para cria-lo
            else if (lerCodigo[0].Contains("ERRO:"))
                return lerCodigo[0];

            //Gera o codigo do Item
            //Codigo será o texto escrito no arquivo
            //So chega ate aki se a leitura não for vazia
            //e se leitura não conter erro
            else
            {
                contCodigo = int.Parse(lerCodigo[0]);


                // verifica quantos caracteres tem o numero para acresentar 'zeros' a esquerda
                if (lerCodigo[0].Length == 1)
                    codigo += ("000" + contCodigo);
                else if (lerCodigo[0].Length == 2)
                    codigo += ("00" + contCodigo);
                else if (lerCodigo[0].Length == 3)
                    codigo += ("0" + contCodigo);
                else
                    codigo += contCodigo;      //se o numero ja tiver mais de 4 algarismos
                                               //não ha necessidade de colocar 'zeros' a esquerda 
                contCodigo++;


                //Função StreamWriter(string path, bool append), caso o parametro 'append' seja declarado 'false'
                // a função sobrescreve o texto do arquivo
                // caso o parametro 'append' seja declarado 'true'
                //a função adiciona texto ao arquivo
                StreamWriter escreve = new StreamWriter($"Codigos/{nomeArquivo}.txt", false);
                escreve.Write(Convert.ToString(contCodigo));
                escreve.Close();
            }
            return codigo;
        }

        //Função para adicionar um elemento a um arquivo XML.
        public static bool SerilizarElemento(string NomeArquivo, T Conteudo)
        {
            string path = $"BancoDados/{NomeArquivo}.xml";
            //joga na variável o caminho do arquivo.

            if (File.Exists(path) == false)
            {
                FileStream Arquivo1 = new FileStream(path, FileMode.Create);
                Arquivo1.Close();
            }


            //TextWriter MeuWriter = new StreamWriter(path);
            List<T> ListaT = new List<T>();
            TextWriter MeuWriter;

            try
            {
                ListaT.Clear();

                // declara a Serialização
                XmlSerializer Serialização = new XmlSerializer(ListaT.GetType());

                //Desserialização
                ListaT = DesserializarXML(NomeArquivo, ListaT);

                //Todo o conteudo do xml é adicionado a lista generica
                ListaT.Add(Conteudo);

                // TextWriter - Para escrever no XML
                MeuWriter = new StreamWriter(path);

                //Serializa usando o TextWriter
                Serialização.Serialize(MeuWriter, ListaT);
                MeuWriter.Close();

            }
            catch (Exception e)
            {
                //se der algum erro durante o processo é retornado falso
                return false;
            }

            //Se não der nenhum erro durante o processo é retornado verdadeiro
            return true;
        }

        //Função que adiciona Elemento em algum arquivo xml
        public static bool AdicionarElemento(string NomeArquivo, T Conteudo)
        {
            XElement xml;
            string path = $"BancoDados/{NomeArquivo}.xml";
            try
            {
                //Ocorre se o arquivo nao exixtir
                if (File.Exists(path) == false)
                {
                    FileStream Arquivo1 = new FileStream(path, FileMode.Create);
                    Arquivo1.Close();
                    if (SerilizarElemento(NomeArquivo, Conteudo))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                
                    xml = XElement.Load(path);

                // Conteudo.GetType().Name Obtem o nome da classe
                XElement y = new XElement(Conteudo.GetType().Name);

                for (int i = 0; i < Conteudo.GetType().GetProperties().Length; i++)
                {
                    y.Add(new XElement(Conteudo.GetType().GetProperties()[i].Name, Conteudo.GetType().GetProperties()[i].GetValue(Conteudo)));
                }

                if (y != null && xml != null)
                {
                    xml.AddFirst(y);
                }

                //salva o conteudo
                if (xml != null)
                {
                    xml.Save(path);
                }
                else
                    y.Save(path);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        //Função para desserializar um arquivo XML e retornar uma lista genérica.
        public static List<T> DesserializarXML(string NomeArquivo, List<T> ListaOriginal)
        {
            string path = $"BancoDados/{NomeArquivo}.xml";

            //Verifica se o arquivo existe
            if (File.Exists(path) == false)
            {
                return null;
            }

            List<T> ListaT = new List<T>();
            // declara a Serialização
            XmlSerializer Serialização = new XmlSerializer(ListaT.GetType());

            FileStream Arquivo = new FileStream(path, FileMode.Open);      // Abre Arquivo para Leitura

            //Variavel que recebe todo conteudo do arquivo
            int tudo = 0;

            tudo = Arquivo.ReadByte();
            Arquivo.Close();

            //Se o xml estiver vazio ele não pode ser desserializado porque da erro
            if (tudo != -1)
            {

                FileStream aqv = new FileStream(path, FileMode.Open);
                ListaT = (List<T>)Serialização.Deserialize(aqv);
                aqv.Close();
            }
            else
                return ListaOriginal;

            return ListaT;
        }

        //Função para deletar um elemento de algum XML.
        public static bool Deletar(string Arquivo, string ID)
        {
            XElement xml;
            try
            {
                //lendo arquivo xml
                xml = XElement.Load($"BancoDados/{Arquivo}.xml");
                XElement x = xml.Elements().Where(p => p.Element("Codigo").Value.Equals(ID)).First();

                if (x != null)
                {
                    x.Remove();
                }
                //Salva o arquivo atualizado
                xml.Save($"BancoDados/{Arquivo}.xml");
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        //Função para editar um elemento de algum XML.
        public static bool Editar(string Arquivo, T Conteudo, T Original)
        {
            XElement xml;
            try
            {
                //lê o arquivo xml
                xml = XElement.Load($"BancoDados/{Arquivo}.xml");
                // Obtém o valor da célula selecionada no datagrid
                XElement x = xml.Elements().Where(p => p.Element("Codigo").Value.Equals(Conteudo.GetType().GetProperties()[0].GetValue(Conteudo))).First();

                XElement y = new XElement(x.Name);

                for (int i = 0; i < Conteudo.GetType().GetProperties().Length; i++)
                {
                    y.Add(new XElement(Conteudo.GetType().GetProperties()[i].Name, Conteudo.GetType().GetProperties()[i].GetValue(Conteudo)));
                }

                //Verifica se os dois arquivos foram criados
                if (x != null && y != null)
                {
                    //para fazer a substutuição de um pelo outro
                    //foi preciso primeiro remover um e adicionar o outro
                    //porque o x.replace(y) não esta funcionando como esperado
                    x.Remove();
                    xml.AddFirst(y);
                }


                Relatorio MeuRelatorio = new Relatorio(); //Cria uma intânciada classe Relatorio

                // Conteudo.GetType().Name = Obtem o nome da classe
                string EventoRelatorio = $"{Conteudo.GetType().Name} Editado(a)";
                string InfoRelatorio = $"Dados editados do código {Original.GetType().GetProperties()[0].GetValue(Original).ToString()}: ";
                int e = 0;
                //Conteudo.GetType().GetProperties().Length = Obtem a quantidade de propriedades publicas da classe
                for (int i = 0; i < Conteudo.GetType().GetProperties().Length; i++)
                {
                    //Conteúdo que foi modificado
                    string A = Conteudo.GetType().GetProperties()[i].GetValue(Conteudo).ToString();
                    //Conteúdo Original
                    string B = Original.GetType().GetProperties()[i].GetValue(Original).ToString();

                    if (Conteudo.GetType().GetProperties()[i].GetValue(Conteudo).GetType().ToString() == MeuRelatorio.Data.GetType().ToString())
                    {
                        string data1 = string.Format("{0:dd/MM/yyyy}", Conteudo.GetType().GetProperties()[i].GetValue(Conteudo));
                        string data2 = string.Format("{0:dd/MM/yyyy}", Original.GetType().GetProperties()[i].GetValue(Original));
                        if (data1 != data2)
                        {
                            InfoRelatorio += $" campo {Conteudo.GetType().GetProperties()[i].Name} de {data2} para {data1},";
                        }
                        else
                            e++;
                    }
                    else if ( A != B)
                    {
                        InfoRelatorio += $" campo {Conteudo.GetType().GetProperties()[i].Name} de {Original.GetType().GetProperties()[i].GetValue(Original)} para {Conteudo.GetType().GetProperties()[i].GetValue(Conteudo)},";
                    }
                    else
                        e++;
                }

                if (Conteudo.GetType().GetProperties().Length - e != 0)
                {
                    //Cria relatorio

                    MeuRelatorio.Evento = EventoRelatorio;
                    MeuRelatorio.Informações = InfoRelatorio;
                    MeuRelatorio.Data = DateTime.Now;
                    MeuRelatorio.Data = new DateTime(MeuRelatorio.Data.Year, MeuRelatorio.Data.Month, MeuRelatorio.Data.Day,
                                                 MeuRelatorio.Data.Hour, MeuRelatorio.Data.Minute, MeuRelatorio.Data.Second);

                    //Adiciona elememto no arquivo relatorio
                    if (Geral<Relatorio>.AdicionarElemento("Relatorio", MeuRelatorio) == false)
                    {
                        return false;
                    }
                }
              

                //salva o conteudo
                xml.Save($"BancoDados/{Arquivo}.xml");
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        //Função para pesquisar em um XML e retornar uma lista generica.
        public static List<T> Pesquisar(string Arquivo, string pesquisar)
        {
            string path = $"BancoDados/{Arquivo}.xml";

            List<T> pesquisa = new List<T>();
            List<T> desserializar = new List<T>();
            //Contém o arquivo em forma de lista
            desserializar = DesserializarXML(Arquivo, desserializar);

            int z = 0;
            //percorre a lista
            foreach (var i in desserializar)
            {

                foreach (var e in i.GetType().GetProperties())
                {
                    //Compara cada linha da lista com o que foi digitado, contido no "pesquisar"
                    //passado por parâmetro
                    var t = e.GetValue(desserializar[z]).ToString().ToUpper();
                    if (t.Contains(pesquisar.ToUpper()))
                    {
                        if (pesquisa.Contains(desserializar[z]) == false)
                        {
                            pesquisa.Add(desserializar[z]);
                        }
                    }
                }
                z++;
            }

            return pesquisa;
        }
    }


}
