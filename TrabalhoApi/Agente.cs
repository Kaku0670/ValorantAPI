using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoApi
{
    internal class Agente
    {
        public string nome;
        public string descrição;
        public string nomeDev;
        public string função;
        public string sexo;
        public string imgRosto;
        public string imgFunc;

        public Agente(string nome, string descrição, string nomeDev, string função, string sexo, string imgRosto, string imgFunc)
        {
            this.nome = nome;
            this.descrição = descrição;
            this.nomeDev = nomeDev;
            this.função = função; 
            this.sexo = sexo;
            this.imgRosto = imgRosto;
            this.imgFunc = imgFunc;
            
        }

    }
}
