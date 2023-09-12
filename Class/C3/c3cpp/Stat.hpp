#include<string>
#include<vector>
#include "Grade.hpp"
using namespace std;
class Stat
{
    vector<Grade>m_vGrades;
public:
    void AddGrade(Grade g)
    {   
        m_vGrades.push_back(g);
    }
    double GetAverage()
    {
        double Sum = 0;
        double credits = 0;
        for (int i = 0; i < m_vGrades.size(); i++)
        {
            Sum+=(m_vGrades[i].m_Value)*(m_vGrades[i].m_Credit);
            credits+=m_vGrades[i].m_Credit;
        }
        return Sum/credits;
    }
};