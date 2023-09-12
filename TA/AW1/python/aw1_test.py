import e0

def test_solve_test():
    assert e0.solve("R") ==  0
    assert e0.solve("L") ==  0
    assert e0.solve("LR") ==  0
    assert e0.solve("RL") ==  1
    assert e0.solve("RLLLL") ==  4
    assert e0.solve("RRRRR") ==  0
    assert e0.solve("LLLLL") ==  0
    assert e0.solve("RLRRL") ==  3
    assert e0.solve("LRLRLLLLLRLRLLLL")  == 11
    assert e0.solve("RLLLR") ==  3

if __name__ == "__main__":
    test_solve_test()