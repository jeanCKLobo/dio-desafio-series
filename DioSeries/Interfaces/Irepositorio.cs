using System.Collections.Generic;

namespace DioSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> lista();
        T retornaPorId(int id);
        
        void insere(T objeto);
        void excluir(int id);
        void atualizar(int id, T objeto);
        int proximoId();
    }
}