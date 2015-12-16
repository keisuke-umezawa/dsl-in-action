using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter3scalar {
    public class Account { 
        public enum StatusEnum {
            Open = 0,
            Closed
        }

        public enum TypeEnum {
            Trading = 0,
            Settlement,
            Both
        }
        
        public Account(String number, String firstName)
        {
            number_ = number;
            firstName_ = firstName;
        }

        public Account(String number, String firstName, TypeEnum accountType)
        {
            number_ = number;
            firstName_ = firstName;
            accountType_ = accountType;
        }

        public double calculate(Calculator c)
        {
            interestAccured_ = c.calculate(this);
            return interestAccured_;
        }
        
        public bool isOpen()
        {
            return status_ == StatusEnum.Open;
        }

        public Account addName(String name)
        {
            names_.Add(name);
            return this;
        }
        /// private member and getter
        private String number_;
        public String Number_
        {
            get
            {
                return number_;
            }
        }
        private String firstName_;
        public String FirstName_
        {
            get
            {
                return number_;
            }
        }
        private List<String> names_ = new List<string>();
        public List<String> Names_
        {
            get
            {
                return names_;
            }
        }
        private StatusEnum status_ = StatusEnum.Open;
        public StatusEnum Status_
        {
            get
            {
                return status_;
            }
        }
        private TypeEnum accountType_ = TypeEnum.Trading;
        public TypeEnum AccountType
        {
            get
            {
                return accountType_;
            }
        }
        private double interestAccured_;
        public double InteresstAccured_
        {
            get
            {
                return interestAccured_;
            }
        }
    }

    public interface Calculator {
        double calculate(Account account);
    }
    
    public class CalculatorImpl : Calculator {
        public double calculate(Account account)
        {
            return 1.0;
        }

    }
}
