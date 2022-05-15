using System;
using System.Linq;
using Turbo.az.App;
using Turbo.az.Helpers;


namespace Turbo.az.Helpers
{
    internal class program
    {
        static void Main(string[] args)
        {
            Helpers.Init();
            Car[] cars = new Car[0];
            var brandMr = new BrandManager();
            var modelMr = new ModelManager();
            var carMr = new CarManager();
            int len;

        l1:
            Helpers.PrintMenu();
            MenuStates m = Helpers.ReadMenu("Birini seçin: ");
            Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}.{m}");
            switch (m)
            {
                case MenuStates.BrandAdd:
                    Console.Clear();
                CheckBrand:
                    string NameBrand = Helpers.ReadString("Markanın adını daxil edin: ");
                    brandMr.CheckBrandName(NameBrand);
                    if (brandMr.CheckBrandName(NameBrand) == false)
                    {
                        Helpers.PrintError("Bu ad artıq istifadə olunub");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.F1)
                        {
                            goto CheckBrand;
                        }
                        else
                        {
                            goto l1;
                        }
                    }
                    else
                    {
                        Brand b = new Brand();
                        b.BrandName = NameBrand;
                        brandMr.Add(b);
                    }
                    goto case MenuStates.BrandAll;
                case MenuStates.BrandId:
                    int brandid = Helpers.ReadInt("Markanın kodu: ", 0);
                    if (brandid == 0)
                    {
                        goto case MenuStates.BrandAll;
                    }
                    foreach(var item in brandMr.GetAll())
                    {
                        if (item.BrandId == brandid)
                        {
                            Console.Clear();
                            Console.WriteLine($"Tapıldı: {item}");
                            goto l1;
                        }
                    }

                    Helpers.PrintError("Marka tapılmadı");
                    goto case MenuStates.BrandId;
                case MenuStates.BrandEdit:
                edit:
                    Console.Clear();
                    ShowAllBrand(brandMr);

                    int value = Helpers.ReadInt("Markanın kodunu daxil edin: ");

                    var CheckBrandEdit = brandMr.GetAll().FirstOrDefault(x => x.BrandId == value);
                    if (CheckBrandEdit == null)
                    {
                        Helpers.PrintError("Bu kod yanlışdır");

                    click:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.F1)
                        {
                            goto edit;
                        }
                        else if (click.Key == ConsoleKey.F2)
                        {
                            goto l1;
                        }
                        else
                        {
                            goto click;
                        }
                    }

                    brandMr.BrandEdit(value);

                    goto case MenuStates.BrandAll;

                case MenuStates.BrandRemove:
                    Console.Clear();
                    ShowAllBrand(brandMr);
                    int id = Helpers.ReadInt("Silmək istədiyiniz markanın kodunu daxil edin: ");

                    Brand b1 = brandMr.GetAll().FirstOrDefault(item => item.BrandId == id);
                    brandMr.BrandRemove(b1);
                    goto case MenuStates.BrandAll;
                case MenuStates.BrandAll:
                    Console.WriteLine("Markaların siyahısı....");
                    Console.Clear();
                    ShowAllBrand(brandMr);
                    goto l1;
                case MenuStates.ModelAdd:
                    Console.Clear();

                CheckModel:
                    string NameModel = Helpers.ReadString("Modelin adını daxil edin: ");

