#define CATCH_CONFIG_MAIN
#include"catch.hpp"
#include"A1.cpp"

TEST_CASE("MaximumValueTest", "[A1]") {
    REQUIRE(A1::MaximumValue<int>(2, 5, 3, 8, 1, 21, 34, 6, 0) ==  34);
}

TEST_CASE("CommonIntegerElementsTest", "[A1]") {
    int nums1[] = { 1, 54, 125, 23, 644, 31, 5, 61 }; 
    int nums2[] = { 125, 23, 2, 3, 1001, 22, 5, 234, 31, 94 }; 
    vector<int> num=A1::CommonIntegerElements(nums1,nums2,8,10);
    vector<int> exp{5, 23, 31 ,125};
    REQUIRE( num ==  exp ) ;
}

TEST_CASE("CommonStringElementsTest", "[A1]") {
    string str1[] = {"Hello", "All", "Cpp", "Ap"}; 
    string str2[] = { "Ap", "Programming", "First", "Language", "Microsoft", "All", "Cpp" }; 
    vector<string> res=A1::CommonStringElements(str1,str2,4,7);
    vector<string> exp{"All", "Ap", "Cpp"};
    REQUIRE ( res == exp ) ;
}

TEST_CASE("CommonElementsTest", "[A1]") {
    string str1[] = {"Hello", "All", "Cpp", "Ap"}; 
    string str2[] = { "Ap", "Programming", "First", "Language", "Microsoft", "All", "Cpp" }; 
    vector<string> res=A1::CommonElements(str1,str2,4,7);
    vector<string> exp1{"All", "Cpp", "Ap"};
    REQUIRE ( res == exp1 ) ;

    int nums1[] = { 1, 54, 125, 23, 644, 31, 5, 61 }; 
    int nums2[] = { 125, 23, 2, 3, 1001, 22, 5, 234, 31, 94 }; 
    vector<int> num=A1::CommonElements(nums1,nums2,8,10);
    vector<int> exp2{125, 23, 31, 5};
    REQUIRE( num ==  exp2 ) ;
}



