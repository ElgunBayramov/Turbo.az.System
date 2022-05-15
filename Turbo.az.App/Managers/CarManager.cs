using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az.App;

namespace Turbo.az.Helpers
{
    internal class CarManager
    {
        Car[] data = new Car[0];

        public void Add(Car entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void CarRemove(Car entity)
        {
            int index = Array.IndexOf(data, entity);

            if (index == -1)
            {
                return;
            }

            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
            {
                Array.Resize(ref data, data.Length - 1);
            }

        }

        public void CarEditModelId(int value, int newmodelid)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    Console.WriteLine("Modelin yeni kodunu daxil edin: ");
                    data[i].ModelId1 = newmodelid;
                    break;
                }
            }
        }

        public void CarEditYear(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    DateTime NewYear = Helpers.ReadDate("Yeni ili daxil edin: ");
                    data[i].Year = NewYear;
                    break;
                }
            }
        }

        public void CarEditPrice(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    double NewPrice = Helpers.ReadDouble("Yeni qiyməti daxil edin: ");
                    data[i].Price = NewPrice;
                    break;
                }
            }
        }

        public void CarEditColor(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    string NewColor = Helpers.ReadString("Yeni rəngi daxil edin: ");
                    data[i].Color = data[i].Color.Replace(data[i].Color, NewColor);
                    break;
                }
            }
        }

        public void CarEditEngine(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    double NewEngine = Helpers.ReadDouble("Yeni mühərriki daxil edin: ");
                    data[i].Engine = NewEngine;
                    break;
                }
            }
        }

        public void CarEditFuelType(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    FuelType menuNum4 = Helpers.FuelType("Yanacağın növünü seçin: ");

                    switch (menuNum4)
                    {
                        case FuelType.Gasoline:
                            data[i].FuelType = nameof(FuelType.Gasoline);
                            break;
                        case FuelType.Diesel:
                            data[i].FuelType = nameof(FuelType.Diesel);
                            break;
                        case FuelType.Hybrid:
                            data[i].FuelType = nameof(FuelType.Hybrid);
                            break;
                        case FuelType.Gas:
                            data[i].FuelType = nameof(FuelType.Gas);
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        public Car[] GetAll()
        {
            return data;
        }
    }
}
