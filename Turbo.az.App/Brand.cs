using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az.App
{
    internal class Brand : IEquatable<Brand>
    {
        static int counter = 0;
        public Brand(int index)
        {
            this.BrandId = index;
        }
        public Brand()
        {
            this.BrandId = ++counter;
        }
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public bool Equals(Brand other)
        {
            return this.BrandId == other.BrandId;
        }

        public override string ToString()
        {
            return $"{BrandId}. Markanın adı:{BrandName}";
        }
    }
}

