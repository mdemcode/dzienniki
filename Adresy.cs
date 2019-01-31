using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dzienniki
{
    static class Adresy
    {
        private static readonly string adresBazowy;

        static Adresy()
        {
            adresBazowy = "C:\\Program Files\\DziennikiSpawania\\";
        }

        public static string AdresBazyAccess()
        {
            return adresBazowy + "#program#\\_bazaDanych\\bazaDanych.mdb";
        }
    }
}
