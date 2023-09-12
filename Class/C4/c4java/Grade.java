public class Grade {
    public int Value;
    public Course Course;
    public int semester;
    public Grade(int value, Course course, int semester) {
        this.Value = value;
        this.Course = course;
        this.semester = semester;
    }
}