using System.Collections.Generic;
using DioSeries.Interfaces;

namespace DioSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {

        private List<Serie> listaSerie = new List<Serie>();

        public void atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> lista()
        {
            return listaSerie;
        }

        public int proximoId()
        {
            return listaSerie.Count;
        }

        public Serie retornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}