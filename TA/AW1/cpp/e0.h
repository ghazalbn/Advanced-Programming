#include<stdlib.h>
#include<string.h>

namespace e0
{
// راه خودم://
int solve(std::__cxx11::string s)
{
    int m = 0;
    while(1){
        int j = 0;
        int d = 0;
        while(j<s.length()-1){
            if (s[j] == 'R' and s[j+1] == 'L'){
                s[j] = 'L';
                s[j+1] = 'R';
                d+=1;
                j++;
            }
            j++;
        }
        if (d == 0){
            break;
        }
        m+=1;
		}
    return m;
}

// راه تی ای

// bool HasRL(char *queue, int size)
// {
//     for (size_t i = 0; i < size; i++)
//         if (queue[i] == 'R' && queue[i + 1] == 'L')
//             return true;
//     return false;
// }

// int solve(const char *queue_orig)
// {
//     int res = 0;
//     int size = strlen(queue_orig);
//     char* queue = (char*) malloc(size + 1);
//     strcpy(queue, queue_orig);

//     while (HasRL(queue, size))
//     {
//         int i = 0;
//         while (i < size)
//         {
//             if (queue[i] == 'R' && queue[i + 1] == 'L')
//             {
//                 queue[i] = 'L';
//                 queue[i + 1] = 'R';
//                 i = i + 1;
//             }
//             i = i + 1;
//         }
//         res = res + 1;
//     }
//     return res;
// }
}