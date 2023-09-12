
class Student:
    Grades = []
    Weights = []
    def __init__(self,G,W):
        for i in range(len(G)):
            self.Grades.append(G[i])
            self.Weights.append(W[i])

    def GetAvg(self):
        sum = 0
        w = 0
        for i in range(len(self.Grades)):
        
            sum+=self.Grades[i]*self.Weights[i]
            w+=self.Weights[i]
        
        return sum/w

if __name__ == "__main__":
    Grades = [15,18,17,20,16,14]
    Weights = [2,3,3,1,2,1]
    s = Student(Grades,Weights)
    print(s.GetAvg())