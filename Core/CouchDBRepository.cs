using MyCouch;
using MyCouch.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class CouchDBRepository
    {
        public CouchDBRepository()
        {
            var dbConn = new DbConnectionInfo("","")
            {
                BasicAuth = new MyCouch.Net.BasicAuthString("", "")
            };
            
            using (var  client  = new MyCouchClient(dbConn))
            {
                
            }
        }
    }
}
