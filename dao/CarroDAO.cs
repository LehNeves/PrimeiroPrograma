using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficial.models;
using Oficial.contexto;

namespace Oficial.dao
{
    public class CarroDAO
    {

        Contexto contexto = new Contexto();
        public List<Carro> GetCarrosFromPessoa(int index)
        {

            return contexto.Carro.SqlQuery("Select carroes.* from pessoas, carroes where carroes.Pessoa_id = pessoas.id and pessoas.id = " + index).ToList(); ;

        }

    }
}
