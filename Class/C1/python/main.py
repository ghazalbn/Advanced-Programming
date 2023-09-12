def reverse(list):
    n = len(list)
    for i in range(0,int(n/2)):
        tmp = list[i]
        list[i] = list[n-i-1]
        list[n-i-1] = tmp

def output_reverse(*args):
    output(args)

def output(list):
    for n in list:
        print(n, end='')
        if n != list[len(list)-1]:
            print(",", end ='')
    print()
if __name__ == "__main__":
    mylist = [1,2,3,4,5]
    reverse(mylist)
    output(mylist)

    output_reverse(1,2,3,4,5,6,7,8,9)