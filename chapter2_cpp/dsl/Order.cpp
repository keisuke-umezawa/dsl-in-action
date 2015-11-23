#include "Order.h"
#include "OrderBuilder.h"

namespace dsl {
    Order::Order(const OrderBuilder& b)
        : _security(b.security()),
        _quantity(b.quantity()),
        _limitPrice(b.limitPrice()),
        _allOrNone(b.allOrNone()),
        _value(b.value()),
        _boughtOrSold(b.boughtOrSold())
    {
    }
    std::ostream& operator<<(std::ostream& os, const Order& order)
    {
        os << "security : " << order.security() << std::endl
            << "quantity : " << order.quantity() << std::endl
            << "limitPrice : " << order.limitPrice() << std::endl
            << "allOrNone : " << order.allOrNone() << std::endl
            << "value : " << order.value() << std::endl;
        return os;
    }
}