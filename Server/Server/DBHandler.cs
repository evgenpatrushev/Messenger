using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server
{
    class DBHandler
    {
        private String dbPath = "";
        private String tableName;


        private String CreateQuery()
        {
            return "";              
        }

        private String SelectQuery()
        {
            return "";
        }

        private String InsertQuery()
        {
            return "";
        }

        private String UpdateQuery()
        {
            return "";
        }

        private String JoinQuery()
        {
            return "";
        }

        private void Execute(Func<String> queryFunction)
        {
            ;
        }


    }

    class DBUsers : DBHandler
    {
        private String tableName = "Users";
    }

    class DBChats : DBHandler
    {
        private String tableName = "Chats";
    }
}
