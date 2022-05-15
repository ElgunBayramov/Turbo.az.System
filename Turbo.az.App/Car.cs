using System;
using System.Threading;
using System.Threading.Tasks;

namespace Turbo.az.App
{
    internal class Car
    {
        static int counter = 0;
        public Car()
        {
            this.CarId = ++counter;
        }
        public int CarId { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public string FuelType { get; set; }
        public DateTime Year { get; set; }
        public int ModelId1 { get; set; }
        public override string ToString()
        {
            return $" Modelin kodu:{ModelId1} , Maşının kodu: {CarId} , İli: {Year:yyyy} , Qiyməti: {Price}$ ,\n Rəngi: {Color} , Mühərriki: {Engine}  , Yanacaq növü: {FuelType}";

        }
    }
}
