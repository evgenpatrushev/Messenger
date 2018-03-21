using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    class Wrap
    {
        private Dictionary<String,String> filters = new Dictionary<String, String> ();
        private String table;

        public Wrap(String _table)
        {
            table = _table;
        }

        private String SelectQuery(String[] args, int number)
        {
            String result = "";
            foreach (String attribute in args)
            {
                result += (" " + attribute);
            }
            return String.Format("Attributes for {0}:{1} and Number {2} were proccesed", table, result, number);
        }

        public String Select(String[] args, int number)
        {
            return Execute(SelectQuery, args, number);
        }

        private String Execute(Func<String[], int, String> function, String[] args, int value)
        {
            return function(args, value) + " and wrapped";
        }
    }
}
