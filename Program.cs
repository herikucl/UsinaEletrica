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
        private float Receita;
        private float PreçoKW;
        private float EnergiaMensal;
        private float ValorProduzido;
        private float ValorLiquido;
        private float LucroMensal;
        private int[] IdFuncionarios= new int[81];

        public void setControlador(Controle c)
        {
            Controlador = c;
        }
        public void setEngenheiro(Engenheiro e)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Eng[i] == null)
                {
                    Eng[i] = e;
                    i = 11;
                }
            }
        }
        public void setTecnico(Tecnico t)
        {
            for (int i = 0; i < 20; i++)
            {
                if (Tec[i] == null)
                {
                    Tec[i] = t;
                    i = 11;
                }
            }
        }
        public void setRecursosHumanos(RecursosHumanos r)
        {
            for (int i = 0; i < 10; i++)
            {
                if (RH[i] == null)
                {
                    RH[i] = r;
                    i = 11;
                }
            }
        }
        public void setPreçoKW(float p)
        {
            PreçoKW = p;
        }
        public float getValorLiquido()
        {
            return ValorLiquido;
        }
        public float getReceita()
        {
            return Receita;
        }
        public float ValorGerado()
        {
            EnergiaMensal = (Controlador.getEnergiaTotalM())/1000; 
            ValorProduzido = EnergiaMensal * PreçoKW;
            return ValorProduzido;
        }
        public float Lucro()
        {
            LucroMensal = ((Controlador.getEnergiaTotalM() - Controlador.getGastoTotalM()) / 1000) * PreçoKW;
            return LucroMensal;
        }
        public float getLucroMensal()
        {
            return LucroMensal;
        }
        public void PagarFuncionarios()
        {
            SalarioFuncionarios = 0;
            for (int i = 0; i < 50; i++)
            {
                if (Eng[i] != null)
                {
                    SalarioFuncionarios += Eng[i].getSalario();
                }
            }
            for (int i = 0; i < 20; i++)
            {
                if (Tec[i] != null)
                {
                    SalarioFuncionarios += Tec[i].getSalario();
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (RH[i] != null)
                {
                    SalarioFuncionarios += RH[i].getSalario();
                }
            }
            setValorLiquido(LucroMensal-SalarioFuncionarios);
            Receita += ValorLiquido;
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
        public void setValorLiquido(float p)
        {
            ValorLiquido = p;
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

        public void Atualizar()
        { 
            GerarListaID();
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
        public RecursosHumanos() { }
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

        public void Promover(Usina u,int id, string c)
        {
            for (int i = 1; i < 80; i++)
            {
                if (u.getListaID(i) == id)
                {
                    u.setListaID(i, c);
                }
            }
        }
        public void Contratar(Usina u,Engenheiro e)
        {
            u.setEngenheiro(e);  
        }
        public void Contratar(Usina u,RecursosHumanos r)
        {
            u.setRecursosHumanos(r);
        }
        public void Contratar(Usina u,Tecnico t)
        {
            u.setTecnico(t);
        }

        public void Demitir(Usina u,int id)
        {
            u.Demissão(id);
        }

        public void DefinirSalario(Usina u,int id,float p)
        {
            u.Salario(id, p);
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
            for (int i = 0; i < 20; i++)
            {
                if (Hidro[i] == null)
                {
                    Hidro[i] = h;
                    i = 21;
                }
            }
        }
        public void setNuclear(Nuclear n)
        {
            for (int i = 0; i < 20; i++)
            {
                if (Rad[i]== null)
                {
                    Rad[i] = n;
                    i = 21;
                }
            }
        }
        public void setEolica(Eolico e)
        {
            for (int i = 0; i < 20; i++)
            {
                if (Vent[i]== null)
                {
                    Vent[i] = e;
                    i = 21;
                }
            }
        }
        public void setEnergiaTotalM()
        {
            for (int i = 0; i < 20; i++)
            {
                if (Hidro[i] != null)
                {
                    Hidro[i].Atualizar();
                    EnergiaTotal += Hidro[i].getEnergiaGerada();
                }
                if (Rad[i] != null)
                {
                    Rad[i].Atualizar();
                    EnergiaTotal += Rad[i].getEnergiaGerada();
                }
                if (Vent[i] != null)
                {
                    Vent[i].Atualizar();
                    EnergiaTotal += Vent[i].getEnergiaGerada();
                }  
            }
        }
        public void setGastoTotalM()
        {
            
            for (int i = 0; i < 20; i++)
            {
                if (Hidro[i] != null)
                {
                    GastoTotal += Hidro[i].getGastoDeEnergia();
                }
                if (Rad[i] != null)
                {
                    GastoTotal += Rad[i].getGastoDeEnergia();
                }
                if (Vent[i] != null)
                {
                    GastoTotal += Vent[i].getGastoDeEnergia();
                }

                
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
            EnergiaTotal = 0;
            GastoTotal = 0;
            setEnergiaTotalM();
            setGastoTotalM();
        }
        public void Extrato()
        {
            Console.WriteLine("Quantidade totais de Geradores: {0}",getQntGeradoresTotal());
            Console.WriteLine("Quantidade totais de Geradores: {0}",getQntTurbinasTotal());
            Console.WriteLine("Gasto total: {0}",getGastoTotalM());
            Console.WriteLine("Energia total gerada: {0}",getEnergiaTotalM());
        }
    }
    class Gerador
    {
        private int QntTurbinas=0;
        private int QntGeradores=0;
        private float PotenciaPorRev=0;
        private float RevPorMin=0;
        private float EnergiaGerada=0;
        private float GastoDeEnergia=0;
        private bool Alarme=false;

        public void AtualizarP()
        {
            EnergiaGeradaM();
        }
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
        public float getEnergiaGerada()
        {
            return EnergiaGerada;
        }
        public float getGastoDeEnergia()
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
        public float getPotenciaPorRev()
        {
            return PotenciaPorRev;
        }  
        public void setGastoDeEnergia(float g)
        {
            GastoDeEnergia = g;
        }
        public void EnergiaGeradaM()
        {
            EnergiaGerada = getRevPorMin() * getPotenciaPorRev() * 43800;
        }
    }
    class Hidreletrica : Gerador
    {
        private float AlturaDaAgua=0;
        private bool Comportas=false;

        public void Atualizar()
        {
            RevPorMin();
            VerificarNivel();
            if (Comportas == true)
            {
                AlturaDaAgua -= 50;
            }
            AtualizarP();
        }
        public Hidreletrica(int turb, int ger, float potrev)
        {
            setQntTurbinas(turb);
            setQntGeradores(ger);
            setPotenciaPorRev(potrev);
        }

        public void RevPorMin()
        {
            setRevPorMin(((float)Math.Sqrt(2 * 9.81 * AlturaDaAgua)) / 2);
        }
        public void setAltura(float h)
        {
            AlturaDaAgua = h;
        }
        public void VerificarNivel()
        {
            if (AlturaDaAgua > 140)
            {
                setAlarme(true);
                Comportas = true;
            }
            else
            {
                setAlarme(true);
                Comportas = false;
            }
        }


    }
    class Nuclear : Gerador
    {

        private string MaterialUtilizado;
        private float MedidorRadiação=0;

        public void Atualizar()
        {
            RevPorMin();
            switch (MaterialUtilizado)
            {
                case "Césio":
                    setMedidorRadiação((float)1.37);
                    break;
                case "Plutonio":
                    setMedidorRadiação((float)0.94);
                    break;
                case "Uranio":
                    setMedidorRadiação((float)0.92);
                    break;
                case "Radio":
                    setMedidorRadiação((float)0.88);
                    break;
                default:
                    setMedidorRadiação((float)-0.5);
                    break;
            }
            AtualizarP();
        }
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
                    setRevPorMin(0);
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
        public void setMaterialUtilizado(string r)
        {
            MaterialUtilizado = r;
        }
        public void setMedidorRadiação(float m)
        {
            MedidorRadiação += m;
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

        public void Atualizar()
        {
            setVelocidadeRelativa();
            RevPorMin();
            AtualizarP();
        }
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
        public void setVelocidadeVento(float v)
        {
            VelocidadeVento = v;
        }
        public void setDireção(float d)
        {
            Direção = d;
        }
        public void setVelocidadePas(float vp)
        {
            VelocidadePas = vp;
        }

    }
    class Program
        {
            static void Main(string[] args)
            {
            Usina Itaipu = new Usina();
            Hidreletrica Hidro1 = new Hidreletrica(1, 1, 100);
            Hidreletrica Hidro2 = new Hidreletrica(2, 2, 50);
            Hidreletrica Hidro3 = new Hidreletrica(3, 3, 80);
            Nuclear Rad1 = new Nuclear(4, 4, 500);
            Nuclear Rad2 = new Nuclear(5, 5, 800);
            Nuclear Rad3 = new Nuclear(6, 6, 700);
            Eolico Vent1 = new Eolico(7, 7, 500);
            Eolico Vent2 = new Eolico(8, 8, 300);
            Eolico Vent3 = new Eolico(9, 9, 200);
            Controle Ctrl = new Controle();

            Hidro1.setGastoDeEnergia(100000);
            Hidro1.setAltura(100);
            Hidro2.setGastoDeEnergia(200000);
            Hidro2.setAltura(120);
            Hidro3.setGastoDeEnergia(300000);
            Hidro3.setAltura(140);


            Rad1.setGastoDeEnergia(150000);
            Rad1.setMaterialUtilizado("Césio");
            Rad2.setGastoDeEnergia(500000);
            Rad2.setMaterialUtilizado("Plutonio");
            Rad3.setGastoDeEnergia(600000);
            Rad3.setMaterialUtilizado("Radio");

            Vent1.setGastoDeEnergia(50000);
            Vent1.setVelocidadeVento(60);
            Vent1.setVelocidadePas(30);
            Vent2.setGastoDeEnergia(80000);
            Vent2.setVelocidadeVento(70);
            Vent2.setVelocidadePas(45);
            Vent3.setGastoDeEnergia(90000);
            Vent3.setVelocidadeVento(80);
            Vent3.setVelocidadePas(40);

            Itaipu.setPreçoKW((float)1.5);

            Ctrl.setHidreletrica(Hidro1);
            Ctrl.setHidreletrica(Hidro2);
            Ctrl.setHidreletrica(Hidro3);
            Ctrl.setNuclear(Rad1);
            Ctrl.setNuclear(Rad2);
            Ctrl.setNuclear(Rad3);
            Ctrl.setEolica(Vent1);
            Ctrl.setEolica(Vent2);
            Ctrl.setEolica(Vent3);
            Itaipu.setControlador(Ctrl);
            Engenheiro Eng1 = new Engenheiro(); Eng1.setSalario(50000);
            Engenheiro Eng2 = new Engenheiro(); Eng2.setSalario(55000);
            Engenheiro Eng3 = new Engenheiro(); Eng3.setSalario(75000);
            Engenheiro Eng4 = new Engenheiro(); Eng4.setSalario(60000);
            Engenheiro Eng5 = new Engenheiro(); Eng5.setSalario(35000);
            Tecnico Tec1 = new Tecnico(); Tec1.setSalario(20000);
            Tecnico Tec2 = new Tecnico(); Tec2.setSalario(25000);
            Tecnico Tec3 = new Tecnico(); Tec3.setSalario(29750);
            Tecnico Tec4 = new Tecnico(); Tec4.setSalario(27500);
            Tecnico Tec5 = new Tecnico(); Tec5.setSalario(30000);
            RecursosHumanos Chefe = new RecursosHumanos(); Chefe.setNomeCompleto("Boss"); Chefe.setSalario(50000);
            RecursosHumanos Rh1 = new RecursosHumanos(); Rh1.setNomeCompleto("Cobaia1"); Rh1.setSalario(10000);
            RecursosHumanos Rh2 = new RecursosHumanos(); Rh2.setNomeCompleto("Cobaia2"); Rh2.setSalario(15000);
            RecursosHumanos Rh3 = new RecursosHumanos(); Rh3.setNomeCompleto("Cobaia3"); Rh3.setSalario(12000);
            RecursosHumanos Rh4 = new RecursosHumanos(); Rh4.setNomeCompleto("Cobaia4"); Rh4.setSalario(11000);
            RecursosHumanos Rh5 = new RecursosHumanos(); Rh5.setNomeCompleto("Cobaia5"); Rh5.setSalario(12500);
            Itaipu.setRecursosHumanos(Chefe);
            Chefe.Contratar(Itaipu,Rh1);
            Chefe.Contratar(Itaipu, Rh2);
            Chefe.Contratar(Itaipu, Rh3);
            Chefe.Contratar(Itaipu, Rh4);
            Chefe.Contratar(Itaipu, Rh5);
            Rh1.Contratar(Itaipu, Eng1);
            Rh1.Contratar(Itaipu, Tec1);
            Rh2.Contratar(Itaipu, Eng2);
            Rh2.Contratar(Itaipu, Tec2);
            Rh3.Contratar(Itaipu, Eng3);
            Rh3.Contratar(Itaipu, Tec3);
            Rh4.Contratar(Itaipu, Eng4);
            Rh4.Contratar(Itaipu, Tec4);
            Rh5.Contratar(Itaipu, Eng5);
            Rh5.Contratar(Itaipu, Tec5);


            for (int i = 1; i <= 12; i++)
            {
                if (i == 2)
                {
                    Vent1.setVelocidadeVento(10);
                    Vent1.setVelocidadePas(5);                 
                    Vent2.setVelocidadeVento(4);
                    Vent2.setVelocidadePas(2);
                    Vent3.setVelocidadeVento(30);
                    Vent3.setVelocidadePas(15);
                }else if (i == 3)
                {
                    Rad1.setMaterialUtilizado("");
                    Rad2.setMaterialUtilizado("");
                    Rad3.setMaterialUtilizado("");
                }else if (i == 5)
                {
                    Hidro1.setAltura(20);
                    Hidro1.setAltura(5);
                    Hidro1.setAltura(40);
                }else if (i == 8)
                {
                    Hidro1.setAltura(100);
                    Hidro2.setAltura(120);
                    Hidro3.setAltura(140);
                    Rad1.setMaterialUtilizado("Césio");
                    Rad2.setMaterialUtilizado("Plutonio");
                    Rad3.setMaterialUtilizado("Radio");
                    Vent1.setVelocidadeVento(60);
                    Vent1.setVelocidadePas(30);
                    Vent2.setVelocidadeVento(70);
                    Vent2.setVelocidadePas(45);
                    Vent3.setVelocidadeVento(80);
                    Vent3.setVelocidadePas(40);
                }
                Ctrl.Atualizar();
                Itaipu.Lucro();
                Itaipu.PagarFuncionarios();
                Console.WriteLine("Mês {0}-----Valor gerado: R${1}  /  Lucro: R${2}  / Valor liquido: R${3}  /  Receita: R${4}",i, Itaipu.ValorGerado(),Itaipu.getLucroMensal(),Itaipu.getValorLiquido(),Itaipu.getReceita());
            }
        }
    }
}
