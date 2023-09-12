class Dot:
    def __init__(self, x, y):
        self.X = x
        self.Y = y
    def Distance(self, other):
        return ((self.X-other.X)**2 + (self.Y-other.Y)**2)**0.5
    def __ne__(self, other):
        return self.X != other.X or self.Y != other.Y
    def __eq__(self, other):
        return self.X == other.X and self.Y == other.Y


