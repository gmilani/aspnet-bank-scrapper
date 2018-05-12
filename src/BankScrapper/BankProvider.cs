﻿using BankScrapper.Utils;
using System;
using System.Threading.Tasks;

namespace BankScrapper
{
    public abstract class BankProvider : IBankProvider
    {
        public BankProvider(Bank bank, IBankConnectionData connectionData)
        {
            if (bank == Bank.Unknown)
                throw new ArgumentException("Não é possível criar um provedor de um banco desconhecido", nameof(bank));

            if (connectionData?.IsValid() != true)
                throw new Exception($"Os dados de conexão do {bank.GetDescription()} são inválidos");

            Bank = bank;
            ConnectionData = connectionData ?? throw new ArgumentNullException(nameof(connectionData));
        }

        public Bank Bank { get; }

        public IBankConnectionData ConnectionData { get; }

        public abstract void Dispose();
        public abstract Task<BankScrapeResult> GetResultAsync();
    }
}