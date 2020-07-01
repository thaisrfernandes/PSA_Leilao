using TF_PSA.PL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                    Email = "thais.fernandes@edu.pucrs.br"
                },
                new Usuario
                {
                    UsuarioId = "87834528750",
                    Nome = "Marina",
                    Email = "marina.moreira@edu.pucrs.br"
                },
                new Usuario
                {
                    UsuarioId = "67456378829",
                    Nome = "Arthur",
                    Email = "arthur.maciel@edu.pucrs.br"
                },
                new Usuario
                {
                    UsuarioId = "12378589940",
                    Nome = "Felipe",
                    Email = "felipe.fahrion@edu.pucrs.br"
                },
                new Usuario
                {
                    UsuarioId = "34709567830",
                    Nome = "Bruno",
                    Email = "bruno.abbad@edu.pucrs.br"
                },
            };

            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();

            Console.WriteLine("Usuarios salvos");

            List<Item> itens = new List<Item>
            {
                new Item {
                    Nome = "Carrinho de bebê",
                    DescricaoBreve = "Carrinho de passeio para bebê da marca Galzerano",
                    DescricaoCompleta = "Carrinho de passeio para bebê da marca Galzerano",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Banquetas",
                    DescricaoBreve = "Banquetas para uso interno da casa. Idela em lugares com lobbys compartilhados",
                    DescricaoCompleta = "Banquetas para uso interno da casa. Idela em lugares com lobbys compartilhados",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Rélógio",
                    DescricaoBreve = "Relógio da marca Invicta, apenas 2 meses de uso",
                    DescricaoCompleta = "Relógio da marca Invicta, apenas 2 meses de uso",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Mouse",
                    DescricaoBreve = "Mouse wireless de Computador com entrada USB 2.0",
                    DescricaoCompleta = "Mouse wireless de Computador com entrada USB 2.0",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Livro Steve Jobs",
                    DescricaoBreve = "A Cabeça de Steve Jobs é um livro de Marcio Edson Tavares, lançado em 2010, que retrata aspectos da vida e personalidade de Steve Jobs. Conforme sinopse da Livraria Cultura, o livro é, ao mesmo tempo, uma biografia e um guia sobre liderança",
                    DescricaoCompleta = "A Cabeça de Steve Jobs é um livro de Marcio Edson Tavares, lançado em 2010, que retrata aspectos da vida e personalidade de Steve Jobs. Conforme sinopse da Livraria Cultura, o livro é, ao mesmo tempo, uma biografia e um guia sobre liderança",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Creme de massagem drenante",
                    DescricaoBreve = "Creme de massagem desenvolvido para auxiliar na ativação do sistema linfático, este creme com óleo de pimenta negra, termogênico de origem natural, é indicado para massagens modeladoras",
                    DescricaoCompleta = "Creme de massagem desenvolvido para auxiliar na ativação do sistema linfático, este creme com óleo de pimenta negra, termogênico de origem natural, é indicado para massagens modeladoras",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Halteres 20 kg",
                    DescricaoBreve = "2 (dois) Halteres, bem cuidados da marca Phonex. Com um ano de garantia",
                    DescricaoCompleta = "2 (dois) Halteres, bem cuidados da marca Phonex. Com um ano de garantia",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                }
            };

            context.Itens.AddRange(itens);
            context.SaveChanges();

            Console.WriteLine("Itens salvos");
        }

        private static void SeedItens(LeilaoContext context)
        {

            List<Item> itens = new List<Item>
            {
                new Item {
                    Nome = "Carrinho de bebê",
                    DescricaoBreve = "Carrinho de passeio para bebê da marca Galzerano",
                    DescricaoCompleta = "Carrinho de passeio para bebê da marca Galzerano",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Banquetas",
                    DescricaoBreve = "Banquetas para uso interno da casa. Idela em lugares com lobbys compartilhados",
                    DescricaoCompleta = "Banquetas para uso interno da casa. Idela em lugares com lobbys compartilhados",
                    Categoria = CategoriaEnum.Movel,
                    Imagem = null
                },
                new Item {
                    Nome = "Rélógio",
                    DescricaoBreve = "Relógio da marca Invicta, apenas 2 meses de uso",
                    DescricaoCompleta = "Relógio da marca Invicta, apenas 2 meses de uso",
                    Categoria = CategoriaEnum.Vestuario,
                    Imagem = null
                },
                new Item {
                    Nome = "Mouse",
                    DescricaoBreve = "Mouse wireless de Computador com entrada USB 2.0",
                    DescricaoCompleta = "Mouse wireless de Computador com entrada USB 2.0",
                    Categoria = CategoriaEnum.Eletronico,
                    Imagem = null
                },
                new Item {
                    Nome = "Livro Steve Jobs",
                    DescricaoBreve = "A Cabeça de Steve Jobs é um livro de Marcio Edson Tavares, lançado em 2010, que retrata aspectos da vida e personalidade de Steve Jobs. Conforme sinopse da Livraria Cultura, o livro é, ao mesmo tempo, uma biografia e um guia sobre liderança",
                    DescricaoCompleta = "A Cabeça de Steve Jobs é um livro de Marcio Edson Tavares, lançado em 2010, que retrata aspectos da vida e personalidade de Steve Jobs. Conforme sinopse da Livraria Cultura, o livro é, ao mesmo tempo, uma biografia e um guia sobre liderança",
                    Categoria = CategoriaEnum.Lazer,
                    Imagem = null
                },
                new Item {
                    Nome = "Creme de massagem drenante",
                    DescricaoBreve = "Creme de massagem desenvolvido para auxiliar na ativação do sistema linfático, este creme com óleo de pimenta negra, termogênico de origem natural, é indicado para massagens modeladoras",
                    DescricaoCompleta = "Creme de massagem desenvolvido para auxiliar na ativação do sistema linfático, este creme com óleo de pimenta negra, termogênico de origem natural, é indicado para massagens modeladoras",
                    Categoria = CategoriaEnum.Higiene,
                    Imagem = null
                },
                new Item {
                    Nome = "Halteres 20 kg",
                    DescricaoBreve = "2 (dois) Halteres, bem cuidados da marca Phonex. Com um ano de garantia",
                    DescricaoCompleta = "2 (dois) Halteres, bem cuidados da marca Phonex. Com um ano de garantia",
                    Categoria = CategoriaEnum.Esporte,
                    Imagem = null
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
                    Data = new DateTime(2020, 5, 15, 17, 47, 0),
                    Valor = 200,
                    EmailUsuario = "marina.moreira@edu.pucrs.br",
                    LeilaoId = 5
                },
                new Lance
                {
                    Data = new DateTime(2020, 5, 15, 17, 57, 0),
                    Valor = 212,
                    EmailUsuario = "thais.fernandes@edu.pucrs.br",
                    LeilaoId = 5
                },

                new Lance
                {
                    Data = new DateTime(2020, 5, 16, 10, 10, 0),
                    Valor = 1000,
                    EmailUsuario = "felipe.fahrion@edu.pucrs.br",
                    LeilaoId = 6
                },
                new Lance
                {
                    Data = new DateTime(2020, 5, 16, 10, 19, 0),
                    Valor = 1115,
                    EmailUsuario = "bruno.abbad@edu.pucrs.br",
                    LeilaoId = 6
                },

                new Lance
                {
                    Data = new DateTime(2020, 5, 17, 20, 35, 0),
                    Valor = 515,
                    EmailUsuario = "arthur.maciel@edu.pucrs.br",
                    LeilaoId = 7
                },
                new Lance
                {
                    Data = new DateTime(2020, 5, 17, 20, 46, 0),
                    Valor = 700,
                    EmailUsuario = "marina.moreira@edu.pucrs.br",
                    LeilaoId = 7
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
                           where i.ItemId < 17
                           select i;

            lote1.AddRange(itens);

            //----------------------------------------

            itens = from i in context.Itens
                        where i.ItemId >= 17  && i.ItemId < 19
                        select i;

            lote2.AddRange(itens);

            //----------------------------------------

            itens = from i in context.Itens
                    where i.ItemId >= 19 && i.ItemId < 21
                    select i;

            lote3.AddRange(itens);

            //----------------------------------------
            
            var lance1 = new List<Lance>();
            var lance2 = new List<Lance>();
            var lance3 = new List<Lance>();

            var lances = from l in context.Lances
                        where l.LanceId < 3
                        select l;

            lance1.AddRange(lances);

            //----------------------------------------

            lances = from l in context.Lances
                     where l.LanceId >= 3 && l.LanceId < 4
                     select l;

            lance2.AddRange(lances);

            //----------------------------------------

            lances = from l in context.Lances
                     where l.LanceId >= 4 && l.LanceId < 6
                     select l;

            lance3.AddRange(lances);
            
            //----------------------------------------
            
            List<Leilao> leiloes = new List<Leilao>
            {
                new Leilao
                {
                    CategoriaDeLance = TipoLance.Aberto,
                    DataInicio = new DateTime(2020, 6, 1, 7, 47, 0),
                    DataFinal = new DateTime(2020, 6, 1, 7, 47, 0),
                    IdUsuarioResponsavel = "12378589940",
                    Lote = lote1,
                    Lances = lance1,
                    Categoria = TipoLeilao.Demanda,
                    Preco = 2000
                },
                new Leilao
                {
                    CategoriaDeLance = TipoLance.Fechado,
                    DataInicio = new DateTime(2020, 6, 1, 7, 47, 0),
                    DataFinal = new DateTime(2020, 6, 1, 7, 47, 0),
                    IdUsuarioResponsavel = "97974378827",
                    Lote = lote2,
                    Lances = lance2,
                    Categoria = TipoLeilao.Oferta,
                    Preco = 300,
                },
                new Leilao
                {
                    CategoriaDeLance = TipoLance.Aberto,
                    DataInicio = new DateTime(2020, 6, 1, 7, 47, 0),
                    DataFinal = new DateTime(2020, 6, 1, 7, 47, 0),
                    IdUsuarioResponsavel = "67456378829",
                    Lote = lote3,
                    Lances = lance3,
                    Categoria = TipoLeilao.Oferta,
                    Preco = 500,
                },
            };

            context.Leiloes.AddRange(leiloes);
            context.SaveChanges();

        }
    }
}
 