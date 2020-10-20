using Atomus.Diagnostics;
using System;
using System.Linq;

namespace Atomus.Service
{
    public class ServerStringAdapter : IServiceString
    {
        public ServerStringAdapter() { }
        
        string IServiceString.Request(string data)
        {
            try
            {
                //return (new ServerStringManager() as IServiceString).Request(data);
                return (this.CreateInstance("Service") as IServiceString).Request(data);
            }
            catch (AtomusException exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return exception.ToString();
            }
            catch (Exception exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return exception.ToString();
            }
        }
    }
}
