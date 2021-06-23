using System;

namespace UsinaEletrica
{
    class Usina
    {
        public static DateTime Hoje = DateTime.Now;
        private Controle Controlador = new Controle();
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
            EnergiaMensal = Controlador.getEnergiaTotalM() - Controlador.getGastoTotalM(); 
            return EnergiaMensal * PreçoKW;
        }
        public void PagarFuncionarios()
        {
            for (int i = 0; i < 50; i++)
            {
                SalarioFuncionarios += Eng[i].getSalario();
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
        public int getID(int i)
        {
            return Eng[i].getID();
        }
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
        public int getID()
        {
            return id;
        }
        public void setCargo(string a)
        {
            Cargo = a;
        }

    }
    class Engenheiro : Funcionarios
    {
        private string Graduação;
        private string ExperienciaProfissional;
        private DateTime VencimentoCrea;
        
        public Engenheiro(string g, string exp, DateTime V)
        {

        }
        public void VerificarValidadeCrea()
        {
            Console.WriteLine("Data de vencimento do crea: {0}", VencimentoCrea);
            if (Usina.Hoje < VencimentoCrea)
            {
                Console.WriteLine("Valido");
            }
            else if (Usina.Hoje > VencimentoCrea)
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
    class RecursosHumanos : Funcionarios
    {
        public void FichaCompleta()
        {
            Ficha();
        }

        public void Promover(int id, string c)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Usina.getID(i) == id)
                {
                    setCargo(c);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                if (Tec[i].getId() == id)
                {
                    Tec[i].setCargo(c);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (RH[i].getId() == id)
                {
                    RH[i].setCargo(c);
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
    class Controle
    {
        private Hidreletrica[] Hidro = new Hidreletrica[20];
        private Nuclear[] Rad = new Nuclear[20];
        private Eolico[] Vent = new Eolico[20];
        private int QntTurbinasTotal;
        private int QntGeradoresTotal;
        private float EnergiaTotal;
        private float GastoTotal;

        public float getEnergiaTotalM()
        {
            for (int i = 0; i < 20; i++)
            {
                EnergiaTotal += Hidro[i].getEnergiaGeradaM();
                EnergiaTotal += Rad[i].getEnergiaGeradaM();
                EnergiaTotal += Vent[i].getEnergiaGeradaM();
            }
            return EnergiaTotal;
        }
        public float getGastoTotalM()
        {
            for (int i = 0; i < 20; i++)
            {
                GastoTotal += Hidro[i].getGastoDeEnergiaM();
                GastoTotal += Rad[i].getGastoDeEnergiaM();
                GastoTotal += Vent[i].getGastoDeEnergiaM();
            }
            return GastoTotal;
        }
        public int getQntTurbinasTotal()
        {
            for (int i = 0; i < 20; i++)
            {
                QntTurbinasTotal += Hidro[i].getQntTurbinas();
                QntTurbinasTotal += Rad[i].getQntTurbinas();
                QntTurbinasTotal += Vent[i].getQntTurbinas();
            }
            return QntTurbinasTotal;
        }
        public int getQntGeradoresTotal()
        {
            for (int i = 0; i < 20; i++)
            {
                QntGeradoresTotal += Hidro[i].getQntGeradores();
                QntGeradoresTotal += Rad[i].getQntGeradores();
                QntGeradoresTotal += Vent[i].getQntGeradores();
            }
            return QntGeradoresTotal;
        }
    }
    class Gerador
    {

        public int QntTurbinas;
        public int QntGeradores;
        private float PotenciaPorRev;
        public float RevPorMin;
        public float EnergiaGerada;
        public float GastoDeEnergia;
        public bool Alarme;

        public float getEnergiaGeradaM()
        {
            return EnergiaGerada;
        }
        public float getGastoDeEnergiaM()
        {
            return GastoDeEnergia;
        }
        public int getQntTurbinas()
        {
            return QntTurbinas;
        }
        public int getQntGeradores()
        {
            return QntGeradores;
        }



    }
    class Hidreletrica : Gerador
    {
        private float AlturaDaAgua;
        private bool Comportas;

        public float getRevPorMin()
        {
            RevPorMin = ((float)Math.Sqrt(2 * 9.81 * AlturaDaAgua)) / 2;
            return RevPorMin;
        }


    }
    class Nuclear : Gerador
    {
        private string MaterialUtilizado;
        private float MedidorRadiação;

        public float getRevPorMin()
        {
            switch (MaterialUtilizado)
            {
                case "Radio":
                    RevPorMin = 88;
                    break;
                case "Césio":
                    RevPorMin = 137;
                    break;
                case "Uranio":
                    RevPorMin = 92;
                    break;
                case "Plutonio":
                    RevPorMin = 94;
                    break;
                default:
                    RevPorMin = 50;
                    break;

            }
            return RevPorMin;
        }

        private void LigarAlarme()
        {
            if (MedidorRadiação > 80)
            {
                Alarme = true;
            }
        }
        private void DesligarAlarme()
        {
            Alarme = false;
        }


    }
    class Eolico : Gerador
    {
        private float VelocidadeVento;
        private float VelocidadePas;
        private float VelocidadeRelativa;
        private float Direção;
        private float DireçãoNacele;
        private float DireçãoPas;

        public void setVelocidadeRelativa()
        {
            VelocidadeRelativa = (float)Math.Sqrt((float)Math.Pow(VelocidadeVento, 2) * (float)Math.Pow(VelocidadePas, 2));
        }
        public void GirarConjunto()
        {
            DireçãoNacele = Direção;
        }
        public void GirarPas()
        {
            setVelocidadeRelativa();
            DireçãoPas = (float)Math.Asin(VelocidadeVento / VelocidadeRelativa);
        }
        public float getRevPorMin()
        {
            RevPorMin = (float)(2 * Math.PI) / VelocidadePas;
            return RevPorMin;

        }

    }

    class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
