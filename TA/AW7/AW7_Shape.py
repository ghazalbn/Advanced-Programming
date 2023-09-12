import AW7_Dot
import AW7_Triangle

class Shape:
    def __init__(self, dots):
        self.Dots = dots
    def Area(self):
        s = 0
        for i in range(1,len(self.Dots)-1):
            s += AW7_Triangle.Triangle([self.Dots[0],self.Dots[i],self.Dots[i+1]]).Area()
        return s
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
    def __iadd__(self, other):
        for dt in other.Dots:
            if dt not in self.Dots:
                self.Dots.append(dt)
        return self