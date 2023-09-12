import java.util.ArrayList;

public class Student {
    public String Name;
    public int Id;
    public ArrayList<Course> Courses;
    public ArrayList<Grade> Grades;
    public Student(String name, int id) {
        this.Name = name;
        this.Id = id;
        this.Courses = new ArrayList<Course>();
        this.Grades = new ArrayList<Grade>();
    }
    public String getInfo(){
        return this.Name + ' ' + this.Id;
    }
    public void addCourse(Course c){
        this.Courses.add(c);
    }
    public void addGrade(Grade g){
        this.Grades.add(g);
    }
    public void printCourses(){
        System.out.println("Courses for student " + this.Name + ": ");
        System.out.println();
        for(Course c : this.Courses)
        System.out.println(c.getInfo());
        System.out.println("***************************");
        System.out.println();
    }
    public void printGrades(){
        System.out.println("Grades for student " + this.Name + ": ");
        System.out.println();
        for(Grade g : this.Grades){
        System.out.print(g.Course.Name);
        System.out.print(": ");
        System.out.println(g.Value);
    }
    System.out.println("***************************");
    System.out.println();
    }
}