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
        private int Contato;
        private long Cpf;
        private int Rg;
        private char Sexo;
        private int Id;
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
            Console.WriteLine("id:{0}", Id);
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
            return Id;
        }
        public void setNomeCompleto(string n) 
        {
            NomeCompleto = n;
        }
        public void setContato(int i)
        {
            Contato = i;
        }
        public void setCpf(long c)
        {
            Cpf = c;
        }
        public void setRg(int r)
        {
            Rg = r;
        }
        public void setSexo(char s)
        {
            Sexo = s;
        }
        public void setId(int i)
        {
            Id = i;
        }
        public void setSalario(float s)
        {
            Salario = s;
        }
        public void setDataDeIngresso(DateTime i)
        {
            DataDeIngresso = i;
        }
        public void setDataDeSaida(DateTime o)
        {
            DataDeSaida = o;
        }
        public void setCargo(string c)
        {
            Cargo = c;
        }
        public void setEstado(string e)
        {
            Estado = e;
        }
        public void setBairro(string b)
        {
            Bairro = b;
        }
        public void setRua(string r)
        {
            Rua = r;
        }
        public void setNumero(int n)
        {
            Numero = n;
        }
        public void setCep(int c)
        {
            Cep = c;
        }
        


    }
    class Engenheiro : Funcionarios
    {
        private string Graduação;
        private string ExperienciaProfissional;
        private DateTime VencimentoCrea;
        
        public Engenheiro(string nome, int numc,int rg, long cpf, char sx, int id, float sal,DateTime i, string c, string est, string bairro, string rua, int num, int cep,string g, string exp, DateTime v)
        {
            setNomeCompleto(nome);
            setContato(numc);
            setCpf(cpf);
            setRg(rg);
            setSexo(sx);
            setId(id);
            setSalario(sal);
            setDataDeIngresso(i);
            setCargo(c);
            setEstado(est);
            setBairro(bairro);
            setRua(rua); 
            setNumero(num);
            setCep(cep);
            Graduação=g;
            ExperienciaProfissional=exp;
            VencimentoCrea=v;
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

        public Tecnico(string nome, int numc, int rg, long cpf, char sx, int id, float sal, DateTime i, string c, string est, string bairro, string rua, int num, int cep, string f)
        {
            setNomeCompleto(nome);
            setContato(numc);
            setCpf(cpf);
            setRg(rg);
            setSexo(sx);
            setId(id);
            setSalario(sal);
            setDataDeIngresso(i);
            setCargo(c);
            setEstado(est);
            setBairro(bairro);
            setRua(rua);
            setNumero(num);
            setCep(cep);
            Formação = f;
        }
        public void FichaCompleta()
        {
            Ficha();
            Console.WriteLine("Formação:{0}", Formação);
        }
    }
    class RecursosHumanos : Funcionarios
    {

        public RecursosHumanos(string nome, int numc, int rg, long cpf, char sx, int id, float sal, DateTime i, string c, string est, string bairro, string rua, int num, int cep)
        {
            setNomeCompleto(nome);
            setContato(numc);
            setCpf(cpf);
            setRg(rg);
            setSexo(sx);
            setId(id);
            setSalario(sal);
            setDataDeIngresso(i);
            setCargo(c);
            setEstado(est);
            setBairro(bairro);
            setRua(rua);
            setNumero(num);
            setCep(cep);
        }
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

        public Controle()
        {
            
        } 
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

        private int QntTurbinas;
        private int QntGeradores;
        private float PotenciaPorRev;
        private float RevPorMin;
        private float EnergiaGerada;
        private float GastoDeEnergia;
        private bool Alarme;

        public void setQntTurbinas(int t)
        {
            QntTurbinas = t;
        }
        public void setQntGeradores(int g)
        {
            QntGeradores = g;
        }
        public void setPotenciaPorRev(float p)
        {
            PotenciaPorRev = p;
        }
        public void setRevPorMin(float r)
        {
            RevPorMin = r;
        }
        public void setAlarme(bool e)
        {
            Alarme = e;
        }
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
        public float getRevPorMin()
        {
            return RevPorMin;
        }



    }
    class Hidreletrica : Gerador
    {
        private float AlturaDaAgua;
        private bool Comportas;

        public Hidreletrica(int turb, int ger, float potrev)
        {
            setQntTurbinas(turb);
            setQntGeradores(ger);
            setPotenciaPorRev(potrev);
        }

        public float RevPorMin()
        {
            setRevPorMin(((float)Math.Sqrt(2 * 9.81 * AlturaDaAgua)) / 2);
            return getRevPorMin();
        }


    }
    class Nuclear : Gerador
    {
        private string MaterialUtilizado;
        private float MedidorRadiação;
        public Nuclear(int turb, int ger, float potrev)
        {
            setQntTurbinas(turb);
            setQntGeradores(ger);
            setPotenciaPorRev(potrev);
        }
        public float RevPorMin()
        {
            switch (MaterialUtilizado)
            {
                case "Radio":
                    setRevPorMin(88);
                    break;
                case "Césio":
                    setRevPorMin(137);
                    break;
                case "Uranio":
                    setRevPorMin(92);
                    break;
                case "Plutonio":
                    setRevPorMin(94);
                    break;
                default:
                    setRevPorMin(50);
                    break;

            }
            return getRevPorMin();
        }

        private void LigarAlarme()
        {
            if (MedidorRadiação > 80)
            {
                setAlarme(true);
            }
        }
        private void DesligarAlarme()
        {
            setAlarme(false);
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
        public Eolico(int turb, int ger, float potrev)
        {
            setQntTurbinas(turb);
            setQntGeradores(ger);
            setPotenciaPorRev(potrev);
        }
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
        public float RevPorMin()
        {
            setRevPorMin((float)(2 * Math.PI) / VelocidadePas);
            return getRevPorMin();

        }

    }

    class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
