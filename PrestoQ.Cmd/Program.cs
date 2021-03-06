﻿using System;
using System.IO;
using PrestoQ.ProductParser;

namespace PrestoQ.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText(args[0]); 
            var parser = new Parser();
            var products =  parser.GetProducts(data);
            var service = new ProductService();
            products.ForEach(p => service.Save(p)); 

        }
    }
}