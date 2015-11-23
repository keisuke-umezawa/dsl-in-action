#ifndef DSL_ORDERVALUER_H_INCLUDED
#define DSL_ORDERVALUER_H_INCLUDED

#include <string>

namespace dsl {
    class OrderValuer {
    public:
        virtual ~OrderValuer() {}
        virtual int valueAs(int quantity, int unitPrice) const = 0;
    };

    class StandeardOrderValuer : public OrderValuer {
    public:
        ~StandeardOrderValuer() {}
        virtual int valueAs(int quantity, int unitPrice) const
        {
            return unitPrice * quantity;
        }
    };
}

#endif // DSL_ORDERVALUER_H_INCLUDED