                    modelMr.CheckModelName(NameModel);
                    if (modelMr.CheckModelName(NameModel) == false)
                    {
                        Helpers.PrintError("Bu ad artıq istifadə olunub");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.F1)
                        {
                            goto CheckModel;
                        }
                        else
                        {
                            goto l1;
                        }
                    }
                    else
                    {
                        Model model = new Model();
                        model.ModelName = NameModel;

                    trymodeladd:
                        ShowAllBrand(brandMr);
                        model.BrandId1 = Helpers.ReadInt("Markanın kodunu daxil edin: ");

                        var CheckModelAdd = brandMr.GetAll().FirstOrDefault(x => x.BrandId == model.BrandId1);
                        if (CheckModelAdd == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        click2:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto trymodeladd;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click2;
                            }
                        }

                        modelMr.Add(model);

                    }
                    goto case MenuStates.ModelAll;
                case MenuStates.ModelId:
                    int modelid = Helpers.ReadInt("Modelin kodu: ", 0);
                    if (modelid == 0)
                    {
                        goto case MenuStates.ModelAll;
                    }
                    foreach (var item in modelMr.GetAll())
                    {

                        if (item.ModelId == modelid)
                        {
                            Console.Clear();
                            Console.WriteLine($"Tapıldı: {item}");
                            goto l1;
                        }
                    }

                    Helpers.PrintError("Model tapılmadı");
                    goto case MenuStates.ModelId;
                case MenuStates.ModelEdit:
                trymodeledit:
                    Console.Clear();
                    ShowAllModel(modelMr);
                    Console.WriteLine("Modelin adını dəyişmək üçün ==> 1 || Markanın kodunu dəyişmək üçün ==> 2");
                    bool success = int.TryParse(Console.ReadLine(), out int menuNumber);
                    if (success && menuNumber == 1)
                    {
                            int value1 = Helpers.ReadInt("Seçilmiş modelin kodunu daxil edin: ");

                        var CheckModelEdit = modelMr.GetAll().FirstOrDefault(x => x.ModelId == value1);
                        if (CheckModelEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        f1:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto trymodeledit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto f1;
                            }
                        }
                        modelMr.ModelEditName(value1);
                    }
                    else if (success && menuNumber == 2)
                    {
                        int value1 = Helpers.ReadInt("Seçilmiş modelin kodunu daxil edin: ");

                        var CheckModelEdit = modelMr.GetAll().FirstOrDefault(x => x.ModelId == value1);
                        if (CheckModelEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        c1:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün < F1 > klikləyin, menuya qayıtmaq üçün < F2 > klikləyin");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto trymodeledit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto c1;
                            }
                        }

                        ShowAllBrand(brandMr);
                        Console.WriteLine("----------------------------------------------------------");

                        int newBrand = Helpers.ReadInt("Yeni markanı daxil edin: ");

                        var CheckModelEdit1 = brandMr.GetAll().FirstOrDefault(x => x.BrandId == newBrand);
                        if (CheckModelEdit1 == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        d1:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                 
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto d1;
                            }
                        }

                        modelMr.ModelEditBrandId(value1, newBrand);
                    }

                    goto case MenuStates.ModelAll;
                case MenuStates.ModelRemove:
                    Console.Clear();
                    ShowAllModel(modelMr);
                    int id1 = Helpers.ReadInt("Silmək istədiyiniz modelin kodunu daxil edin: ");

                    Model model1 = modelMr.GetAll().FirstOrDefault(item => item.ModelId == id1);
                    modelMr.ModelRemove(model1);
                    goto case MenuStates.ModelAll;
                case MenuStates.ModelAll:
                    Console.WriteLine("Modellərin siyahısı...");
                    Console.Clear();
                    ShowAllModel(modelMr);
                    goto l1;
                case MenuStates.CarsAdd:
                    len = cars.Length;
                    Array.Resize(ref cars, len + 1);
                    cars[len] = new Car();
                    cars[len].Color = Helpers.ReadString("Maşının rəngi: ", true);
                    cars[len].Price = Helpers.ReadDouble("Maşının qiyməti: ", 1000);
                    cars[len].Engine = Helpers.ReadDouble("Maşının motoru: ", 1);
                    cars[len].Year = Helpers.ReadDate("Maşının ili: ");
                    PrintFuelMenu();
                    FuelType menu = Helpers.FuelType("Yanacaq növünü seçin: ");

                    switch (menu)
                    {
                        case FuelType.Gasoline:
                            cars[len].FuelType = nameof(FuelType.Gasoline);
                            break;
                        case FuelType.Diesel:
                            cars[len].FuelType = nameof(FuelType.Diesel);
                            break;
                        case FuelType.Hybrid:
                            cars[len].FuelType = nameof(FuelType.Hybrid);
                            break;
                        case FuelType.Gas:
                            cars[len].FuelType = nameof(FuelType.Gas);
                            break;
                        default:
                            break;
                    }

                trycaradd:
                    ShowAllModel(modelMr);
                    cars[len].ModelId1 = Helpers.ReadInt("Modelin kodunu daxil edin: ");

                    var CheckCarAdd = modelMr.GetAll().FirstOrDefault(x => x.ModelId == cars[len].ModelId1);
                    if (CheckCarAdd == null)
                    {
                        Helpers.PrintError("Bu kod yanlışdır");

                    click6:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.F1)
                        {
                            goto trycaradd;
                        }
                        else if (click.Key == ConsoleKey.F2)
                        {
                            goto l1;
                        }
                        else
                        {
                            goto click6;
                        }
                    }

                    carMr.Add(cars[len]);

                    goto case MenuStates.CarsAll;
                case MenuStates.CarsId:
                    int carid = Helpers.ReadInt("Maşının kodu: ", 0);
                    if (carid == 0)
                    {
                        goto case MenuStates.CarsAll;
                    }
                    foreach (var item in carMr.GetAll())
                    {
                        if (item.CarId == carid)
                        {
                            Console.Clear();
                            Console.WriteLine($"Tapıldı: {item}");
                            goto l1;
                        }
                    }

                    Helpers.PrintError("Maşın tapılmadı");
                    goto case MenuStates.CarsId;
                case MenuStates.CarsEdit:
                TryCarEdit:
                    Console.Clear();
                    ShowAllCar(carMr);
                    Console.WriteLine("Modelin kodunu dəyişmək üçün ==> 1 || ilini dəyişmək ==> 2 || " +
                        "qiymətini dəyişmək üçün ==> 3 || rəngini dəyişmək üçün ==> 4 || " +
                        "mühərriki dəyişmək üçün ==> 5 || yanacaq növünü dəyişmək üçün ==> 6 ");
                    bool success2 = int.TryParse(Console.ReadLine(), out int menuNumber2);
                    if (success2 && menuNumber2 == 1)
                    {
                        int value1 = Helpers.ReadInt("Seçilmiş maşının kodunu daxil edin: ");

                        var CheckCarEdit = carMr.GetAll().FirstOrDefault(x => x.CarId == value1);
                        if (CheckCarEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        click8:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto TryCarEdit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click8;
                            }
                        }

                        ShowAllModel(modelMr);
                        Console.WriteLine("------------------------------------------");

                        int newmodelid = Helpers.ReadInt("Yeni modelin kodunu daxil edin: ");

                        var CheckCarEditNewModel = modelMr.GetAll().FirstOrDefault(x => x.ModelId == newmodelid);
                        if (CheckCarEditNewModel == null)
                        {
                            Helpers.PrintError("It is False Id");

                        click8:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto TryCarEdit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click8;
                            }
                        }

                        carMr.CarEditModelId(value1, newmodelid);
                    }
                    else if (success2 && menuNumber2 == 2)
                    {
                        int value1 = Helpers.ReadInt("Seçilmiş maşının kodunu daxil edin:");

                        var CheckCarEdit = carMr.GetAll().FirstOrDefault(x => x.CarId == value1);
                        if (CheckCarEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        click9:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto TryCarEdit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click9;
                            }
                        }

                        carMr.CarEditYear(value1);
                    }
                    else if (success2 && menuNumber2 == 3)
                    {
                        int value1 = Helpers.ReadInt("Seçilmiş maşının kodunu daxil edin:");

                        var CheckCarEdit = carMr.GetAll().FirstOrDefault(x => x.CarId == value1);
                        if (CheckCarEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        click10:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto TryCarEdit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click10;
                            }
                        }

                        carMr.CarEditPrice(value1);
                    }
                    else if (success2 && menuNumber2 == 4)
                    {
                        int value1 = Helpers.ReadInt("Seçilmiş maşının kodunu daxil edin:");

                        var CheckCarEdit = carMr.GetAll().FirstOrDefault(x => x.CarId == value1);
                        if (CheckCarEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        click11:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto TryCarEdit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click11;
                            }
                        }

                        carMr.CarEditColor(value1);
                    }
                    else if (success2 && menuNumber2 == 5)
                    {
                        int value1 = Helpers.ReadInt("Seçilmiş maşının kodunu daxil edin: ");

                        var CheckCarEdit = carMr.GetAll().FirstOrDefault(x => x.CarId == value1);
                        if (CheckCarEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        click12:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto TryCarEdit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click12;
                            }
                        }

                        carMr.CarEditEngine(value1);
                    }
                    else if (success2 && menuNumber2 == 6)
                    {
                        int value1 = Helpers.ReadInt("Seçilmiş maşının kodunu daxil edin: ");

                        var CheckCarEdit = carMr.GetAll().FirstOrDefault(x => x.CarId == value1);
                        if (CheckCarEdit == null)
                        {
                            Helpers.PrintError("Bu kod yanlışdır");

                        click13:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin ");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.F1)
                            {
                                goto TryCarEdit;
                            }
                            else if (click.Key == ConsoleKey.F2)
                            {
                                goto l1;
                            }
                            else
                            {
                                goto click13;
                            }
                        }

                        Console.Clear();
                        PrintFuelMenu();
                        carMr.CarEditFuelType(value1);
                    }

                    goto case MenuStates.CarsAll;
                case MenuStates.CarsRemove:
                TryCarRemove:
                    Console.Clear();
                    ShowAllCar(carMr);
                    int id2 = Helpers.ReadInt("Silmək istədiyiniz maşının kodunu daxil edin: ");

                    var CheckCarRemove = carMr.GetAll().FirstOrDefault(x => x.CarId == id2);
                    if (CheckCarRemove == null)
                    {
                        Helpers.PrintError("Bu kod yanlışdır");

                    click14:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("yenidən cəhd etmək üçün <F1> klikləyin , menuya qayıtmaq üçün <F2> klikləyin");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.F1)
                        {
                            goto TryCarRemove;
                        }
                        else if (click.Key == ConsoleKey.F2)
                        {
                            goto l1;
                        }
                        else
                        {
                            goto click14;
                        }
                    }

                    Car c1 = carMr.GetAll().FirstOrDefault(item => item.CarId == id2);
                    carMr.CarRemove(c1);
                    goto case MenuStates.CarsAll;
                case MenuStates.CarsAll:
                    Console.Clear();
                    ShowAllCar(carMr);
                    goto l1;
                case MenuStates.All:
                    Console.Clear();
                    ShowAllBrand(brandMr);
                    ShowAllModel(modelMr);
                    ShowAllCar(carMr);

                    goto l1;
                case MenuStates.Exit:
                    Helpers.PrintError("Təsdiq üçün <enter> düyməsini klikləyin.Əks halda menuya qayıdılacaq");
                    if(Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                    goto l1;
                default:
                    break;
            }
            static void ShowAllBrand(BrandManager brandManager)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------MARKALAR---------------");
                foreach (var item in brandManager.GetAll())
                {
                    Console.WriteLine(item);
                }
                Console.ResetColor();
            }
            static void ShowAllModel(ModelManager modelManager)
            {
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine("-------------MODELLƏR----------------");
                foreach (var item in modelManager.GetAll())
                {
                    Console.WriteLine(item);
                }
                Console.ResetColor();
            }
            static void PrintFuelMenu()
            {
                Console.WriteLine(new string('-', Console.WindowWidth));

                foreach (var item in Enum.GetNames(typeof(FuelType)))
                {
                    FuelType m = (FuelType)Enum.Parse(typeof(FuelType), item);

                    Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
                }
                Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
            }
            static void ShowAllCar(CarManager carManager)
            {
                Console.ForegroundColor=ConsoleColor.Blue;
                Console.WriteLine("---------------MAŞINLAR---------------");
                foreach (var item in carManager.GetAll())
                {
                    Console.WriteLine(item);
                }
                Console.ResetColor();
            }
        }
    }
}