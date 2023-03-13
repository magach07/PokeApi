namespace PokeApi.Domain.Entities
{
    public class MestrePokemonEntity
    {
        public MestrePokemonEntity (string name, int idade, string cpf)
        {
            Name = name;
            Idade = idade;
            Cpf = cpf;
        }

        public string Name { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
    }
}