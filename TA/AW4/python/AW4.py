with open('text.txt','r') as t, open('odd.txt','w') as o, open('even.txt','w') as e:
    i = 0
    for i,line in enumerate(t):
        if i % 2 == 0:
            e.write(line)
        else:
            o.write(line)