namespace Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities
{
    public partial class AvisoEntity
    {
        public int Id { get; private set; }
        public bool Ativo { get; set; } = true;
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? EditadoEm { get; set; }
        public bool Deletado { get; set; }

        public void SetMensagem(string mensagem)
        {
            Mensagem = mensagem;
            EditadoEm = DateTime.Now;
        }

        public void SetAtivo(bool ativo)
        {
            Ativo = ativo;
            EditadoEm = DateTime.Now;
        }
    }
}