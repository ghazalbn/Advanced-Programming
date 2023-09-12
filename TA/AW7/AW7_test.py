import AW7_Dot
import AW7_Shape
import AW7_Triangle

def test_DotConstructor():
    dot = AW7_Dot.Dot(1,2)
    assert (dot.X+dot.Y) == 3
    
def test_DotDistance():
    dot1 = AW7_Dot.Dot(1,4)
    dot2 = AW7_Dot.Dot(5,1)

    assert (dot1.Distance(dot2)) == (dot2.Distance(dot1))
    assert (dot1.Distance(dot2)) == 5

def test_TriangleConstructor():
    dot1 = AW7_Dot.Dot(1 , 1)
    dot2 = AW7_Dot.Dot(4 , 1)
    dot3 = AW7_Dot.Dot(1 , 5)
    triangle = AW7_Triangle.Triangle([dot1,dot2,dot3])

    assert (triangle.Surroundings()) == 12
    assert (triangle.Area()) == 6

def test_TriangleEqual():
    dot1_1 = AW7_Dot.Dot(0 , 0)
    dot2_1 = AW7_Dot.Dot(3 , 0)
    dot3_1 = AW7_Dot.Dot(0 , 4)
    triangle = AW7_Triangle.Triangle([dot1_1,dot2_1,dot3_1])

    dot1_2 = AW7_Dot.Dot(0 , 0)
    dot2_2 = AW7_Dot.Dot(3 , 0)
    dot3_2 = AW7_Dot.Dot(0 , 4)
    triangle1 = AW7_Triangle.Triangle([dot1_2,dot2_2,dot3_2])

    assert triangle == triangle1

def test_ShapeConstructor():
    dot1 = AW7_Dot.Dot(0 , 0)
    dot2 = AW7_Dot.Dot(3 , 0)
    dot3 = AW7_Dot.Dot(3 , 4)
    dot4 = AW7_Dot.Dot(0 , 4)
    rectangle = AW7_Shape.Shape([dot1,dot2,dot3,dot4])

    assert rectangle.Surroundings() == 14
    assert rectangle.Area() == 12

def test_ShapeEquality():
    dot1_1 = AW7_Dot.Dot(0 , 0)
    dot2_1 = AW7_Dot.Dot(3 , 0)
    dot3_1 = AW7_Dot.Dot(3 , 4)
    dot4_1 = AW7_Dot.Dot(0 , 4)
    rectangle_1 = AW7_Shape.Shape([dot1_1,dot2_1,dot3_1,dot4_1])

    dot1_2 = AW7_Dot.Dot(0 , 0)
    dot2_2 = AW7_Dot.Dot(3 , 0)
    dot3_2 = AW7_Dot.Dot(3 , 4)
    dot4_2 = AW7_Dot.Dot(0 , 4)
    rectangle_2 = AW7_Shape.Shape([dot1_2,dot2_2,dot3_2,dot4_2])

    assert rectangle_1 == rectangle_2

def test_ShapeAdding():
    dot1_1 = AW7_Dot.Dot(0 , 0)
    dot2_1 = AW7_Dot.Dot(3 , 0)
    dot3_1 = AW7_Dot.Dot(3 , 4)
    dot4_1 = AW7_Dot.Dot(0 , 4)
    rectangle_1 = AW7_Shape.Shape([dot1_1,dot2_1,dot3_1,dot4_1])

    dot1_2 = AW7_Dot.Dot(-3 , 4)
    dot2_2 = AW7_Dot.Dot(0 , 0)
    dot3_2 = AW7_Dot.Dot(0 , 4)
    rectangle_2 = AW7_Shape.Shape([dot1_2,dot2_2,dot3_2])

    rectangle_1 += rectangle_2

    assert rectangle_2.Area() == 6
    assert rectangle_2.Surroundings() == 12

    assert rectangle_1.Area() == 18
    assert rectangle_1.Surroundings() == 18

    