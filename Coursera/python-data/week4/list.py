fname = input("Enter file name: ")
fh = open(fname)
lst = list()
for line in fh:
    line = line.split()
    for l in line:
        if l not in lst:
            lst.append(l)
lst.sort()            
print(lst)