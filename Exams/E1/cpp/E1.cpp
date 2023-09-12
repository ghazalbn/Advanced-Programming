#include <vector>
#include <iostream>
using namespace std;
class Student
{
private:
    std:: vector <double> Grades;
    std:: vector <int> Weights;
public:
    Student(std::vector<double>G,std::vector<int>W)
    {
        Grades = G;
        Weights = W;
        
    }
    double GetAvg()
    {
        double sum = 0;
        int w = 0;
        for (int i = 0; i < Grades.size(); i++)
        {
            sum+=Grades[i]*Weights[i];
            w+=Weights[i];
        }
       return sum/w; 
    }
};
int main(int argc, char const *argv[])
{
    vector<double>Grades = {16,15.25,17,18};
    vector<int>Weights = {1,2,3,2};
    Student s(Grades,Weights);
    cout<<s.GetAvg();
    return 0;
}
