using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Domain.ValurObjects
{
    public sealed record Email
    {
        public string Value { get; set; }

        private Email(string value) => Value = value;

        public static Email Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                 throw new ArgumentException("Email can not be empty!");

            string normalEmail = input.Trim().ToLowerInvariant();

            try
            {
                _ = new MailAddress(normalEmail);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Email format is not valid!");
            }

            return new (normalEmail);
        }

        public override string ToString() => Value;
    }
}
