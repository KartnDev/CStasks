using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NumMethods1.Utils
{
    class ReflectionInvoker
    {
        public object InvokeString(string lambdaStr) => ExecuteLambdaExpression(lambdaStr);
        private object ExecuteLambdaExpression(string lambdaExpression)
        {
            string source =
            "namespace LambdaNamespace" +
            "{" +
                "public class LambdaClass" +
                "{" +
                    "delegate bool MethodDelegate();" +
                    "public bool LambdaMethod()" +
                    "{" +
                        lambdaExpression +
                    "}" +
                "}" +
            "}";

            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, source);

            Console.WriteLine("compiled with errors: " +
                results.Errors.HasErrors + ", warnings: " +
                results.Errors.HasWarnings);

            if (!results.Errors.HasErrors && !results.Errors.HasWarnings)
            {
                Assembly ass = results.CompiledAssembly;

                object lambdaClassInstance =
                        ass.CreateInstance("LambdaNamespace.LambdaClass");

                object lambdaMethodResult =
                        lambdaClassInstance.GetType().InvokeMember("LambdaMethod",
                        BindingFlags.InvokeMethod, null, lambdaClassInstance, new object[] { });

                return lambdaMethodResult;
            }

            return null;
        }

    }
}
