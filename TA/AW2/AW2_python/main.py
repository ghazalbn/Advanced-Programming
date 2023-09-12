def maximum(list):
    max = list[0]
    for  i in list:
        if i>max:
            max = i
         
    return max
l = [1,3,7,9,17,64,67]
print(maximum(l))