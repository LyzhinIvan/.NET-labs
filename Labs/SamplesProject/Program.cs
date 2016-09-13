using System;
using Lab01;
using Lab02;

namespace SamplesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IPriceList<HakkapeliittaTire> hakPriceList = new PriceList<HakkapeliittaTire>();
            IPriceList<Tire> tirePriceList = hakPriceList; // covarience

            Action<IPriceList<HakkapeliittaTire>> hakPrint = Print; // contravarience
            hakPrint(hakPriceList);
        }

        static void Print(IPriceList<Tire> priceList)
        {
            
        }
    }
}
