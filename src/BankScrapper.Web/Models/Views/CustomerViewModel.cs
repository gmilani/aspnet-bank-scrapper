﻿using BankScrapper.Enums;
using BankScrapper.ValueObjects;
using System;
using System.Collections.Generic;

namespace BankScrapper.Web.Models.Views
{
    public class CustomerViewModel
    {
        public Address Address { get; set; }

        public Address BillingAddress { get; set; }

        public string Cpf { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public Dictionary<string, string> ExtraInformation { get; set; }
    }
}