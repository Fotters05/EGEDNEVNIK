using System;

class dnevnik
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }

    public dnevnik(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
        IsCompleted = false;
    }

    class Program
    {
        static List<dnevnik> notes = new List<dnevnik>();
        static int selectedDateIndex = 0;
        static int selectedNoteIndex = 0;

        //метод для заполнения заметок
        static void zametki()
        {
            notes.Add(new dnevnik("Заметка 1", "Сходить на пары", new DateTime(2023, 10, 20)));
            notes.Add(new dnevnik("Заметка 2", "Сходить в автошколу", new DateTime(2023, 10, 18)));
            notes.Add(new dnevnik("Заметка 3", "Прогать, прогать", new DateTime(2023, 10, 16)));
            notes.Add(new dnevnik("Заметка 4", "Ужин", new DateTime(2023, 10, 16)));
            notes.Add(new dnevnik("Заметка 5", "Сон <3 ", new DateTime(2023, 10, 16)));
        }

        static void Main(string[] args)
        {
            zametki(); //метод для заполнения заметок

            while (true)
            {
                Console.Clear();
                Menyushka(); //метод для отображения меню

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        sledDATA();
                        break;

                    case ConsoleKey.RightArrow:
                        proshlayaDATA();
                        break;

                    case ConsoleKey.UpArrow:
                        proshlayaZametka();
                        break;

                    case ConsoleKey.DownArrow:
                        sledZametka();
                        break;

                    case ConsoleKey.Enter:
                        prosmotr();
                        break;

                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        //метод для отображения меню
        static void Menyushka()
        {
            Console.WriteLine("Дневник дел\n");

            var currentDate = notes[selectedDateIndex].Date;
            Console.WriteLine($"Дата: {currentDate.ToShortDateString()}\n");

            for (int i = 0; i < notes.Count; i++)
            {
                var note = notes[i];
                Console.Write(i == selectedNoteIndex ? " -> " : "    ");
                Console.WriteLine($"{note.Title}");
            }
        }

        //метод для переключения на следующую дату
        static void sledDATA()
        {
            if (selectedDateIndex < notes.Count - 1)
            {
                selectedDateIndex++;
            }
        }

        //метод для переключения на предыдущую дату
        static void proshlayaDATA()
        {
            if (selectedDateIndex > 0)
            {
                selectedDateIndex--;
            }
        }

        //метод для переключения на следующую заметку
        static void sledZametka()
        {
            if (selectedNoteIndex < notes.Count - 1)
            {
                selectedNoteIndex++;
            }
        }

        //метод для переключения на предыдущую заметку
        static void proshlayaZametka()
        {
            if (selectedNoteIndex > 0)
            {
                selectedNoteIndex--;
            }
        }

        //метод для просмотра заметки
        static void prosmotr()
        {
            var note = notes[selectedNoteIndex];
            Console.Clear();
            Console.WriteLine($"Название: {note.Title}");
            Console.WriteLine($"Описание: {note.Description}");
            Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
            Console.WriteLine("Заметка должна быть выполнена?: Да");
            Console.ReadKey(true);
        }
    }
}