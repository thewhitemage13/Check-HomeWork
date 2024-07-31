using System.Collections;

namespace Check_Home_Work
{

    struct Product
    {
        private string goodsName;
        private double price;

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public string GetGoodsName()
        {
            return goodsName;
        }

        public void SetGoodsName(string goodsName)
        {
            this.goodsName = goodsName;
        }
    }

    struct Shop
    {
        private string name;
        private string address;
        private int index;

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }

    struct Check
    {
        private Product product;
        private Shop shop;
        private double clientMoney;
        private int mwst;
        private double wm;
        private double netto;
        private double surrenders;
        private int tseNummer;
        private DateTime dataTime;

        public void SetShop(Shop shop)
        {
            this.shop = shop;
        }

        public void SetProduct (Product product)
        { 
            this.product = product; 
        }

        public Shop GetShop()
        {
            return shop;
        }

        public Product GetProduct()
        {
            return product;
        }

        public DateTime GetDataTime()
        {
            return dataTime;
        }

        public void SetDataTime(DateTime dataTime)
        {
            this.dataTime = dataTime;
        }

        public int GetTseNummer()
        {
            return tseNummer;
        }

        public void SetTseNummer(int tseNummer)
        {
            this.tseNummer = tseNummer;
        }

        public double GetSurrenders()
        {
            return surrenders;
        }

        public void SetSurrenders(double surrenders)
        {
            this.surrenders = surrenders;
        }

        public double GetNetto()
        {
            return netto;
        }

        public void SetNetto(double netto)
        {
            this.netto = netto;
        }

        public double GetWM()
        {
            return wm;
        }

        public void SetWM(double wm)
        {
            this.wm = wm;
        }

        public int GetMWST()
        {
            return mwst;
        }

        public void SetMWST(int mwst)
        {
            this.mwst = mwst;
        }

        public double GetMyMoney()
        {
            return clientMoney;
        }

        public void SetMyMoney(double clientMoney)
        {
            this.clientMoney = clientMoney;
        }

    }

    struct ConsoleInputInformtion
    {
        private bool operation;

        public void Input(ref Check check)
        {
            Product product = new Product();
            Shop shop = new Shop();

            operation = true;
            while (operation)
            {
                try
                {
                    Console.Write("Enter shop name: ");
                    String shopName = Console.ReadLine();
                    shop.SetName(shopName);
                    
                    Console.Write("Enter adress: ");
                    String adress = Console.ReadLine();
                    shop.SetAddress(adress);

                    Console.Write("Enter idex: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    shop.SetIndex(index);

                    check.SetShop(shop);

                    check.SetDataTime(DateTime.Now);

                    Console.Write("Enter product name: ");
                    String goodsName = Console.ReadLine();
                    product.SetGoodsName(goodsName);

                    Console.Write("Enter price: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    product.SetPrice(price);

                    check.SetProduct(product);

                    Console.Write("Enter your client: ");
                    double myMoney = Convert.ToDouble(Console.ReadLine());
                    check.SetMyMoney(myMoney);

                    Console.Write("Enter Transaction number: ");
                    int tseNummer = Convert.ToInt32(Console.ReadLine());
                    check.SetTseNummer(tseNummer);

                    Console.Write("Enter MWST in %: ");
                    int mwst = Convert.ToInt32(Console.ReadLine());
                    check.SetMWST(mwst);

                    operation = false;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    struct CalculateCheck
    {
        public void Calculate(ref Check check)
        {
            check.SetWM((int)(check.GetProduct().GetPrice() / 100 * check.GetMWST()));

            check.SetNetto(check.GetProduct().GetPrice() - check.GetWM());

            check.SetSurrenders(check.GetProduct().GetPrice() - check.GetMyMoney());
        }
    }

    struct ConsolePrinter
    {
        public void Print(ref Check check)
        {
            Console.WriteLine();
            Console.WriteLine(check.GetShop().GetName());
            Console.WriteLine(check.GetShop().GetAddress());
            Console.WriteLine(check.GetShop().GetIndex());
            Console.WriteLine(check.GetProduct().GetGoodsName());

            Console.WriteLine(String.Format("{0:F2 $ \n\t}", check.GetProduct().GetPrice()));

            Console.WriteLine("-------------------------------------\n\t");

            Console.WriteLine(String.Format("Price:          {0:F2} $ \n\t", check.GetProduct().GetPrice()));
            Console.WriteLine(String.Format("Your moeny:     {0:F2} $ \n\t", check.GetMyMoney()));
            Console.WriteLine(String.Format("Surrenders:    {0:F2} $ \n\t", check.GetSurrenders()));

            Console.WriteLine("-------------------------------------\n\t");

            Console.WriteLine("MWST%   MWST   +   NETTO   =   BRUTTO\n\t");

            Console.Write(check.GetMWST() + "%");

            Console.Write(String.Format("     {0:F2} $", check.GetWM()));

            Console.Write(String.Format("   {0:F2} $", check.GetNetto()));

            Console.Write(String.Format("      {0:F2} $\n", check.GetProduct().GetPrice()));

            Console.Write("Summ:");

            Console.Write(String.Format("   {0:F2} $", check.GetWM()));

            Console.Write(String.Format("   {0:F2} $", check.GetNetto()));

            Console.Write(String.Format("      {0:F2} $\n", check.GetProduct().GetPrice()));

            Console.Write("-------------------------------------\n");

            Console.Write("TSE: " + check.GetTseNummer() + "\n");

            Console.Write("-------------------------------------\n");

            Console.WriteLine(check.GetDataTime());
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Check check = new Check();
            ConsoleInputInformtion input = new ConsoleInputInformtion();
            CalculateCheck calculateCheck = new CalculateCheck();
            ConsolePrinter consolePrinter = new ConsolePrinter();

            input.Input(ref check);
            calculateCheck.Calculate(ref check);
            consolePrinter.Print(ref check);
        }
    }
}
