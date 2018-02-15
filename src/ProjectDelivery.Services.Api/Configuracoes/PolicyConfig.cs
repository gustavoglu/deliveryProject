using Microsoft.AspNetCore.Authorization;

namespace ProjectDelivery.Services.Api.Configuracoes
{
    public class PolicyConfig
    {
        public static void Configurar(AuthorizationOptions options)
        {
            ConfigurarEntityBasicAuthorization(options, "Adicionais");
            ConfigurarEntityBasicAuthorization(options, "IngredienteOpcOpcoes");
            ConfigurarEntityBasicAuthorization(options, "IngredienteOpcs");
            ConfigurarEntityBasicAuthorization(options, "PagamentoTipos");
            ConfigurarEntityBasicAuthorization(options, "Pedidos");
            ConfigurarEntityBasicAuthorization(options, "Periodos");
            ConfigurarEntityBasicAuthorization(options, "Produto_ValorExcecoes");
            ConfigurarEntityBasicAuthorization(options, "Produtos");
            ConfigurarEntityBasicAuthorization(options, "ProdutoTipos");
            ConfigurarEntityBasicAuthorization(options, "Tamanhos");
        }

        private static void ConfigurarEntityBasicAuthorization(AuthorizationOptions options,string entityNome)
        {
            options.AddPolicy(entityNome, opt => opt.RequireClaim(entityNome, "Criar"));
            options.AddPolicy(entityNome, opt => opt.RequireClaim(entityNome, "Atualizar"));
            options.AddPolicy(entityNome, opt => opt.RequireClaim(entityNome, "Deletar"));
            options.AddPolicy(entityNome, opt => opt.RequireClaim(entityNome, "Listar"));
        }
    }
}
