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
                #region seeding
                if (db.Usuarios.Count() == 0)
                {
                    Seed(db);
                }
                #endregion

                #region consultas

                LeilaoContext context = new LeilaoContext();

                var usuarios = from c in context.Usuarios
                             select c.Nome;

                Console.WriteLine(" ");
                Console.WriteLine("Usuarios registrados: ");
                foreach (String usuarioNome in usuarios)
                {
                    Console.WriteLine(usuarioNome);
                }

                Console.ReadKey();
                #endregion
            }
        }


        private static void Seed(LeilaoContext context)
        {

            List<Usuario> usuarios = new List<Usuario> { 
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

        }
    }

}