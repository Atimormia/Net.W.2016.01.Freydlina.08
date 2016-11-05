using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Customer
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        public Customer(string name = "", string contactPhone = "", decimal revenue = 0)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public override string ToString()
        {
            return ToString("NRP", null);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
                format = "NRP";
            format = format.ToUpper();
            if (provider == null)
                provider = new CultureInfo("en-US");
            switch (format)
            {
                case "N":
                    return string.Format(provider, "{0:N}", Name);
                case "P":
                    return string.Format(provider, "{0:P}", ContactPhone);
                case "R":
                    return string.Format(provider, "{0:N2}", Revenue);
                case "NP":
                    return string.Format(provider, "{0:N}, {1:P}", Name, ContactPhone);
                case "NR":
                    return string.Format(provider, "{0:N}, {1:N2}", Name, Revenue);
                case "PR":
                    return string.Format(provider, "{0:P}, {1:N2}", ContactPhone, Revenue);
                case "NRP":
                    return string.Format(provider, "{0:N}, {1:N2}, {2:P}", Name, Revenue, ContactPhone);
                default:
                    throw new FormatException($"The '{format}' format specifier is not supported.");
            }
        }
    }
}
