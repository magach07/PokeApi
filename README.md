*DOCUMENTAÇÃO DAS APIS*

(GET) /PokeApi/Get10PokesRandom/ - Método GET para 10 Pokémon aleatórios.
(GET) /PokeApi/GetPokemon/ - Método GET para 1 Pokémon específico.
(GET) /PokeApi/GetPokesCapturados/ - Método GET para listar Pokémons capturados.
(POST) /PokeApi/PostMestrePokemon/ - Método POST para cadastro de Mestre Pokémon.
    - Modelo JSON Body: {
                            "name":"Ash Ketchum",
                            "idade":10,
                            "cpf":"326.458.569-30"
                        }
(POST) /PokeApi/PostPokemonCapturado/ - Método POST para cadasrtar Pokémon Capturado.
        - Modelo JSON Body: {
                                "name":"Pikachu",
                                "id_Treinador": 1
                            }

* O BANCO FOI CRIADO EM SQLite E UTILIZEI OS SEGUINTES COMANDOS

CREATE TABLE TB_MESTRE_POKEMON
(
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    CL_NAME TEXT(30),
    CL_IDADE INT,
    CL_CPF TEXT(30)
)

CREATE TABLE TB_POKEMON_CAPTURADO
(
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    CL_NAME TEXT(30),
    CL_DATA_CAPTURA TEXT(30),
    CL_ID_TREINADOR INTEGER
)

* O padrão de arquitetura utilizado foi o CQRS, que utiliza microsserviços para maximizar o desempenho, a escabilidade e a segurança da aplicação.