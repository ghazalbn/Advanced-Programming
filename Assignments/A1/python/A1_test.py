import A1

def test_MaximumValue():
    assert A1.MaximumValue(2, 5, 3, 8, 1, 21, 34, 6, 0) == 34
    
def test_CommonIntegerElements():
    nums1=[1, 54, 125, 23, 644, 31, 5, 61]
    nums2=[125, 23, 2, 3, 1001, 22, 5, 234, 31, 94]
    assert A1.CommonIntegerElements(nums1,nums2) == [5, 23, 31, 125]

def test_CommonStringElements():
    str1=["Hello", "All", "Python", "Ap"]
    str2=["Ap", "Programming", "First", "Language", "Microsoft", "All" , "Python" ]
    assert A1.CommonStringElements(str1,str2) == ["All", "Ap","Python"]

def test_CommonElements():
    nums1=[1, 54, 125, 23, 644, 31, 5, 61]
    nums2=[125, 23, 2, 3, 1001, 22, 5, 234, 31, 94]
    assert A1.CommonElements(nums1,nums2) == [ 125, 23, 31, 5 ]

    str1=["Hello", "All", "Python", "Ap"]
    str2=["Ap", "Programming", "First", "Language", "Microsoft", "All" , "Python" ]
    assert A1.CommonElements(str1,str2) == ["All", "Python","Ap"]


if __name__ == "__main__":
    test_MaximumValue()
    test_CommonIntegerElements()
    test_CommonStringElements()
    test_CommonElements()
    