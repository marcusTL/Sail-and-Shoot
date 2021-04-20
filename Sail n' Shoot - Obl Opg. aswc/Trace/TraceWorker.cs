using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail_n__Shoot___Obl_Opg._aswc.Trace
{
    public class TraceWorker
    {
         TraceSource ts = new TraceSource("Sea");
        public TraceWorker()
        {
            ts.Switch = new SourceSwitch("Marcus", "All");

            TraceListener consoleLog = new ConsoleTraceListener();
            ts.Listeners.Add(consoleLog);
            TraceListener fileLog = new TextWriterTraceListener(new StreamWriter("SeaTrace.txt") { AutoFlush = true });
            ts.Listeners.Add(fileLog);
            //C:\Users\mtlau\source\repos\4th semester\Sail n' Shoot - Obl Opg. aswc\GameTest\bin\Debug\net5.0
        }
        public void TraceTest()
        {
            ts.TraceEvent(TraceEventType.Information, 111, "dette er information");
            ts.TraceEvent(TraceEventType.Verbose, 111, "dette er Verbose");
            ts.TraceEvent(TraceEventType.Warning, 111, "dette er Warning");

        }

        public void CloseTrace()
        {
            ts.Close();
        }

        public void TextToTrace(string text)
        {
            ts.TraceInformation(text);
            CloseTrace();
        }
    }
}
