#ifndef DSL_ORDER_BUILDER_H_INCLUDED
#define DSL_ORDER_BUILDER_H_INCLUDED

#include <string>
#include "dsl/Order.h"
#include "dsl/OrderValuer.h"

namespace dsl {
    class Order;

    class OrderBuilder {
    public:
        OrderBuilder& buy(int quantity, const std::string& security);
        OrderBuilder& sell(int quantity, const std::string& security);
        OrderBuilder& atLimitPrice(int price);
        OrderBuilder& allOrNone();
        OrderBuilder& valueAs(const OrderValuer& valuer);
        Order build() const;

        const std::string& security() const { return _security;}
        const int quantity() const { return _quantity;}
        const int limitPrice() const { return _limitPrice;}
        const bool allOrNone() const { return _allOrNone;}
        const int value() const { return _value;}
        const std::string& boughtOrSold() const { return _boughtOrSold;}
    private:
        std::string _security;
        int _quantity;
        int _limitPrice;
        bool _allOrNone;
        int _value;
        std::string _boughtOrSold;
    };
}

#endif // DSL_ORDER_BUILDER_H_INCLUDED
