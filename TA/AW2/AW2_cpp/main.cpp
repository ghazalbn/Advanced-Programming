#include <vector>
#include <iostream>
using namespace std;

int maximum(vector<int> &a)
{
    int max = a[0];
    for (int i : a)
    {
        if (i > max)
        {
            max = i;
        }
    }
    return max;
}
int main()
{
    vector<int> v;
    v.push_back(1);
    v.push_back(2);
    cout<<maximum(v);
    return 0;
}