using OOP5_prak_3;
using System.Text.Encodings.Web;
using System.Text.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Student> students = new()
{
    new Student { Id = 1, Name = "Олена", AverageGrade = 89.5 },
    new Student { Id = 2, Name = "Андрій", AverageGrade = 94.2 },
    new Student { Id = 3, Name = "Максим", AverageGrade = 78.0 },
    new Student { Id = 4, Name = "Софія", AverageGrade = 96.8 },
    new Student { Id = 5, Name = "Дмитро", AverageGrade = 85.4 }
};

string filePath = "students.json";

var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
string json = JsonSerializer.Serialize(students, options);
File.WriteAllText(filePath, json);
Console.WriteLine("Список студентів збережено у файл students.json.");

string fileContent = File.ReadAllText(filePath);
List<Student> restoredStudents = JsonSerializer.Deserialize<List<Student>>(fileContent);

if (restoredStudents.Count > 0)
{
    var topStudent = restoredStudents.MaxBy(s  => s.AverageGrade);
    Console.WriteLine($"\nСтудент з найвищим середнім балом: {topStudent?.Name} {topStudent?.AverageGrade}");
}
