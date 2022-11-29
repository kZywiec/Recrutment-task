using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace WebApp1.Models
{
    public class Campany
    {
        int id;
        int product_id;
        string campaign_name;
        string keywords;
        double bid_amount;
        double campaign_fund;
        bool status;
        string town;
        int radius;

        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public int Product_Id { get; set; }

        [Required]
        public string Campaign_name { get; set; }

        [Required]
        public string Keywords { get; set; }

        [Required]
        [Range(1000,int.MaxValue , ErrorMessage = "Bid can't be less then 1000")]
        public double Bid_amount { get; set; }

        [Required]
        public double Campaign_fund { get; set; }

        [Required]
        public bool Status { get; set; }

        public string Town { get; set; }

        [Required]
        public int Radius{
            get => radius;
            set => radius = value > 0 ? value: 0;
        }

        public Campany() { }
        public Campany(string campaign_name, string keywords, double bid_amount, double campaign_fund, bool status, string town, int radius)
        {
            Campaign_name = campaign_name;
            Keywords = keywords;
            Bid_amount = bid_amount;
            Campaign_fund = campaign_fund;
            Status = status;
            Town = town;
            Radius = radius;
        }

        public string RadiusAsString()
            => Radius+" Km";
    }
}
