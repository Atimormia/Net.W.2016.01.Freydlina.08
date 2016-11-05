using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class CustomFormatter: IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType != null && (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!Equals(formatProvider))
                return null;

            if (string.IsNullOrEmpty(format))
                    format = "N";

            string argString = arg.ToString();
            
            format = format.ToUpper();
            switch (format)
            {
                case "P":
                    argString = argString.Replace(" ", "");
                    argString = argString.Replace("-", "");
                    argString = argString.Replace("(", "");
                    argString = argString.Replace(")", "");
                    return argString.Substring(0, 2) + " (" + argString.Substring(2, 3) + ") " + argString.Substring(5, 3) + " " + argString.Substring(8, 2) + " " + argString.Substring(10, 2);
                case "N":
                    return argString.ToUpper();
                case "N2":
                    return string.Format(CultureInfo.CurrentCulture, "{0:F2}", arg);
                default:
                    throw new FormatException($"The '{format}' format specifier is not supported.");
            }
        }
    }
}
