using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az.App
{
    internal class Model : IEquatable<Model>
    {
        static int counter = 0;
        public Model(int index)
        {
            this.ModelId = index;
        }
        public Model()
        {
            this.ModelId = ++counter;
        }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int BrandId1 { get; set; }

        public bool Equals(Model other)
        {
            return this.ModelId == other.ModelId;
        }

        public override string ToString()
        {
            return $"Modelin kodu: {ModelId} , Modelin adı: {ModelName} , Markanın kodu: {BrandId1}";
        }
    }
}
