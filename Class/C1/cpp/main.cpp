#include <vector>
#include <iostream>
using namespace std;


template<typename _Type> void Reverse(vector<_Type>& v)
{
    for(int j = 0;j< v.size()/2;j++)
        {
            _Type tmp = v[j];
            v[j] = v[v.size()-j-1];
            v[v.size()-j-1] = tmp;
        }
               
}

template<typename _T,typename... _Type>
void OutputReverse(_Type ... args)
{
    vector<_T> vlist = {args ...};
    Reverse(vlist);
    for(int i = 0; i < vlist.size();i++)
    {
        cout<<vlist[i];
        if(i != vlist.size()-1) cout<<',';
    }
    // (std::cout << ... << args)<< std::endl;
}


int main(int argc, char const *argv[])
{
    OutputReverse<int>(1,2,3,4,5,6);
    return 0;
}
