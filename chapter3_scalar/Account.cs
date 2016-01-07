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
            _number = number;
            _firstName = firstName;
        }

        public Account(String number, String firstName, TypeEnum accountType)
        {
            _number = number;
            _firstName = firstName;
            _accountType = accountType;
        }

        public double calculate(Calculator c)
        {
            _interestAccured = c.calculate(this);
            return _interestAccured;
        }
        
        public bool isOpen()
        {
            return _status == StatusEnum.Open;
        }

        public Account addName(String name)
        {
            _names.Add(name);
            return this;
        }
        /// private member and getter
        private String _number;
        public String number
        {
            get
            {
                return _number;
            }
        }
        private String _firstName;
        public String firstName
        {
            get
            {
                return _firstName;
            }
        }
        private List<String> _names = new List<string>();
        public List<String> names
        {
            get
            {
                return _names;
            }
        }
        private StatusEnum _status = StatusEnum.Open;
        public StatusEnum status
        {
            get
            {
                return _status;
            }
        }
        private TypeEnum _accountType = TypeEnum.Trading;
        public TypeEnum accountType
        {
            get
            {
                return _accountType;
            }
        }
        private double _interestAccured;
        public double interesstAccured
        {
            get
            {
                return _interestAccured;
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
