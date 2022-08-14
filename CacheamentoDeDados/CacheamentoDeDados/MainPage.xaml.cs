using CacheamentoDeDados.Models;
using CacheamentoDeDados.Service.Cache;
using System;
using System.Text.Json;
using Xamarin.Forms;

namespace CacheamentoDeDados
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();

        private async void CadastrarUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EtrNome.Text) || string.IsNullOrEmpty(EtrEmail.Text) ||
                string.IsNullOrEmpty(EtrSenha.Text) || string.IsNullOrEmpty(EtrSenhaConfirmacao.Text))
            {
                await DisplayAlert("Atenção",
                    "Todos os campos devem ser preenchido", "Fechar");
            }

            var cacheamentoService = new CacheamentoService();

            var usuario = new Usuario
            {
                Email = EtrEmail.Text,
                Nome = EtrNome.Text,
                Senha = EtrSenha.Text,
                SenhaConfirmacao = EtrSenhaConfirmacao.Text
            };

            var usuarioJson = JsonSerializer.Serialize(usuario);
            cacheamentoService.ArmazenarDado("usuario-cadastrado", usuarioJson);

            await DisplayAlert("Sucesso",
                "Usuario Cadastrado Com Sucesso", "Fechar");
        }
    }
}