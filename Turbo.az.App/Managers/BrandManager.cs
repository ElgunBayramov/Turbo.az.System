using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az.App;

namespace Turbo.az.Helpers
{
    internal class BrandManager
    {
        Brand[] data = new Brand[0];

        public void Add(Brand entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void BrandRemove(Brand entity)
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
        public bool CheckBrandName(string name)
        {
            name = name.ToLower().Trim();

            for (int i = 0; i < data.Length; i++)
            {
                if (data != null)
                {
                    if (data[i].BrandName.ToLower() == name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void BrandEdit(int value)
        {
            int index = Array.IndexOf(data, new Brand(value));

            if (index == -1)
            {
                Helpers.PrintError("Bu marka tapilmadi");
                return;
            }

            Console.WriteLine("Markanın adını dəyiş: ");
        l1:
            string NewBrand = Helpers.ReadString("Yeni markanı daxil edin: ");
            if (CheckBrandName(NewBrand) == false)
            {
                Helpers.PrintError("Bu ad artıq istifadə olunub");
                goto l1;
            }
            else
            {
                data[index].BrandName = NewBrand;
            }
        }

        public Brand[] GetAll()
        {
            return data;
        }
    }
}
