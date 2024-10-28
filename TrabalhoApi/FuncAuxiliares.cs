using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoApi
{

    internal class Aux
    {
        static int painelPos = 0;
        static int contPainel = 0;

        public static List<Agente> ListaAgentes = new List<Agente>();
        public static List<string> AgentesRepetidos = new List<string>();
        public static List<Panel> MiniPaineis = new List<Panel>();
        public static Panel CriaPainel(int largura, int altura, Agente Agente, int randomV)
        {
            // Criar o painel dinamicamente
            Panel painel = new Panel();
            // Definir as propriedades do painel
            painel.Size = new System.Drawing.Size(210, 54); // Largura, Altura
            painel.Location = new System.Drawing.Point(0, 0); // Posição no formulário
            painel.BackColor = System.Drawing.Color.Gray; // Cor de fundo


            //cria pictures boxes
            PictureBox imgAcerto = new PictureBox();
            imgAcerto.Image = EstaCerto(Agente.nome, randomV);
            imgAcerto.Size = new Size(50, 50);
            imgAcerto.Location = new Point(2, 2);
            imgAcerto.SizeMode = PictureBoxSizeMode.StretchImage;
            imgAcerto.BorderStyle = BorderStyle.FixedSingle;

            PictureBox imgAgente = new PictureBox();
            imgAgente.Load(Agente.imgRosto);
            imgAgente.Size = new Size(50, 50);
            imgAgente.SizeMode = PictureBoxSizeMode.StretchImage;
            imgAgente.Location = new Point(54, 2);
            imgAgente.BorderStyle = BorderStyle.FixedSingle;
            imgAgente.BackColor = System.Drawing.Color.WhiteSmoke;

            PictureBox imgFunc = new PictureBox();
            imgFunc.Image = AnalisaFunc(Agente, randomV);
            imgFunc.Size = new Size(50, 50);
            imgFunc.SizeMode = PictureBoxSizeMode.StretchImage;
            imgFunc.Location = new Point(106, 2);
            imgFunc.BorderStyle = BorderStyle.FixedSingle;

            PictureBox imgSexo = new PictureBox();
            imgSexo.Image = AnalisaSexo(Agente, randomV);
            imgSexo.Size = new Size(50, 50);
            imgSexo.SizeMode = PictureBoxSizeMode.StretchImage;
            imgSexo.Location = new Point(158, 2);
            imgSexo.BorderStyle = BorderStyle.FixedSingle;
            // Adicionar uma picturebox ao painel 
            painel.Controls.Add(imgAcerto);
            painel.Controls.Add(imgAgente);
            painel.Controls.Add(imgFunc);
            painel.Controls.Add(imgSexo);
            MiniPaineis.Add(painel);


            if (contPainel >= 1) { painel.Location = new Point(painel.Location.X, painelPos + 56); painelPos += 56; }

            contPainel++;
            return painel;
        }

        public static Agente ProcuraAgente(string nome)
        {
            for (int i = 0; i < ListaAgentes.Count; i++)
            {
                if (ListaAgentes[i].nome.ToLower() == nome.ToLower())
                {

                    return ListaAgentes[i];

                }

            }

            return null;
        }


        public async static Task ResgataAgentes()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // URL da API para os agentes jogáveis
                    string url = "https://valorant-api.com/v1/agents?isPlayableCharacter=true";

                    // Fazendo a requisição GET
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Lendo o conteúdo da resposta
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Processando o JSON de resposta
                    JObject json = JObject.Parse(responseBody);
                    var agents = json["data"];

                    // Exibindo o nome dos agentes em um TextBox
                    foreach (var agent in agents)
                    {

                        Agente agente = new Agente(Convert.ToString(agent["displayName"]), Convert.ToString(agent["description"]), Convert.ToString(agent["developerName"]), Convert.ToString(agent["role"]["displayName"]), "maxo", Convert.ToString(agent["displayIcon"]), Convert.ToString(agent["role"]["displayIcon"]));
                        if (Convert.ToString(agent["displayName"]) == "Skye" || Convert.ToString(agent["displayName"]) == "Jett" || Convert.ToString(agent["displayName"]) == "Sage" || Convert.ToString(agent["displayName"]) == "Viper" || Convert.ToString(agent["displayName"]) == "Fade" || Convert.ToString(agent["displayName"]) == "Deadlock" || Convert.ToString(agent["displayName"]) == "Raze" || Convert.ToString(agent["displayName"]) == "Killjoy" || Convert.ToString(agent["displayName"]) == "Vyse" || Convert.ToString(agent["displayName"]) == "Astra" || Convert.ToString(agent["displayName"]) == "Neon" || Convert.ToString(agent["displayName"]) == "Reyna")
                        {
                            agente.sexo = "feminino";
                        }
                        else if (Convert.ToString(agent["displayName"]).ToLower() == "clove")
                        {
                            agente.sexo = "não binário"; //Dado oficial do valorant dle: https://valdle.gg/guessAgent
                        }
                        else
                        {
                            agente.sexo = "masculino";
                        }


                        ListaAgentes.Add(agente);
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Erro: {e.Message}");
                }
            }
        }



        public static Image AnalisaFunc(Agente agente, int randomV)
        {
            if (ListaAgentes[randomV].função.ToLower() != agente.função.ToLower())
            {
                if (agente.função.ToLower() == "duelist")
                {

                    return Properties.Resources.DuelistaVermelho1;
                }
                else if (agente.função.ToLower() == "initiator")
                {
                    return Properties.Resources.IniciadorVermelho;
                }
                else if (agente.função.ToLower() == "controller")
                {

                    return Properties.Resources.contoladorVermelho1;
                }
                else if (agente.função.ToLower() == "sentinel")
                {

                    return Properties.Resources.SentinelaVermelho;
                }
            }
            else if (ListaAgentes[randomV].função.ToLower() == agente.função.ToLower())
            {
                if (agente.função.ToLower() == "duelist")
                {

                    return Properties.Resources.DuelistaVerde1;
                }
                else if (agente.função.ToLower() == "initiator")
                {

                    return Properties.Resources.IniciadorVerde;
                }
                else if (agente.função.ToLower() == "controller")
                {

                    return Properties.Resources.ControladorVerde1;
                }
                else if (agente.função.ToLower() == "sentinel")
                {

                    return Properties.Resources.SentinelaVerde;
                }
            }
            return null;
        }

        public static Image AnalisaSexo(Agente agente, int randomV)
        {
            if (ListaAgentes[randomV].sexo.ToLower() != agente.sexo.ToLower())
            {
                if (agente.sexo.ToLower() == "feminino")
                {
                    return Properties.Resources.FemininoVermelho;
                }
                else if (agente.sexo.ToLower() == "masculino")
                {
                    return Properties.Resources.MasculinoVermelho;
                }
                else if (agente.sexo.ToLower() == "não binário")
                {
                    return Properties.Resources.NãoBinárioVermelho;
                }

            }
            if (ListaAgentes[randomV].sexo.ToLower() == agente.sexo.ToLower())
            {
                if (agente.sexo.ToLower() == "feminino")
                {
                    return Properties.Resources.FemininoVerde;
                }
                else if (agente.sexo.ToLower() == "masculino")
                {
                    return Properties.Resources.MasculinoVerde;
                }
                else if (agente.sexo.ToLower() == "não binário")
                {
                    return Properties.Resources.NãoBinárioVerde;
                }

            }
            return null;
        }

        public static Image EstaCerto(string nome, int randomV)
        {
            if (nome.ToLower() == ListaAgentes[randomV].nome.ToLower())
            {
                return Properties.Resources.Certo;
            }
            else if ((nome.ToLower() != ListaAgentes[randomV].nome.ToLower()))
            {
                return Properties.Resources.Errado;
            }
            return null;
        }

        public static List<string> Busca(string nomeBusca)
        {
            
            List<string> nomesPossiveis = new List<string>();
            nomesPossiveis.Clear();
            List<char> letrasNomeBusca = new List<char>();
            string letrasNomePos = "";
            string nomeAgente = "";
            for (int i = 0; i < nomeBusca.Length; i++)
            {
                letrasNomeBusca.Add(nomeBusca.ToLower()[i]);
            }
            for (int i = 0; i < ListaAgentes.Count; i++)
            {
                if (letrasNomeBusca.Count <= ListaAgentes[i].nome.Length)
                {
                    for (int j = 0; j < letrasNomeBusca.Count; j++)
                    {
                        if (letrasNomeBusca[j] == ListaAgentes[i].nome.ToLower()[j])
                        {
                            letrasNomePos += letrasNomeBusca[j];
                        }

                    }
                    for (int j = 0; j < letrasNomePos.Length; j++)
                    {

                        nomeAgente += ListaAgentes[i].nome.ToLower()[j];
                        if (nomeAgente == letrasNomePos)
                        {
                            nomesPossiveis.Add(ListaAgentes[i].nome);
                        }
                    }
                }
                letrasNomePos = "";
                nomeAgente = "";
                
            }
            return nomesPossiveis;
            
        }
        public static bool persona = false;
        public static string nomeClicado = "";
        public static Panel CriaPanel2(int largura, int altura,int x, int y, Agente Agente, int randomV,Label label)
        {
            
                // Criar o painel dinamicamente
                Panel painel = new Panel();
                // Definir as propriedades do painel
                painel.Size = new System.Drawing.Size(210, 54); // Largura, Altura
                painel.Location = new System.Drawing.Point(x, y); // Posição no formulário
                painel.BackColor = System.Drawing.Color.Gray; // Cor de fundo
                

            PictureBox imgAgente = new PictureBox();
                imgAgente.Load(Agente.imgRosto);
                imgAgente.Size = new Size(50, 50);
                imgAgente.SizeMode = PictureBoxSizeMode.StretchImage;
                imgAgente.Location = new Point(54, 2);
                imgAgente.BorderStyle = BorderStyle.FixedSingle;
                imgAgente.BackColor = System.Drawing.Color.WhiteSmoke;
                painel.Controls.Add(imgAgente);

                Label nomeAgente = new Label();
                nomeAgente.Text = Agente.nome;
                nomeAgente.Font = label.Font;
                persona = true;
                nomeClicado = Agente.nome;
                
                return painel;
            
        }

        

        
    }
   
}
