﻿using BankScrapper.Utils;

namespace BankScrapper.Nubank
{
    public sealed class NubankConnectionData : IBankConnectionData
    {
        public string CPF { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            if (CPF.IsNullOrEmpty() || Password.IsNullOrEmpty())
                return false;

            if (CPF.Length > 11)
                CPF = CPF.Replace(".", "").Replace("-", "");

            return CPF.Length == 11;
        }
    }
}