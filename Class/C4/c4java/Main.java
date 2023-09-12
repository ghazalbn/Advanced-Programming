public class Main {
    public static void main(String[] args) {

        Instructor maleki = new Instructor("Maleki", 134, "PhD");
        Instructor hakami = new Instructor("Hakami", 131, "PhD");
        Instructor etemadi = new Instructor("Etemadi", 130, "PhD");

        Course ap = new Course("AP", 3, maleki, 982);
        Course ds = new Course("DS", 3, etemadi, 981);
        Course dm = new Course("DM", 3, hakami, 982);

        Student ali = new Student("Ali", 98522134);
        Student ghazal = new Student("Ghazal", 98522265);
        Student zahra = new Student("Zahra", 98521132);

        ap.registerStudent(ali);
        ap.registerStudent(zahra);
        ap.registerStudent(ghazal);

        ds.registerStudent(ghazal);
        ds.registerStudent(ali);

        dm.registerStudent(zahra);

        ap.printStudents();
        dm.printStudents();

        ghazal.printCourses();
        zahra.printCourses();

        ap.addStudentGrade(ali, 12);
        ap.addStudentGrade(zahra, 20);
        ap.addStudentGrade(ghazal, 20);
        ds.addStudentGrade(ali, 15);
        ds.addStudentGrade(ghazal, 19);
        dm.addStudentGrade(zahra, 18);

        zahra.printGrades();
        ghazal.printGrades();
        ali.printGrades();
        ap.printGrades();
    }
}