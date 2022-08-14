using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CacheamentoDeDados.Service.Cache
{
    public class CacheamentoService
    {
        public async void ArmazenarDado(string chave, string valor)
        {
            try
            {
                await SecureStorage.SetAsync(chave, valor);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task<string> ObterDado(string chave)
        {
            try
            {
                return await SecureStorage.GetAsync(chave);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public void LimparDado(string chave) => SecureStorage.Remove(chave);

        public void LimparTodosDados() => SecureStorage.RemoveAll();
    }
}