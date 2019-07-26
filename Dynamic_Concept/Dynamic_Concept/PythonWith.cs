using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace Dynamic_Concept
{
    class PythonWith
    { 
        public static void print()
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("n", "장성현");
            scope.SetVariable("p", "010-4283-6857");

            ScriptSource source = engine.CreateScriptSourceFromString(@"
class NameCard :
    name = ''
    phone= ''
    def __init__(self, name, phone) :
        self.name = name
        self.phone = phone

    def printNameCard(self) :
        print self.name + ', ' + self.phone

NameCard(n,p)
");
            dynamic result = source.Execute(scope);
            result.printNameCard();
            Console.WriteLine("{0}, {1}", result.name, result.phone);
        }

        
    }
}
