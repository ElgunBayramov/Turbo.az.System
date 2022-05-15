using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az.App;

namespace Turbo.az.Helpers
{
    internal class ModelManager
    {
            Model[] data = new Model[0];

        public void Add(Model entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void ModelRemove(Model entity)
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

        public bool CheckModelName(string name)
        {
            name = name.ToLower().Trim();

            for (int i = 0; i < data.Length; i++)
            {
                if (data != null)
                {
                    if (data[i].ModelName.ToLower() == name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void ModelEditBrandId(int value, int newBrand)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ModelId == value)
                {
                    Console.WriteLine("Modelin markasını dəyiş: ");
                    data[i].BrandId1 = newBrand;
                    break;
                }
            }
        }

        public void ModelEditName(int value)
        {
            int index = Array.IndexOf(data, new Model(value));

            if (index == -1)
            {
                Helpers.PrintError("Bu marka tapilmadi");
                return;
            }

            Console.WriteLine("Markanın adını dəyiş: ");
        l1:
            string NewModel = Helpers.ReadString("Yeni markanı daxil edin: ");
            if (CheckModelName(NewModel) == false)
            {
                Helpers.PrintError("Bu ad artıq istifadə olunub");
                goto l1;
            }
            else
            {
                data[index].ModelName = NewModel;
            }
        }


        public Model[] GetAll()
        {
            return data;
        }
            
    }
}
