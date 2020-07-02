using System;
using System.Collections.Generic;
using System.Linq;
using TF_PSA.PL;

namespace TF_PSA
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new LeilaoContext())
            {
                #region UserSeeding
                if (db.Usuarios.Count() == 0)
                {
                    SeedUsuarios(db);
                }
                #endregion
                #region ConsultaUsuarios

                LeilaoContext context = new LeilaoContext();

                var usuarios = from c in context.Usuarios
                               select c.Nome;

                Console.WriteLine(" ");
                Console.WriteLine("Usuarios registrados: ");
                foreach (String usuarioNome in usuarios)
                {
                    Console.WriteLine(usuarioNome);
                }
                #endregion
                
                #region ItemSeeding
                if (db.Itens.Count() == 0)
                {
                    SeedItens(db);
                }
                #endregion
                #region ConsultaItens
                var itens = from i in context.Itens
                            select i.Nome;

                Console.WriteLine(" ");
                Console.WriteLine("Itens registrados: ");
                foreach (String item in itens)
                {
                    Console.WriteLine(item);
                }
                #endregion
                
                #region LeiloesSeeding
                if (db.Leiloes.Count() == 0)
                {
                    SeedLeiloes(db);
                }

                #endregion
                #region ConsultaLeiloes
                var leiloes = from l in context.Leiloes
                              select l.IdUsuarioResponsavel;

                Console.WriteLine(" ");
                Console.WriteLine("Leiloes registrados: ");
                foreach (String leilao in leiloes)
                {
                    Console.WriteLine(leilao);
                }

                #endregion
                
                #region LancesSeeding
                if (db.Lances.Count() == 0)
                {
                    SeedLances(db);
                }
                #endregion
                #region ConsultaLances
                var lances = from l in context.Lances
                             select l.EmailUsuario;

                Console.WriteLine(" ");
                Console.WriteLine("Lances registrados: ");
                foreach (String lance in lances)
                {
                    Console.WriteLine(lance);
                }
                #endregion
                
                Console.ReadKey();
            }
        }

        private static void SeedUsuarios(LeilaoContext context)
        {

            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario
                {
                    UsuarioId = "97974378827",
                    Nome = "Thais",
                    Email = "thais.fernandes@edu.pucrs.br",
                    Cpf = "97974378827",
                    Telefone = "(51) 981665664"
                },
                new Usuario
                {
                    UsuarioId = "87834528750",
                    Nome = "Marina",
                    Email = "marina.moreira@edu.pucrs.br",
                    Cpf = "87834528750",
                    Telefone = "(51) 33196974"
                },
                new Usuario
                {
                    UsuarioId = "67456378829",
                    Nome = "Arthur",
                    Email = "arthur.maciel@edu.pucrs.br",
                    Cpf = "67456378829",
                    Telefone = "(51) 985632645"
                },
                new Usuario
                {
                    UsuarioId = "12378589940",
                    Nome = "Felipe",
                    Email = "felipe.fahrion@edu.pucrs.br",
                    Cpf = "12378589940",
                    Telefone = "(51) 33184635"
                },
                new Usuario
                {
                    UsuarioId = "34709567830",
                    Nome = "Bruno",
                    Email = "bruno.abbad@edu.pucrs.br",
                    Cpf = "34709567830",
                    Telefone = "(51) 983562364"
                },
            };

            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();

            Console.WriteLine("Usuarios salvos");
        }

        private static void SeedItens(LeilaoContext context)
        {

            List<Item> itens = new List<Item>
            {
                new Item {
                    ItemId = 1,
                    Nome = "Carrinho de bebê",
                    DescricaoBreve = "Carrinho de passeio para bebê da marca Galzerano",
                    DescricaoCompleta = "Carrinho de passeio para bebê da marca Galzerano",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = "https://static.carrefour.com.br/medias/sys_master/images/images/hdb/heb/h00/h00/12050914312222.jpg"
                },
                new Item {
                    ItemId = 2,
                    Nome = "Banquetas",
                    DescricaoBreve = "Banquetas para uso interno da casa. Idela em lugares com lobbys compartilhados",
                    DescricaoCompleta = "Banquetas para uso interno da casa. Idela em lugares com lobbys compartilhados",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = "https://www.ennecoisasdacasa.com.br/thumbs/produtos/88paula+1thumb_w800.png"
                },
                new Item {
                    ItemId = 3,
                    Nome = "Rélógio",
                    DescricaoBreve = "Relógio da marca Invicta, apenas 2 meses de uso",
                    DescricaoCompleta = "Relógio da marca Invicta, apenas 2 meses de uso",
                    Categoria = CategoriaEnum.Vestuario,
                    Imagem = "https://www.casasbahia-imagens.com.br/Relogios/relogiosMasculinos/relogio-masculino-analogico/14399391/1317594743/relogio-invicta-bolt-modelo-21361-dourado-azul-14399391.jpg"
                },
                new Item {
                    ItemId = 4,
                    Nome = "Mouse",
                    DescricaoBreve = "Mouse wireless de Computador com entrada USB 2.0",
                    DescricaoCompleta = "Mouse wireless de Computador com entrada USB 2.0",
                    Categoria = CategoriaEnum.Eletronico,
                    Imagem = "https://d1ijv31ps3i0yu.cloudfront.net/wp-content/uploads/2018/04/Mouse-Wireless-1.jpg"
                },
                new Item {
                    ItemId = 5,
                    Nome = "Livro Steve Jobs",
                    DescricaoBreve = "A Cabeça de Steve Jobs é um livro de Marcio Edson Tavares, lançado em 2010, que retrata aspectos da vida e personalidade de Steve Jobs. Conforme sinopse da Livraria Cultura, o livro é, ao mesmo tempo, uma biografia e um guia sobre liderança",
                    DescricaoCompleta = "A Cabeça de Steve Jobs é um livro de Marcio Edson Tavares, lançado em 2010, que retrata aspectos da vida e personalidade de Steve Jobs. Conforme sinopse da Livraria Cultura, o livro é, ao mesmo tempo, uma biografia e um guia sobre liderança",
                    Categoria = CategoriaEnum.Lazer,
                    Imagem = "https://www.oficinadanet.com.br/imagens/post/11075/td_capa-livro-a-cabeca-de-steve-jobs.jpg"
                },
                new Item {
                    ItemId = 6,
                    Nome = "Creme de massagem drenante",
                    DescricaoBreve = "Creme de massagem desenvolvido para auxiliar na ativação do sistema linfático, este creme com óleo de pimenta negra, termogênico de origem natural, é indicado para massagens modeladoras",
                    DescricaoCompleta = "Creme de massagem desenvolvido para auxiliar na ativação do sistema linfático, este creme com óleo de pimenta negra, termogênico de origem natural, é indicado para massagens modeladoras",
                    Categoria = CategoriaEnum.Higiene,
                    Imagem = "https://adcos.vteximg.com.br/arquivos/ids/156794-1000-1000/8397_Reduxcel-Slim-Creme-Massagem-Redutor-Plus_1kg_SITE.png?v=636027261392300000"
                },
                new Item {
                    ItemId = 7,
                    Nome = "Halteres 20 kg",
                    DescricaoBreve = "2 (dois) Halteres, bem cuidados da marca Phonex. Com um ano de garantia",
                    DescricaoCompleta = "2 (dois) Halteres, bem cuidados da marca Phonex. Com um ano de garantia",
                    Categoria = CategoriaEnum.Esporte,
                    Imagem = "https://http2.mlstatic.com/kit-de-halteres-20-kg-com-mala-domyos-D_NQ_NP_457601-MLB20372345182_082015-F.jpg"
                }
            };

            context.Itens.AddRange(itens);
            context.SaveChanges();

            Console.WriteLine("Itens salvos");
        }

        private static void SeedLances(LeilaoContext context)
        {
            List<Lance> lances = new List<Lance>
            {
                new Lance
                {
                    LanceId = 1,
                    Data = new DateTime(2020, 5, 15, 17, 47, 0),
                    Valor = 200,
                    EmailUsuario = "marina.moreira@edu.pucrs.br",
                    LeilaoId = 1
                },
                new Lance
                {
                    LanceId = 2,
                    Data = new DateTime(2020, 5, 15, 17, 57, 0),
                    Valor = 212,
                    EmailUsuario = "thais.fernandes@edu.pucrs.br",
                    LeilaoId = 1
                },

                new Lance
                {
                    LanceId = 3,
                    Data = new DateTime(2020, 5, 16, 10, 10, 0),
                    Valor = 1000,
                    EmailUsuario = "felipe.fahrion@edu.pucrs.br",
                    LeilaoId = 2
                },
                new Lance
                {
                    LanceId = 4,
                    Data = new DateTime(2020, 5, 16, 10, 19, 0),
                    Valor = 1115,
                    EmailUsuario = "bruno.abbad@edu.pucrs.br",
                    LeilaoId = 2
                },

                new Lance
                {
                    LanceId = 5,
                    Data = new DateTime(2020, 5, 17, 20, 35, 0),
                    Valor = 515,
                    EmailUsuario = "arthur.maciel@edu.pucrs.br",
                    LeilaoId = 3
                },
                new Lance
                {
                    LanceId = 6,
                    Data = new DateTime(2020, 5, 17, 20, 46, 0),
                    Valor = 700,
                    EmailUsuario = "marina.moreira@edu.pucrs.br",
                    LeilaoId = 3
                },
            };

            context.Lances.AddRange(lances);
            context.SaveChanges();

        }

        private static void SeedLeiloes(LeilaoContext context)
        {
            var lote1 = new List<Item>();
            var lote2 = new List<Item>();
            var lote3 = new List<Item>();

            var itens = from i in context.Itens
                        where i.ItemId < 3
                        select i;

            lote1.AddRange(itens);

            //----------------------------------------

            itens = from i in context.Itens
                    where i.ItemId >= 3 && i.ItemId <= 5
                    select i;

            lote2.AddRange(itens);

            //----------------------------------------

            itens = from i in context.Itens
                    where i.ItemId > 5
                    select i;

            lote3.AddRange(itens);

            //----------------------------------------

            var lances1 = new List<Lance>();
            var lances2 = new List<Lance>();
            var lances3 = new List<Lance>();

            var lances = from i in context.Lances
                        where i.LanceId < 3
                        select i;

            lances1.AddRange(lances);

            //----------------------------------------

            lances = from i in context.Lances
                    where i.LanceId >= 3 && i.LanceId <= 5
                    select i;

            lances2.AddRange(lances);

            //----------------------------------------

            lances = from i in context.Lances
                    where i.LanceId > 5
                    select i;

            lances3.AddRange(lances);

            //----------------------------------------

            List<Leilao> leiloes = new List<Leilao>
            {
                new Leilao
                {
                    LeilaoId = 1,
                    CategoriaDeLance = TipoLance.Aberto,
                    DataInicio = new DateTime(2020, 6, 1, 7, 47, 0),
                    IdUsuarioResponsavel = "12378589940",
                    Lote = lote1,
                    Lances = lances1,
                    Categoria = TipoLeilao.Demanda,
                    Preco = 2000
                },
                new Leilao
                {
                    LeilaoId = 2,
                    CategoriaDeLance = TipoLance.Fechado,
                    DataInicio = new DateTime(2020, 6, 1, 7, 47, 0),
                    IdUsuarioResponsavel = "97974378827",
                    Lote = lote2,
                    Lances = lances2,
                    Categoria = TipoLeilao.Oferta,
                    Preco = 300,
                },
                new Leilao
                {
                    LeilaoId = 3,
                    CategoriaDeLance = TipoLance.Aberto,
                    DataInicio = new DateTime(2020, 6, 1, 7, 47, 0),
                    IdUsuarioResponsavel = "67456378829",
                    Lote = lote3,
                    Lances = lances3,
                    Categoria = TipoLeilao.Oferta,
                    Preco = 500,
                },
            };

            context.Leiloes.AddRange(leiloes);
            context.SaveChanges();

        }
    }
}
