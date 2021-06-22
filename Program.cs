using System;

namespace UsinaEletrica
{

    class Usina
    {
        public static DateTime Hoje = DateTime.Now;
        //public Controle Controlador;
        private Engenheiro[] Eng = new Engenheiro[50];
        private Tecnico[] Tec = new Tecnico[20];
        private RecursosHumanos[] RH = new RecursosHumanos[10];
        private float SalarioFuncionarios;
        private float PreçoKW;
        private float EnergiaMensal;
        private float LucroMensal;

        public float Lucro()
        {
            return LucroMensal;
        }
        public float ValorGerado()
        {
           EnergiaMensal = getEnergiaTotal() - getGastoTotal();
            return EnergiaMensal * PreçoKW;
        }
        public void PagarFuncionarios()
        {
            for (int i = 0; i < 50; i++)
            {
                SalarioFuncionarios+=Eng[i].getSalario();
            }
            for (int i = 0; i < 20; i++)
            {
                SalarioFuncionarios += Tec[i].getSalario();
            }
            for (int i = 0; i < 10; i++)
            {
                SalarioFuncionarios += RH[i].getSalario();
            }
            LucroMensal = ValorGerado() - SalarioFuncionarios;
        }




        class Funcionarios
        {
            private string NomeCompleto;
            private long Cpf;
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

            public float getSalario()
            {
                return Salario;
            }
        }

        class Engenheiro : Funcionarios
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

            public void FichaCompleta()
            {
                Ficha();
                Console.WriteLine("Graduação:{0}", Graduação);
                Console.WriteLine("ExperienciaProfissional:{0}", ExperienciaProfissional);
                Console.WriteLine("VencimentoCrea:{0}", VencimentoCrea);
            }
        }
        class Tecnico : Funcionarios 
        {
            private string Formação;


            public void FichaCompleta()
            {
                Ficha();
                Console.WriteLine("Formação:{0}", Formação);
            }
        }

        class RecursosHumanos: Funcionarios
        {
            public void FichaCompleta()
            {
                Ficha();
            }

            public void Promover(int i, string c)
            {
                for (int j = 0; i < 50; i++)
                {
                    if (Eng[i].getId() == i) 
                    {
                        Eng[i].setCargo() == c;
                    }
                }
                for (int k = 0; i < 20; i++)
                {
                    if (Tec[i].getId() == i)
                    {
                        Tec[i].setCargo() == c;
                    }
                }
                for (int l = 0; i < 10; i++)
                {
                    if (RH[i].getId() == i)
                    {
                        RH[i].setCargo() == c;
                    }
                }

            }
            public void Contratar()
            {

            }

            public void Demitir()
            {

            }

            public void DefinirSalario()
            {

            }

        }


    }//usina

        class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
