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

                Console.ReadKey();
                #endregion

               
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
    }

}