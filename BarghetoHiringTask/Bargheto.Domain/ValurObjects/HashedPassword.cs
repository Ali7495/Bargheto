using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Domain.ValurObjects
{
    public sealed record HashedPassword
    {
        public string Value { get; set; }

        public HashedPassword(string value) => Value = value;

        public static HashedPassword CheckHashed(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new ArgumentException("Hashed password is required!");

            if (hash.Length > 200)
                throw new ArgumentException("The hashed password is too long!");

            return new (hash);
        }

        public override string ToString() => Value;
    }
}
