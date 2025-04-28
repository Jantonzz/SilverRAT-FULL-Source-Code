using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura;

[CompilerGenerated]
internal static class AssemblyLoader
{
    private static object nullCacheLock = new object();

    private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

    private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

    private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();

    private static int isAttached;

    private static string CultureToString(CultureInfo culture)
    {
        if (culture == null)
        {
            return "";
        }
        return culture.Name;
    }

    private static Assembly ReadExistingAssembly(AssemblyName name)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        int num = 0;
        Assembly assembly;
        while (true)
        {
            if (num < assemblies.Length)
            {
                assembly = assemblies[num];
                AssemblyName name2 = assembly.GetName();
                if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(CultureToString(name2.CultureInfo), CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                num++;
                continue;
            }
            return null;
        }
        return assembly;
    }

    private static void CopyTo(Stream source, Stream destination)
    {
        byte[] array = new byte[81920];
        int count;
        while ((count = source.Read(array, 0, array.Length)) != 0)
        {
            destination.Write(array, 0, count);
        }
    }

    private static Stream LoadStream(string fullName)
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        if (fullName.EndsWith(".compressed"))
        {
            using (Stream stream = executingAssembly.GetManifestResourceStream(fullName))
            {
                using DeflateStream source = new DeflateStream(stream, CompressionMode.Decompress);
                MemoryStream memoryStream = new MemoryStream();
                CopyTo(source, memoryStream);
                memoryStream.Position = 0L;
                return memoryStream;
            }
        }
        return executingAssembly.GetManifestResourceStream(fullName);
    }

    private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
    {
        if (resourceNames.TryGetValue(name, out var value))
        {
            return LoadStream(value);
        }
        return null;
    }

    private static byte[] ReadStream(Stream stream)
    {
        byte[] array = new byte[stream.Length];
        stream.Read(array, 0, array.Length);
        return array;
    }

    private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
    {
        string text = requestedAssemblyName.Name.ToLowerInvariant();
        if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
        {
            text = requestedAssemblyName.CultureInfo.Name + "." + text;
        }
        byte[] rawAssembly;
        using (Stream stream = LoadStream(assemblyNames, text))
        {
            if (stream == null)
            {
                return null;
            }
            rawAssembly = ReadStream(stream);
        }
        using (Stream stream2 = LoadStream(symbolNames, text))
        {
            if (stream2 != null)
            {
                byte[] rawSymbolStore = ReadStream(stream2);
                return Assembly.Load(rawAssembly, rawSymbolStore);
            }
        }
        return Assembly.Load(rawAssembly);
    }

    public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
    {
        lock (nullCacheLock)
        {
            if (nullCache.ContainsKey(e.Name))
            {
                return null;
            }
        }
        AssemblyName assemblyName = new AssemblyName(e.Name);
        Assembly assembly = ReadExistingAssembly(assemblyName);
        if (assembly != null)
        {
            return assembly;
        }
        assembly = ReadFromEmbeddedResources(assemblyNames, symbolNames, assemblyName);
        if (assembly == null)
        {
            lock (nullCacheLock)
            {
                nullCache[e.Name] = true;
            }
            if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
            {
                assembly = Assembly.Load(assemblyName);
            }
        }
        return assembly;
    }

    static AssemblyLoader()
    {
        assemblyNames.Add("bouncycastle.crypto", "costura.bouncycastle.crypto.dll.compressed");
        assemblyNames.Add("bunifu.licensing", "costura.bunifu.licensing.dll.compressed");
        symbolNames.Add("bunifu.licensing", "costura.bunifu.licensing.pdb.compressed");
        assemblyNames.Add("bunifu.ui.winforms.1.5.3", "costura.bunifu.ui.winforms.1.5.3.dll.compressed");
        assemblyNames.Add("bunifu.ui.winforms", "costura.bunifu.ui.winforms.dll.compressed");
        assemblyNames.Add("cgeoip", "costura.cgeoip.dll.compressed");
        assemblyNames.Add("costura", "costura.costura.dll.compressed");
        assemblyNames.Add("guna.ui2", "costura.guna.ui2.dll.compressed");
        assemblyNames.Add("microsoft.win32.registry.accesscontrol", "costura.microsoft.win32.registry.accesscontrol.dll.compressed");
        assemblyNames.Add("microsoft.win32.registry", "costura.microsoft.win32.registry.dll.compressed");
        assemblyNames.Add("microsoft.win32.systemevents", "costura.microsoft.win32.systemevents.dll.compressed");
        assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
        assemblyNames.Add("protobuf-net.core", "costura.protobuf-net.core.dll.compressed");
        assemblyNames.Add("protobuf-net", "costura.protobuf-net.dll.compressed");
        assemblyNames.Add("restsharp", "costura.restsharp.dll.compressed");
        assemblyNames.Add("system.buffers", "costura.system.buffers.dll.compressed");
        assemblyNames.Add("system.codedom", "costura.system.codedom.dll.compressed");
        assemblyNames.Add("system.collections.immutable", "costura.system.collections.immutable.dll.compressed");
        assemblyNames.Add("system.configuration.configurationmanager", "costura.system.configuration.configurationmanager.dll.compressed");
        assemblyNames.Add("system.data.odbc", "costura.system.data.odbc.dll.compressed");
        assemblyNames.Add("system.data.oledb", "costura.system.data.oledb.dll.compressed");
        assemblyNames.Add("system.data.sqlclient", "costura.system.data.sqlclient.dll.compressed");
        assemblyNames.Add("system.diagnostics.eventlog", "costura.system.diagnostics.eventlog.dll.compressed");
        assemblyNames.Add("system.diagnostics.performancecounter", "costura.system.diagnostics.performancecounter.dll.compressed");
        assemblyNames.Add("system.drawing.common", "costura.system.drawing.common.dll.compressed");
        assemblyNames.Add("system.io.filesystem.accesscontrol", "costura.system.io.filesystem.accesscontrol.dll.compressed");
        assemblyNames.Add("system.io.packaging", "costura.system.io.packaging.dll.compressed");
        assemblyNames.Add("system.io.pipes.accesscontrol", "costura.system.io.pipes.accesscontrol.dll.compressed");
        assemblyNames.Add("system.io.ports", "costura.system.io.ports.dll.compressed");
        assemblyNames.Add("system.memory", "costura.system.memory.dll.compressed");
        assemblyNames.Add("system.numerics.vectors", "costura.system.numerics.vectors.dll.compressed");
        assemblyNames.Add("system.runtime.compilerservices.unsafe", "costura.system.runtime.compilerservices.unsafe.dll.compressed");
        assemblyNames.Add("system.security.accesscontrol", "costura.system.security.accesscontrol.dll.compressed");
        assemblyNames.Add("system.security.cryptography.cng", "costura.system.security.cryptography.cng.dll.compressed");
        assemblyNames.Add("system.security.cryptography.pkcs", "costura.system.security.cryptography.pkcs.dll.compressed");
        assemblyNames.Add("system.security.cryptography.protecteddata", "costura.system.security.cryptography.protecteddata.dll.compressed");
        assemblyNames.Add("system.security.cryptography.xml", "costura.system.security.cryptography.xml.dll.compressed");
        assemblyNames.Add("system.security.permissions", "costura.system.security.permissions.dll.compressed");
        assemblyNames.Add("system.security.principal.windows", "costura.system.security.principal.windows.dll.compressed");
        assemblyNames.Add("system.servicemodel.duplex", "costura.system.servicemodel.duplex.dll.compressed");
        symbolNames.Add("system.servicemodel.duplex", "costura.system.servicemodel.duplex.pdb.compressed");
        assemblyNames.Add("system.servicemodel.http", "costura.system.servicemodel.http.dll.compressed");
        symbolNames.Add("system.servicemodel.http", "costura.system.servicemodel.http.pdb.compressed");
        assemblyNames.Add("system.servicemodel.nettcp", "costura.system.servicemodel.nettcp.dll.compressed");
        symbolNames.Add("system.servicemodel.nettcp", "costura.system.servicemodel.nettcp.pdb.compressed");
        assemblyNames.Add("system.servicemodel.primitives", "costura.system.servicemodel.primitives.dll.compressed");
        symbolNames.Add("system.servicemodel.primitives", "costura.system.servicemodel.primitives.pdb.compressed");
        assemblyNames.Add("system.servicemodel.security", "costura.system.servicemodel.security.dll.compressed");
        symbolNames.Add("system.servicemodel.security", "costura.system.servicemodel.security.pdb.compressed");
        assemblyNames.Add("system.servicemodel.syndication", "costura.system.servicemodel.syndication.dll.compressed");
        assemblyNames.Add("system.serviceprocess.servicecontroller", "costura.system.serviceprocess.servicecontroller.dll.compressed");
        assemblyNames.Add("system.text.encoding.codepages", "costura.system.text.encoding.codepages.dll.compressed");
        assemblyNames.Add("system.threading.accesscontrol", "costura.system.threading.accesscontrol.dll.compressed");
        assemblyNames.Add("system.web.services.description", "costura.system.web.services.description.dll.compressed");
        symbolNames.Add("system.web.services.description", "costura.system.web.services.description.pdb.compressed");
    }

    public static void Attach()
    {
        if (Interlocked.Exchange(ref isAttached, 1) == 1)
        {
            return;
        }
        AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs e)
        {
            lock (nullCacheLock)
            {
                if (nullCache.ContainsKey(e.Name))
                {
                    return null;
                }
            }
            AssemblyName assemblyName = new AssemblyName(e.Name);
            Assembly assembly = ReadExistingAssembly(assemblyName);
            if (assembly != null)
            {
                return assembly;
            }
            assembly = ReadFromEmbeddedResources(assemblyNames, symbolNames, assemblyName);
            if (assembly == null)
            {
                lock (nullCacheLock)
                {
                    nullCache[e.Name] = true;
                }
                if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
                {
                    assembly = Assembly.Load(assemblyName);
                }
            }
            return assembly;
        };
    }
}
