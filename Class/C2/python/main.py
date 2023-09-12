import math
class Circle:
    center_x = 0
    center_y = 0
    radius = 0
    def __init__(self,x,y,r):
        self.center_x = x
        self.center_y = y
        self.radius = r

    def circumference(self):
        return 2*math.pi*self.radius
    def area(self):
        return (self.radius**2)*math.pi
    def distance_from_center(self,c):
        return math.pow((c.CenterX-self.CenterX)**2+(c.CenterY-self.CenterY)**2,0.5)

    