using System;
using System.Collections.Generic;

public class Task
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CompletionPercentage { get; set; }
    public string Description { get; set; }

    public void SetStartDate()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Nhập ngày bắt đầu (dd/MM/yyyy): ");
            string input = Console.ReadLine();
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime startDate))
            {
                if (EndDate == default || startDate <= EndDate)
                {
                    StartDate = startDate;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Lỗi: Ngày bắt đầu phải trước hoặc trùng với ngày kết thúc và phải đúng thứ tự dd/MM/yyyy.");
                }
            }
            else
            {
                Console.WriteLine("Lỗi: Định dạng ngày không hợp lệ.");
            }
        }
    }

    public void SetEndDate()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Nhập ngày kết thúc (dd/MM/yyyy): ");
            string input = Console.ReadLine();
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime endDate))
            {
                if (StartDate == default || endDate >= StartDate)
                {
                    EndDate = endDate;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Lỗi: Ngày kết thúc phải sau hoặc trùng với ngày bắt đầu và phải đúng thứ tự dd/MM/yyyy.");
                }
            }
            else
            {
                Console.WriteLine("Lỗi: Định dạng ngày không hợp lệ.");
            }
        }
    }

    public void SetCompletionPercentage()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Nhập phần trăm hoàn thành (0-100): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int percentage))
            {
                if (percentage >= 0 && percentage <= 100)
                {
                    CompletionPercentage = percentage;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Lỗi: Phần trăm hoàn thành phải nằm trong khoảng từ 0 đến 100.");
                }
            }
            else
            {
                Console.WriteLine("Lỗi: Phần trăm hoàn thành không hợp lệ.");
            }
        }
    }

    public void SetDescription()
    {
        Console.WriteLine("Nhập mô tả công việc:");
        Description = Console.ReadLine();
    }

    public int GetDuration()
    {
        // Số ngày thực hiện task (ngày kết thúc trừ ngày bắt đầu)
        return (EndDate - StartDate).Days;
    }

    public override string ToString()
    {
        int duration = GetDuration();
        return $"{Name} - Mô tả: {Description}, Bắt đầu: {StartDate.ToString("dd/MM/yyyy")}, Kết thúc: {EndDate.ToString("dd/MM/yyyy")}, % Hoàn thành: {CompletionPercentage}%, Thời gian thực hiện: {duration} ngày";
    }
}

public class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool continueProgram = true;
        while (continueProgram)
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Nhập task mới");
            Console.WriteLine("2. Hiển thị danh sách các task");
            Console.WriteLine("3. Thoát chương trình");

            Console.WriteLine("Chọn chức năng (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    DisplayTasks();
                    break;
                case "3":
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Task task = new Task();

        Console.WriteLine("Nhập tên công việc:");
        task.Name = Console.ReadLine();

        task.SetStartDate();
        task.SetEndDate();
        task.SetCompletionPercentage();
        task.SetDescription();

        tasks.Add(task);
        Console.WriteLine("Task đã được thêm thành công!");
        Console.ReadKey();
        Console.Clear();
    }

    static void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Danh sách task trống.");
        }
        else
        {
            Console.WriteLine("Danh sách các task:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
