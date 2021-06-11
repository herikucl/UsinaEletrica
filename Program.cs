using System;

namespace UsinaEletrica
{

    class Usina
    {
        public static DateTime Hoje = DateTime.Now;

        class Funcionarios
        {
            private string NomeCompleto;
            private int Cpf;
            private int Rg;
            private char Sexo;
            private int id;
            private float Salario;
            private DateTime DataDeIngresso;
            private DateTime DataDeSaida;
            private string Cargo;
            private string Estado;
            private string Bairro;
            private string Rua;
            private int Numero;
            private int Cep;

            public void Ficha()
            {
                Console.WriteLine("NomeCompleto: {0}", NomeCompleto);
                Console.WriteLine("Cpf: {0}", Cpf);
                Console.WriteLine("Rg: {0}", Rg);
                Console.WriteLine("Sexo:{0}", Sexo);
                Console.WriteLine("id:{0}", id);
                Console.WriteLine("Salario:{0}", Salario);
                Console.WriteLine("DataDeIngresso:{0}", DataDeIngresso);
                Console.WriteLine("DataDeSaida:{0}", DataDeSaida);
                Console.WriteLine("Cargo:{0}", Cargo);
                Console.WriteLine("Estado:{0}", Estado);
                Console.WriteLine("Bairro:{0}", Bairro);
                Console.WriteLine("Rua:{0}", Rua);
                Console.WriteLine("Numero:{0}", Numero);
                Console.WriteLine("Cep:{0}", Cep);
            }
        }

        class Engenheiro
        {
            private string Graduação;
            private string ExperienciaProfissional;
            private DateTime VencimentoCrea;

            public void VerificarValidadeCrea()
            {
                Console.WriteLine("Data de vencimento do crea: {0}",VencimentoCrea);
                if (Hoje < VencimentoCrea)
                {
                    Console.WriteLine("Valido");
                }
                else if (Hoje > VencimentoCrea)
                {
                    Console.WriteLine("Vencido");
                }
                else
                {
                    Console.WriteLine("Vence hoje!");
                }

            }


        }
    }

        class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
