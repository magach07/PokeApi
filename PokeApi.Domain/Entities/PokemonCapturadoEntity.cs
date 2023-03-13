namespace PokeApi.Domain.Entities
{
    public class PokemonCapturadoEntity
    {
        public string? Name { get; set; }
        public string Data_Captura => DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        public int Id_Treinador { get; set; }

        public PokemonCapturadoEntity(string name, int id_Treinador)
        {
            Name = name;
            Id_Treinador = id_Treinador;
        }
    }
}