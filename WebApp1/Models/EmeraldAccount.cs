namespace WebApp1.Models
{
    public class EmeraldAccount
    {
        static uint account_number;
        double ballance;
        
        public static uint AccountNumber { 
            get => account_number; 
            set => account_number = value;
        }
        public double Ballance { 
            get => ballance; 
            set => ballance += value;
        }
    }
}
