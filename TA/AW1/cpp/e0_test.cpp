#define CATCH_CONFIG_MAIN
#include"catch.hpp"
#include"e0.h"

TEST_CASE("e0 solve test", "[e0]") {
    REQUIRE(e0::solve("R") ==  0);
    REQUIRE(e0::solve("L") ==  0);
    REQUIRE(e0::solve("LR") ==  0);
    REQUIRE(e0::solve("RL") ==  1);
    REQUIRE(e0::solve("RLLLL") ==  4);
    REQUIRE(e0::solve("RRRRR") ==  0);
    REQUIRE(e0::solve("LLLLL") ==  0);
    REQUIRE(e0::solve("RLRRL") ==  3);
    REQUIRE(e0::solve("LRLRLLLLLRLRLLLL")  == 11);
    REQUIRE(e0::solve("RLLLR") ==  3 );
}