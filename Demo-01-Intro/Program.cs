// * VAR *

using Data;
using Data.Models;
using Demo_01_Intro.Extensions;

var test1 = 42; // (shortint?)
var test2 = 3_000_000_000; // int? long?
var test3 = 9_000_000_000;

Console.WriteLine();


// Type anonyme
var person = new { Firstname = "Dipper", Lastname = "Pines" };
Console.WriteLine($"{person.Firstname}");


// * Exemple LinQ *
DataContext dataContext = new DataContext();
List<Student> students = dataContext.Students;
//List<Student> students = new DataContext().Students;

// Obtenir la liste des étudiants qui ont la moyenne (50)

// - Classique
List<Student> result1 = new();
foreach (Student student in students)
{
    if(student.Result >= 50)
    {
        result1.Add(student);
    }
}
Console.WriteLine(string.Join("\n >", result1));

// - LinQ
IEnumerable<Student> result2 = students.Where((student) => { return student.Result >= 50; });
Console.WriteLine(string.Join("\n >", result2));

// - Exemple de lambda
{
    IEnumerable<Student> lambda1 = students.Where((student) => { return student.Result >= 50; });
    IEnumerable<Student> lambda2 = students.Where(student => student.Result >= 50);
    var people = students.Select(student => new { Fullname = $"{student.Firstname} {student.Lastname}", student.Result });
}

// * Les méthodes d'extension *

Student mabel = new Student(6, "Mabel", "Pines", 23);

StudentExtension.SayHello(mabel);
mabel.SayHello(); // graçe au "this Student" dans les paramètres de "SayHello"

// * List Vs IEnumerable *

Console.WriteLine("* List Vs IEnumerable *");

// Opération en mode "Immédiat"
List<string> resultat3 = students.OrderByDescending(s => s.Firstname)
                                    .Select(s => s.SayHello())
                                    .ToList();

// Opération en mode "Différé"
IEnumerable<string> resultat4 = students.OrderByDescending(s => s.Firstname)
                                    .Select(s => s.SayHello());

// Appel des modes
Console.WriteLine("1)");
foreach(string st in resultat3)
{
    Console.WriteLine(st);
}

Console.WriteLine("2)");
students.Add(new Student(7, "Bill", "Cypher", 100));
foreach (string st in resultat4)
{
    Console.WriteLine(st);
}

Console.WriteLine("3)");
foreach (string st in resultat4)
{
    Console.WriteLine(st);
}