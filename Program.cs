// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext())
{

    //Student -> Teacher
    var student = new Student { Name = "Emre" };
    student.Teachers.Add(new Teacher { Name = "Fatih" });
    student.Teachers.Add(new Teacher { Name = "Mehmet" });
    _context.Students.Add(student);

    //Teacher -> Student
    var teacher = new Teacher
    {
        Name = "Veli",
        Students = new List<Student>{
        new Student(){Name = "Ali"}
    }};
    _context.Teachers.Add(teacher);

    // Add strudent to existing teacher
    var existingTeacher = _context.Teachers.First(i => i.Name == "Mehmet");

    existingTeacher.Students.Add(new Student { Name = "Rıza" });

    _context.SaveChanges();


}



