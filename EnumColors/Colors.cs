using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace EnumColors
{
    internal class Colors
    {
        public enum SevenColors
        {
            [Display(Name = "#FF5B58")]
            R = 6,

            [Display(Name = "#FFAC40")]
            O = 5,

            [Display(Name = "#FFF650")]
            Y = 4,

            [Display(Name = "#8DFF70")]
            G = 3,

            [Display(Name = "#97FFF3")]
            C = 2,

            [Display(Name = "#7F8CFF")]
            B = 1,

            [Display(Name = "#A978FF")]
            P = 0
        }
        public static string GetDisplayName(SevenColors color)
        {
            Type type = color.GetType();
            var enumItem = type.GetField(color.ToString());
            var attribute = enumItem?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name;
        }
    }
}