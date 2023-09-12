# def HasRL(s):
#     for i in range(len(s)-1):
#         if(s[i]=='R' and s[i+1]=='L'):
#             return True
#     return False
def solve(s):
    m=0
    while(('RL' in s) == True):
        s = s.replace('RL','LR')
        # i=0
        # while(i<len(s)-1):
        #     if(s[i]=='R' and s[i+1]=='L'):
        #         s=s[:i]+"LR"+s[i+2:]
        #         i+=1
        #     i+=1
        m+=1
    return m
    