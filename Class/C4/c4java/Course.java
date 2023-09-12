import java.util.ArrayList;

public class Course {
    public String Name;
    public int Credits;
    public Instructor Instructor;
    public int Semester;
    public ArrayList<Student> Students;
    public Course(String name,int credits, Instructor instructor , int semester) {
        this.Name = name;
        this.Credits = credits;
        this.Instructor = instructor;
        this.Semester = semester;
        this.Students = new ArrayList<Student>();
    }
    public void registerStudent(Student s){
        s.addCourse(this);
        Students.add(s);
    }
    public void addStudentGrade(Student s, int value){
        s.addGrade(new Grade(value,this,this.Semester));
    }
    public void printStudents(){
        System.out.println("Students for course " + this.Name + ": ");
        System.out.println();
        for(Student s : this.Students)
        System.out.println(s.getInfo());
        System.out.println("***************************");
        System.out.println();
    }
    public void printGrades(){
        System.out.println("Grades for course " + this.Name + ": ");
        System.out.println();
        for(Student s : this.Students){
        System.out.print(s.getInfo());
        System.out.print(": ");
        for (Grade g : s.Grades) {
            if(g.Course == this){
            System.out.print(g.Value);
            System.out.print(' ');
            }
        }
        System.out.println();
        }
        System.out.println("***************************");
        System.out.println();
    }
	public String getInfo() {
		return this.Name + " -> " + "Dr " + this.Instructor.Name;
	}
}