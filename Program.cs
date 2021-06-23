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
        private int[] IdFuncionarios= new int[81];
        
        public Usina(float p)
        {
            PreçoKW = p;
        }
        public void setControlador(Controle c)
        {
            Controlador = c;
        }
        public void setEngenheiro(Engenheiro e)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Eng[i].getID() == 0)
                {
                    Eng[i] = e;
                }
            }
        }
        public void setTecnico(Tecnico t)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Tec[i].getID() == 0)
                {
                    Tec[i] = t;
                }
            }
        }
        public void setRecursosHumanos(RecursosHumanos r)
        {
            for (int i = 0; i < 10; i++)
            {
                if (RH[i].getID() == 0)
                {
                    RH[i] = r;
                }
            }
        }

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
        public void GerarListaID()
        {
            for (int i = 1; i < 80; i++)
            {
                IdFuncionarios[i] = Eng[i].getID();
                if (i > 50)
                {
                    IdFuncionarios[i] = Tec[i].getID();
                    if (i > 70)
                    {
                        IdFuncionarios[i] = RH[i].getID();
                    }
                }
            }
        }
        public void setListaID(int i,string c)
        {
            if(i>0 & i < 51)
            {
                Eng[i].setCargo(c);
            }else if(i>50 & i<71){
                Tec[i - 50].setCargo(c);
            }else if(i>70 & i < 81)
            {
                RH[i - 70].setCargo(c);
            }  
        }
        public void Demissão(int id)
        {
            for (int i = 1; i < 80; i++)
            {
                if (getListaID(i) == id)
                {
                    if (i > 0 & i < 51)
                    {
                        Eng[i] = new Engenheiro();
                    }
                    else if (i > 50 & i < 71)
                    {
                        Tec[i] = new Tecnico();
                    }
                    else if (i > 70 & i < 81)
                    {
                        RH[i] = new RecursosHumanos();
                    }
                }
            }

        }
        public int getListaID(int i)
        {
            return IdFuncionarios[i];
        }
        public void Salario(int id,float p)
        {
            for (int i = 1; i < 80; i++)
            {
                if (getListaID(i) == id)
                {
                    if (i > 0 & i < 51)
                    {
                        Eng[i].setSalario(p);
                    }
                    else if (i > 50 & i < 71)
                    {
                        Tec[i].setSalario(p);
                    }
                    else if (i > 70 & i < 81)
                    {
                        RH[i].setSalario(p);
                    }
                }
            }
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
        
        public Engenheiro(){ }
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

        public Tecnico() { }
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
        private Usina UsinaRH;
        
        public RecursosHumanos() { }
        public RecursosHumanos(Usina usina,string nome, int numc, int rg, long cpf, char sx, int id, float sal, DateTime i, string c, string est, string bairro, string rua, int num, int cep)
        {
            UsinaRH = usina;
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
            for (int i = 1; i < 80; i++)
            {
                if (UsinaRH.getListaID(i) == id)
                {
                    UsinaRH.setListaID(i, c);
                }
            }
        }
        public void Contratar(Engenheiro e)
        {
            UsinaRH.setEngenheiro(e);  
        }
        public void Contratar(RecursosHumanos r)
        {
            UsinaRH.setRecursosHumanos(r);
        }
        public void Contratar(Tecnico t)
        {
            UsinaRH.setTecnico(t);
        }

        public void Demitir(int id)
        {
            UsinaRH.Demissão(id);
        }

        public void DefinirSalario(int id,float p)
        {
            UsinaRH.Salario(id, p);
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
        public void setHidreletrica(Hidreletrica h)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Hidro[i].getQntTurbinas() == 0)
                {
                    Hidro[i] = h;
                    i = 51;
                }
            }
        }
        public void setNuclear(Nuclear n)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Rad[i].getQntTurbinas() == 0)
                {
                    Rad[i] = n;
                    i = 51;
                }
            }
        }
        public void setEolica(Eolico e)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Vent[i].getQntTurbinas() == 0)
                {
                    Vent[i] = e;
                    i = 51;
                }
            }
        }
        public void setEnergiaTotalM()
        {
            for (int i = 0; i < 20; i++)
            {
                EnergiaTotal += Hidro[i].getEnergiaGeradaM();
                EnergiaTotal += Rad[i].getEnergiaGeradaM();
                EnergiaTotal += Vent[i].getEnergiaGeradaM();
            }
        }
        public void setGastoTotalM()
        {
            for (int i = 0; i < 20; i++)
            {
                GastoTotal += Hidro[i].getGastoDeEnergiaM();
                GastoTotal += Rad[i].getGastoDeEnergiaM();
                GastoTotal += Vent[i].getGastoDeEnergiaM();
            }
        }
        public void setQntTurbinasTotal()
        {
            for (int i = 0; i < 20; i++)
            {
                QntTurbinasTotal += Hidro[i].getQntTurbinas();
                QntTurbinasTotal += Rad[i].getQntTurbinas();
                QntTurbinasTotal += Vent[i].getQntTurbinas();
            }
        }
        public void setQntGeradoresTotal()
        {
            for (int i = 0; i < 20; i++)
            {
                QntGeradoresTotal += Hidro[i].getQntGeradores();
                QntGeradoresTotal += Rad[i].getQntGeradores();
                QntGeradoresTotal += Vent[i].getQntGeradores();
            }
        }
        public float getEnergiaTotalM()
        {
            return EnergiaTotal;
        }
        public float getGastoTotalM()
        {
            return GastoTotal;
        }
        public int getQntTurbinasTotal()
        {
            return QntTurbinasTotal;
        }
        public int getQntGeradoresTotal()
        {
            return QntGeradoresTotal;
        }
        public void Atualizar()
        {
            setEnergiaTotalM();
            setGastoTotalM();
            setQntGeradoresTotal();
            setQntTurbinasTotal();
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
