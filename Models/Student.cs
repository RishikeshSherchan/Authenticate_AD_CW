namespace Authentication_V2.Models;

public class Student
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string grade { get; set; }
    
    public Student(){}
    
    public Student(int id, string name, string email, string grade)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.grade = grade;
    }   
    
}