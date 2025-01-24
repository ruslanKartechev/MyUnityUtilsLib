using UnityEngine;

namespace SleepDev
{
    public static class MoneyConverter
    {
        public static void SetDecimalOperatorToDot()
        {
            System.Globalization.CultureInfo customCulture = 
                (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
        
        public static string ConvertToString(float amount)
        {
            return amount switch
            {
                >= 1000000000f => $"{amount / 1000000000f:N1}B",
                >= 1000000f when amount % 1000000f == 0 => $"{(int)(amount / 1000000)}M",
                >= 1000000f => $"{amount / 1000000f:N1}M",
                >= 1000f when amount % 1000f == 0 => $"{(int)(amount / 1000)}K",
                >= 1000f => $"{amount / 1000f:N1}K",
                _ => $"{Mathf.RoundToInt(amount)}"
            };
        }
        
    }
}