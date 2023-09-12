import AW7_Dot

def M(a):
    if a>=0:
        return a
    return -a
class Triangle:
    def __init__(self, dots):
        self.Dots = dots
    def Area(self):
        return M(self.Dots[0].X*(self.Dots[1].Y - self.Dots[2].Y)
            + self.Dots[1].X*(self.Dots[2].Y - self.Dots[0].Y)
            + self.Dots[2].X*(self.Dots[0].Y - self.Dots[1].Y))/2
    def Surroundings(self):
        s = self.Dots[len(self.Dots)-1].Distance(self.Dots[0])
        for i in range(len(self.Dots)-1):
            s += self.Dots[i].Distance(self.Dots[i+1])
        return s
    def __eq__(self, other):
        for i in range(len(self.Dots)):
            if self.Dots[i] != other.Dots[i]:
                return False
        return True
    




        