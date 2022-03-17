using System;
using System.Reflection;

namespace ONYX.UnitTests.TestUtils
{
    public static class AttributeChecker
    {

        public static object[] GetMethodAttributes(object @class, string methodName, Type attributeType)
        {
            var methodInfo = GetMethodInfo(@class, methodName);
            var attributes = methodInfo.GetCustomAttributes(attributeType, true);

            return attributes;
        }

        private static MethodInfo GetMethodInfo(object @class, string methodName)
        {
            var type = @class.GetType();
            return type.GetMethod(methodName);
        }

        public static object[] GetClassAttributes(object @class, Type attributeType)
        {
            var type = @class.GetType();
            var attributes = type.GetCustomAttributes(attributeType, true);
            return attributes;
        }
    }
}
