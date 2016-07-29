using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Infrastructure.Extensions
{
    public static class Extensions
    {
        public static bool TryFindElement(this IWebElement mainElement, By by, out IWebElement element)
        {
            try
            {
                element = mainElement.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                element = null;
                return false;
            }
            return true;
        }
    }
}
