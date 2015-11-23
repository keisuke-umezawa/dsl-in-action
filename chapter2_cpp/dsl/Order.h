#ifndef DSL_ORDER_H_INCLUDED
#define DSL_ORDER_H_INCLUDED

#include <string>
#include <iostream>

namespace dsl {
    class OrderBuilder;

    class Order {
    public:
        Order(const OrderBuilder& b);
        //! getters
        const std::string& security() const { return _security; }
        const int quantity() const { return _quantity; }
        const int limitPrice() const { return _limitPrice; }
        const bool allOrNone() const { return _allOrNone; }
        const int value() const { return _value; }
        const std::string& boughtOrSold() const { return _boughtOrSold; }

    private:
        const std::string _security;
        const int _quantity;
        const int _limitPrice;
        const bool _allOrNone;
        const int _value;
        const std::string _boughtOrSold;
    };

    std::ostream& operator<<(std::ostream& os, const Order& order);
}

#endif // DSL_ORDER_H_INCLUDED
