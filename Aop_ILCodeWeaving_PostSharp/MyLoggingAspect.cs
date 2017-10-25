using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aop_ILCodeWeaving_PostSharp
{
    [PSerializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class MyLoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            string logData = CreateLogData("Entering", args);
            Console.WriteLine(logData);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            string logData = CreateLogData("Exception", args);
            Console.WriteLine(logData);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            string logData = CreateLogData("Success", args);
            Console.WriteLine(logData);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            string logData = CreateLogData("Leaving", args);
            Console.WriteLine(logData);
        }

        private string CreateLogData(string methodStage, MethodExecutionArgs args)
        {
            var str = new StringBuilder();
            str.AppendLine();
            str.AppendLine(string.Format(methodStage + " {0} ", args.Method));
            foreach (var argument in args.Arguments)
            {
                var argType = argument.GetType();

                str.Append(argType.Name + ": ");

                if (argType == typeof(string) || argType.IsPrimitive)
                {
                    str.Append(argument);
                }
                else
                {
                    foreach (var property in argType.GetProperties())
                    {
                        str.AppendFormat("{0} = {1}; ",
                            property.Name, property.GetValue(argument, null));
                    }
                }
            }
            return str.ToString();
        }
    }
}
