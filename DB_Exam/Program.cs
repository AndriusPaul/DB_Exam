using DB_Exam;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Working..");
Console.WriteLine("");
using var dbContext = new Context();

// 1. Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos paskaitos jau egzistuojančios duomenų bazėje).

/*var student1 = new Student("Tomas", "Tomavicius");
var student2 = new Student("Jonas", "Jonaitis");
var lecture1 = new Lecture("Kompiuterine grafika");
var lecture2 = new Lecture("Programavimas");
var lecture3 = new Lecture("Matematika");

dbContext.AddRange(
    new Department
    {
        Name = "Informacines Technologijos",
        Students = new List<Student> { student1, student2 },
        Lectures= new List<Lecture> {lecture1,lecture2,lecture3 }
    }); ;
dbContext.SaveChanges();*/

// 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.

/*var existDepartment = dbContext.Departments.Where(x => x.Id == 1).Include(x=>x.Students).First();
var existDepartment1 = dbContext.Departments.Where(x=>x.Id == 1).Include(x=>x.Lectures).First();

var newStudent = new Student("Andrius", "Andriuskevicius");
existDepartment.Students.Add(newStudent);

var newLecture = new Lecture("Fizika");
existDepartment1.Lectures.Add(newLecture);

dbContext.Departments.Update(existDepartment);
dbContext.Departments.Update(existDepartment1);
dbContext.SaveChanges();*/

//3. Sukurti paskaitą ir ją priskirti prie departamento.

/*var newLecture = new Lecture("Dirbtinis Intelektas");

var departFromDB = dbContext.Departments.Where(x => x.Id == 1).Include(x => x.Lectures).FirstOrDefault();

departFromDB.Lectures.Add(newLecture);
dbContext.Departments.Update(departFromDB);
dbContext.SaveChanges();
*/

//4.Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas.

/*var newDep = dbContext.Departments.Where(x=>x.Name == "Teise").Include(x=>x.Students).FirstOrDefault();
var newDep2 = dbContext.Departments.Where(x => x.Name == "Teise").Include(x => x.Lectures).FirstOrDefault();
//var newStudent = new Student("Petras", "Petraitis");
var lectureFizika = dbContext.Lectures.Where(x => x.Id == 4).FirstOrDefault();
var lectureMath = dbContext.Lectures.Where(x=>x.Id ==3).FirstOrDefault();

//newDep.Students.Add(newStudent);
newDep2.Lectures.Add(lectureFizika);
newDep2.Lectures.Add(lectureMath);

dbContext.Departments.Update(newDep2);

dbContext.SaveChanges();*/


//5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos).

/*var changeStudent = dbContext.Students.Where(x=>x.Id == 1).FirstOrDefault();
changeStudent.DepartmentId = 2;
dbContext.SaveChanges();*/

// 6. Atvaizduoti visus departamento studentus.

var students = dbContext.Students.Where(x => x.DepartmentId == 1);
Console.WriteLine($"Departamento studentai:");
foreach (var student in students)
{
    Console.WriteLine($"{student.Name}, {student.Surname}");
}
// 7. Atvaizduoti visas departamento paskaitas.
Console.WriteLine(" ");
var result = dbContext.Departments.Include(x=>x.Lectures).Where(x => x.Id == 1).FirstOrDefault();

var lectures = result.Lectures;
Console.WriteLine($"Departamento {result.Name} paskaitos:");
foreach (var lecture in lectures)
{
    Console.WriteLine($"{lecture.Name}");
}

// 8. Atvaizduoti visas paskaitas pagal studentą.

Console.WriteLine(" ");
Console.WriteLine("Paskaitos pagal vieno studento ID:");

var studentDepartment = dbContext.Students.Where(x=>x.Id ==4).Select(x => x.DepartmentId).FirstOrDefault();

var res = dbContext.Departments.Include(x => x.Students).Include(x => x.Lectures).Where(x => x.Id == studentDepartment).FirstOrDefault();
var lect = res.Lectures;

foreach (var lecture in lect)
{
    Console.WriteLine(lecture.Name);
}

