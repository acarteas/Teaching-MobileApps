using System.Text;
using System;
namespace Core
{
    public static class ExpressionScrambler
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "";
            else
                raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var c in raw)
            {
                if (" -0123456789".Contains(c))
                {
                    newNumber.Append(c);
                }
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                }
                // otherwise we've skipped a non-numeric char
            }
            return newNumber.ToString();
        }
        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }
        static string TranslateToNumber(char c)
        {
            if ("A".Contains(c))
                return "2";
            else if ("B".Contains(c))
                return "3";
            else if ("C".Contains(c))
                return "4";
            else if ("D".Contains(c))
                return "5";
            else if ("E".Contains(c))
                return "6";
            else if ("F".Contains(c))
                return "7";
            else if ("G".Contains(c))
                return "8";
            else if ("H".Contains(c))
                return "9";
            else if ("I".Contains(c))
                return "10!";
            else if ("J".Contains(c))
                return "11!";
            else if ("K".Contains(c))
                return "12!";
            else if ("L".Contains(c))
                return "13!";
            else if ("M".Contains(c))
                return "14!";
            else if ("N".Contains(c))
                return "15!";
            else if ("O".Contains(c))
                return "16!";
            else if ("P".Contains(c))
                return "17!";
            else if ("Q".Contains(c))
                return "18!";
            else if ("R".Contains(c))
                return "19!";
            else if ("S".Contains(c))
                return "20!";
            else if ("T".Contains(c))
                return "21!";
            else if ("U".Contains(c))
                return "22!";
            else if ("V".Contains(c))
                return "23!";
            else if ("W".Contains(c))
                return "24!";
            else if ("X".Contains(c))
                return "25!";
            else if ("Y".Contains(c))
                return "26!";
            else if ("Z".Contains(c))
                return "27!";
            return null;
        }

        public static string ToAlpha(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "";
            else
                raw = raw.ToUpperInvariant();

            var newExpr = new StringBuilder();
            foreach (var c in raw)
            {
                if (" abcdefghijklmnopqrstuvwxyz".Contains(c))
                {
                    newExpr.Append(c);
                }
                else
                {
                    var result = TranslateToAlpha(c);
                    if (result != null)
                        newExpr.Append(result);
                }
            }
            return newExpr.ToString();
        }

        static string TranslateToAlpha(char c)
        {
            if ("0123".Contains(c))
                return "a";
            else if ("456".Contains(c))
                return "k";
            else if ("789".Contains(c))
                return "z";
            return null;
       

        }
    }
}
