using System;

namespace Task14._3._3
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Доработайте вашу телефонную книгу из задания 14.2.10 предыдущего юнита так,
            //чтобы контакты телефонной книги были отсортированы сперва по имени, а затем по фамилии.

            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            //сортируем книгу по имени , по фамилии
            phoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).ToList();
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите номер  страницы: ");

                // Читаем введенный с консоли символ
                var input = Console.ReadLine();
                Console.Clear();
               
                if (!Int32.TryParse(input,out int number) || number <1 || number >3)
                {
                    Console.WriteLine("Ошибка.Введите корректное число(1,2,3).");
                    Console.ReadKey();
                    continue;
                }

                var contacts = phoneBook.Skip((number - 1) * 2).Take(2);              
                                  
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact.Name + " " + " " + contact.LastName + " " + contact.PhoneNumber);
                }
                Console.ReadKey();
            }
        }
        public class Contact // модель класса
        {
            public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
    }
}
