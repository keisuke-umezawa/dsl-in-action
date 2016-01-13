using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{

    public
        class TenuantStore
    {
        public TenuantStore()
        {
        }
        public TenuantStore getTenant(string tenant)
        {
            return TenuantStore();
        }
        public IEnumerable<string> getTenantNames()
        {
            return Array<string>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }