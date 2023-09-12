def MaximumValue(*a):
    max = a[0]
    for i in a:
        if i > max:
            max = i
    return max
def CommonIntegerElements(a,b):
    list = []
    for i in a:
        for j in b:
            if i == j:
                list.append(i)
                break
    return sorted(list)
def CommonStringElements(a,b):
    str = []
    for i in a:
        for j in b:
            if i == j:
                str.append(i)
                break
    return sorted(str)
def CommonElements(a,b):
    list = []
    for i in a:
        for j in b:
            if i == j:
                list.append(i)
                break
    return list
