#include "OrderBuilder.h"
#include "Order.h"

namespace dsl {

    OrderBuilder& OrderBuilder::buy(int quantity, const std::string& security)
    {
        _boughtOrSold = "Bought";
        _quantity = quantity;
        _security = security;
        return *this;
    }
    OrderBuilder& OrderBuilder::sell(int quantity, const std::string& security)
    {
        _boughtOrSold = "Sold";
        _quantity = quantity;
        _security = security;
        return *this;
    }
    OrderBuilder& OrderBuilder::atLimitPrice(int price)
    {
        _limitPrice = price;
        return *this;
    }
    OrderBuilder& OrderBuilder::allOrNone()
    {
        _allOrNone = true;
        return *this;
    }
    OrderBuilder& OrderBuilder::valueAs(const OrderValuer& valuer)
    {
        _value = valuer.valueAs(_quantity, _limitPrice);
        return *this;
    }
    Order OrderBuilder::build() const
    {
        return Order(*this);
    }
}