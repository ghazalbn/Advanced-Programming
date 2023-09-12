#define CATCH_CONFIG_MAIN
#include<string>
#include"catch.hpp"
#include"e7cpp.h"


TEST_CASE("Q0: Save Int Variable With Pointer", "[e7cpp]") {
    int n = 5;
    if (5 == n)
    {
        SaveVariablePtr save_n(&n); 
        for (int i=0; i<10; i++)
            n++;
        REQUIRE(n == 15);
    }
    REQUIRE(n == 5);
}

TEST_CASE("Q1: Save Template Variable With Pointer", "[e7cpp]") {
    std::string s = "abc";
    int n = 5;
    if (s == "abc" && n == 5)
    {
        SaveVariablePtr save_s(&s);
        SaveVariablePtr save_n(&n);
        s = "def";
        n = 15;
        REQUIRE(s == "def");
        REQUIRE(n == 15);
    }
    REQUIRE(s == "abc");
    REQUIRE(n == 5);
}


TEST_CASE("Q2: Save Int Variable With Reference", "[e7cpp]") {
    int n = 5;
    if (5 == n)
    {
        SaveVariableRef save_n(n); 
        for (int i=0; i<10; i++)
            n++;
        REQUIRE(n == 15);
    }
    REQUIRE(n == 5);
}

TEST_CASE("Q3: Save Template Variable With Reference", "[e7cpp]") {
    std::string s = "abc";
    int n = 5;
    if (s == "abc" && n == 5)
    {
        SaveVariableRef save_s(s);
        SaveVariableRef save_n(n);
        s = "def";
        n = 15;
        REQUIRE(s == "def");
        REQUIRE(n == 15);
    }
    REQUIRE(s == "abc");
    REQUIRE(n == 5);
}