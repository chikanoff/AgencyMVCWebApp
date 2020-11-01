using AgencyMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyMVCWebApp.Data
{
    public static class InitializeDb
    {
        private static Random random = new Random();
        private static string[] insuranceTypes = { "Медицинское страхование", "Страхование от несчастных случаев и болезней", "Страхование имущества граждан", "Страхование финансовых рынков", "Страхование средств наземного транспорта", "Страхование грузов", "Страхование ответственности владельцев автотранспортных средств", "Страхование профессиональной ответственности", "Страхование гражданской ответственности предприятий", "Страхование других видов имущества"};
        private static string[] names = { "Даниил", "Александр", "Алексей", "Кирилл", "Дмитрий", "Олег", "Евгений", "Игорь", "Павел", "Денис", "Николай", "Егор", "Антон", "Максим", "Геннадий", "Святослав", "Сергей", "Кузьма", "Владислав", "Иван" };
        private static string[] surnames = { "Третьяков", "Медведев", "Станченко", "Кищук", "Бутрим", "Михальчук", "Бращук", "Ульяненко", "Черняков", "Серединский", "Вересковский", "Киркоров", "Покровский", "Чуприс", "Магомедов", "Могилевец", "Каврига", "Романко", "Маценко", "Морозов" };
        private static string[] middleNames = { "Николаевич", "Владимирович", "Иванович", "Евгеньевич", "Кириллович", "Андреевич", "Алексеевич", "Дмитриевич", "Васильевич", "Георгиевич", "Даниилович", "Артемьевич", "Артурович", "Олегович", "Максимович", "Романович", "Александрович", "Павлович", "Кузьмич", "Владиславович" };
        private static string[] adresses = {"бульвар Юбилейный", "проспект Машерова", "улица Ленина", "улица Королева", "бульвар Днепровский", "улица Рокоссовского", "улица Горовца", "улица Ванеева", "улица Долгобродская", "улица Козлова", "улица Голодеда", "проспект Мира", "проспект Независимисти", "улица Народного Ополчения", "улица Миронова", "улица Веры Хоружей", "улица Нёманская", "улица Мояковского", "Партизанский проспект", "улица Ангарская"};
        private static string[] residences = { "Могилев", "Минск", "Барановичи", "Гомель", "Полоцк", "Быхов", "Бобруйск", "Москва", "Гомель", "Пермь", "Борисов", "Краснополье", "Сочи", "Речица", "Жлобин", "Орша", "Кобрин", "Кричев", "Варшава", "Волгоград" };
        private static string[] genders = { "Male", "Female" };
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static string[] phoneCodes = { "33", "29", "44", "17", "25" };
        private static string GetRandomElement(string[] arr)
        {
            return arr[random.Next(0, arr.Length)];
        }
        private static DateTime NextDateTime()
        {
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }

        private static string GetString(int minStringLength, int maxStringLength)
        {
            string result = "";

            int stringLimit = minStringLength + random.Next(maxStringLength - minStringLength);

            int stringPosition;
            for (int i = 0; i < stringLimit; i++)
            {
                stringPosition = random.Next(letters.Length);

                result += letters[stringPosition];
            }

            return result;
        }

        public static void Initialize(courseworkDbContext db)
        {
            db.Database.EnsureCreated();

            int rowCount;
            int rowIndex;

            if (!db.TypesOfinsurance.Any())
            {
                rowCount = 500;
                rowIndex = 0;
                while (rowIndex < rowCount)
                {
                    TypeOfinsurance type = new TypeOfinsurance 
                    { 
                        Name = insuranceTypes[random.Next(0, insuranceTypes.Length)], 
                        Description = "desc", Price = new decimal(random.Next(1, 1000)), 
                        Payment = new Decimal(random.Next(1, 1000)) 
                    };

                    db.TypesOfinsurance.Add(type);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Clients.Any())
            {
                rowCount = 500;
                rowIndex = 0;

                while (rowIndex < rowCount)
                {
                    Client client = new Client 
                    { 
                        Name = GetRandomElement(names), 
                        Surname = GetRandomElement(surnames), 
                        MiddleName = GetRandomElement(middleNames), 
                        Gender = genders[0], 
                        Phone = GetRandomElement(phoneCodes) + Convert.ToString(random.Next(1000000, 9999999)), 
                        DateOfBirth = NextDateTime(), 
                        Adress = GetRandomElement(adresses), 
                        SerialNumber = GetString(8, 16), 
                        Residence = GetRandomElement(residences) 
                    };
                    db.Clients.Add(client);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Policies.Any())
            {
                rowCount = 20000;
                rowIndex = 0;

                while (rowIndex < rowCount)
                {
                    int minIndex = db.Clients.Min(c => c.Id);
                    int maxIndex = db.Clients.Max(c => c.Id);
                    Policy policy = new Policy
                    {
                        AgentId = 1,
                        ClientId = random.Next(minIndex, maxIndex+1),
                        RegistredAt = NextDateTime(),
                        Start = NextDateTime(),
                        Finish = NextDateTime()
                    };
                    rowIndex++;
                    db.Policies.Add(policy);
                }

                db.SaveChanges();
            }

        }
    }
}
