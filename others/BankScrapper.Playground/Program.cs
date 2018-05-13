﻿using BankScrapper.BB;
using BankScrapper.Models;
using BankScrapper.Nubank;
using BankScrapper.Utils;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Text;

namespace BankScrapper.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginNubank();
            //LoginBB();
            Console.ReadKey();
        }

        async static void LoginNubank()
        {
            var connectionData = new NubankConnectionData
            {
                CPF = ConfigurationManager.AppSettings["CPF"].Replace("-", string.Empty).Replace(".", string.Empty),
                Password = ConfigurationManager.AppSettings["NubankPassword"]
            };

            Console.WriteLine("Realizando conexão com o Nubank. Por favor, aguarde...");

            using (var provider = new NubankProvider(new NubankApi(), connectionData))
            {
                var result = await provider.GetResultAsync();
                Console.WriteLine("Dados coletados a partir do Nubank:");
                PrintResult(result);
            }
        }

        static void PrintResult(BankScrapeResult result)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(result, settings);

            Console.WriteLine();
            Console.WriteLine(json);
        }

        async static void LoginBB()
        {
            var connectionData = new BancoDoBrasilConnectionData
            {
                Account = ConfigurationManager.AppSettings["ContaBB"],
                Agency = ConfigurationManager.AppSettings["AgenciaBB"],
                ElectronicPassword = ConfigurationManager.AppSettings["SenhaEletronicaBB"]
            };

            Console.WriteLine("Realizando conexão com o Banco do Brasil. Por favor, aguarde...");

            using (var bbProvider = BancoDoBrasilProvider.New(connectionData))
            {
                var result = await bbProvider.GetResultAsync();
                Console.WriteLine("Dados coletados a partir do Banco do Brasil:");
                PrintResult(result);
            }
        }
    }
}