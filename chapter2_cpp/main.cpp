#include <iostream>
#include "dsl/Order.h"
#include "dsl/OrderBuilder.h"
#include "dsl/OrderValuer.h"

int main(int argc, char** argv)
{
    const dsl::Order o 
        = dsl::OrderBuilder()
        .buy(100, "IBM")
        .atLimitPrice(300)
        .allOrNone()
        .valueAs(dsl::StandeardOrderValuer())
        .build();
    std::cout << o << std::endl;
    return 0;
}