using System;
using UnityEngine;

namespace Develop.Runtime.Extensions
{
    public static class StringExtensions
    {
        public static string AddColor(this string self, string color, bool runtime = false)
        {
            return runtime || Application.isEditor ? $"<color={color}>{self}</color>" : self;
        }
        
        // ReSharper disable once UnusedMember.Global
        public static string AddItalic(this string self, bool runtime = false)
        {
            return runtime || Application.isEditor ? $"<i>{self}</i>" : self;
        }
        
        public static string AddContext<T>(this string self, T context)
            where T : class
        {
            return self.AddContext(context.GetType().Name);
        }
        
        public static bool IsGuid(this string self)
        {
            return Guid.TryParse(self, out _);
        }
        
        public static string AddContext(this string self, string context)
        {
            return $"{context.AddBold()}: {self}";
        }
        
        private static string AddBold(this string self, bool runtime = false)
        {
            return runtime || Application.isEditor ? $"<b>{self}</b>" : self;
        }
    }
}