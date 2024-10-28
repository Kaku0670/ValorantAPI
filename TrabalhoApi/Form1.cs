using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TrabalhoApi.Properties;
using System.Media;
using Microsoft.VisualBasic.Devices;
namespace TrabalhoApi
{
    public partial class Form1 : Form
    {
        private SoundPlayer player;// fazendo um som de fundo
        private SoundPlayer acerto;//quando um usuário acerta

        public Form1()
        {
            this.MouseMove += Form1_MouseMove;
            InitializeComponent();
            player = new SoundPlayer("D:\\Users\\Kmatt\\Downloads\\TrabalhoApi\\TrabalhoApi\\sons\\VavaMusic.wav");//lembre de mudar o caminho para o arquivo
            player.PlayLooping(); //toca o som em loop
            acerto = new SoundPlayer("D:\\Users\\Kmatt\\Downloads\\TrabalhoApi\\TrabalhoApi\\sons\\VitoriaMusic.wav");// lembre de mudar o caminho para o arquivo
            ImagemAcerto.Location = new Point(9999, 9999);
        }
        Random random = new Random();
        int randomV;

        private void Form1_Load(object sender, EventArgs e)
        {
            Aux.ResgataAgentes();
            randomV = random.Next(0, 24);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            /*List<string> list = new List<string>();
            list = Aux.Busca(textBox1.Text);
            for (int i = 0; i < list.Count; i++)
            {
                this.Controls.Add(Aux.CriaPainel(50, 100, Aux.ProcuraAgente(list[i]), randomV));
            }*/

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            //button1.Text = Aux.ListaAgentes[randomV].nome;
            Agente a = Aux.ProcuraAgente(textBox1.Text);
            if (textBox1.Text.ToLower() == Aux.ListaAgentes[randomV].nome.ToLower())
            {
                ImagemAcerto.Location = new Point((this.Width / 2) - (ImagemAcerto.Width / 2), 38);
                textBox1.Location = new Point(textBox1.Location.X, ImagemAcerto.Location.Y + 200);
                button1.Location = new Point(button1.Location.X, textBox1.Location.Y);
                button2.Location = new Point(button2.Location.X,textBox1.Location.Y);
                ImagemAcerto.Load(Aux.ListaAgentes[randomV].imgRosto);
                painelTentativas.Controls.Add((Aux.CriaPainel(202, 52, a, randomV)));
              


                if (Aux.MiniPaineis.Count < 4) { vScrollBar1.Maximum += 05; vScrollBar1.LargeChange = 10; painelTentativas.Size = new Size(painelTentativas.Size.Width, painelTentativas.Size.Height + 55); }
                else { vScrollBar1.Maximum += 56; }

                acerto.Play(); // Toca o som uma vez quando ganha

            }
            else if (textBox1.Text != "" && a != null)
            {

                //button1.Text = Aux.ListaAgentes[randomV].função.ToLower();
                painelTentativas.Controls.Add((Aux.CriaPainel(202, 52, a, randomV)));
                //painelTentativas.Size = new Size(painelTentativas.Size.Width, painelTentativas.Size.Height + 54);

                if (Aux.MiniPaineis.Count < 4)
                {
                    vScrollBar1.Maximum += 05;
                    vScrollBar1.LargeChange = 10;
                    painelTentativas.Size = new Size(painelTentativas.Size.Width, painelTentativas.Size.Height + 55);
                }
                else
                {
                    vScrollBar1.Maximum += 56;
                }




            }
            else
            {
                MessageBox.Show("Agente inválido");
            }
            Aux.persona = true;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            for (int i = 0; i < Aux.MiniPaineis.Count; i++)
            {
                Aux.MiniPaineis[i].Location = new Point(Aux.MiniPaineis[i].Location.X, (56 * i) - vScrollBar1.Value);


            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
            player.Dispose();
            acerto.Dispose();
        }
        bool podeir = false;
        private void Form1_Click(object sender, EventArgs e)
        {
            if (PodeClick == true && Aux.persona == true)
            {
                podeir = true;
            }
        }

        private void Form1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
        bool PodeClick;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > 308 && e.X < textBox1.Size.Width + 308)
            {
                if (e.Y > 205 && e.Y < 255)
                {
                    PodeClick = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (podeir)
            {
                textBox1.Text = Aux.nomeClicado;
                Aux.nomeClicado = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Aux.MiniPaineis.Count >= 4)
            {
                MessageBox.Show($"Dica: O nome de desenvolvimento desse agente é: {Aux.ListaAgentes[randomV].nomeDev}" );
            }
            else{ MessageBox.Show($"A dica só sera disponibilizada após o 3º erro "); }
            
        }
    }
}
