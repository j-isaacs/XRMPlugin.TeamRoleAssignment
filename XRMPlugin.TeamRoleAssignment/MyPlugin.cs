using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XRMPlugin.TeamRoleAssignment
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "User Team/Role Assignment"),
        ExportMetadata("Description", "This tool allows bulk user assignment of teams and roles"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABmJLR0QA/wD/AP+gvaeTAAACUUlEQVRYhe3WuWtVURAG8F82CzHgLhj3DYMYhVhEBBUVxEr9KwSLoDZiY5VOQUGwFjfkYaEETCEWbmChuIE7uOGKuEU0LokW5wZuTu57uVefiJAPpnhz7pzvO3PmzDyG8Y9R85txY7EBK9GE69hWLVFDYTM+4GfK+rAHS/42+faIOLY+bCmy4VBX0IK1Qpqv4ABqh4j5gU2YjEko4XwRUTAOJ4VTvcIT4XSVTp+273iIB7iHjQrUWy0u4C5WJIEz8KyAgFPJXtNwHN04mlfAenzFzMh/roCAi1FsK3qFVzPotDGW4qyQwjTu5T0BHkW/r+Aq1uQRAF8yfC8LCHhdxjc6j4CbaMvwtxYQ0JzhW4gbeQTMFdTGVXu/gIA70e86fMb4PAI+CK12SuTfhcc5yB9hd+SbgFGyr3YQRuMa9mestRv6BbRnxO3DLRkZKId2oegaI/8EvK1A/h4To5iRQg/ZmpdcQvxc6P0xdlQQsDPj+y1CTY3JIir3DLuVf3Yfy6nGpwzfCLzAuyIC2jBPmAMxplcQEHdPyR6z5RjVNViHLqFtHkZDar0Je4VpV+4KeoWCm5qKa8CxZO0EVmWRL8BlYYqVsDy11oJD+FaBOLZvOILFqX1WCxO2VxjPs/sX5gj32mlgCmcIU63IGM6yrmSvfszHGbyR9JrOxJHufIuEovkT4rS9SzLZj3pcwsEa9OC2ga12mfCPppp4buCYbsa4ukTNx0RID2YJNVFtNAqZeJrwPMXprA87VC/1sXXEZPUZAkpl/NVA6S/tO4z/GL8ArL73FPTJxjYAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAYAAACOEfKtAAAABmJLR0QA/wD/AP+gvaeTAAAGSklEQVR4nO2ca4gXVRTAf+tjt7J21cyil1qWWWDWqmn2UtIiosgeUhHUh6QvkX2wCCt7WVRkZkSGoUUPi4IwKwIjSA1DAjVL8oGamNlquKmr7kPtw9mxM////Hfumecuzg8O3D97zz13zty5c8+9ZxYKCgoKCgoKCgqOR6ry7kAAg4HxwEjgAuB8oBdQB/wM3Azsyq13nZTewFTgV+BoiMzLqY+dkmpgGvAP4Y7zpAUZmcc95wErcXeclsPAJmAuMCLrjncG6oHdRHNekCwE+mR6BTlyCbCH5JznyQbgrAyvIxdOBtaRvPM8WQOcmNnV5MBrpOc8T17J7GpIdh1YDVwLTACGAxcBtciIWAjMQB6z6gRtBtEMTAQGAqOAy4D+yFKpFlgG3AbsS7kfztQCzwI76XhkRH3jpiHPpOKJCEwC/iZ/h1hlFxLp9IzrgDiP8Ix2KW1jNxJybQT2A0/EsBGHHcAq4DegAWgC3gR6qDp7gPeBF5DFfGY8RvldXYzEqaV39buAulnIhIB+f1qh7jZgaFRnWBkDtCrjDcDtHdSvAz4iG6dpmRLQlz7Ay8AiyufsrUBfkyciUIU8np7RvcgbN4wnydZ5R4GnQ/rUE5heojPX4VpicU2JwXsc9Uo7moXMcOzb20qnGTjTUQ+AbpbKyFvXYz3wiaPebqOdJGh1rDcNedmBrFEnW4xYHThGlRcARxz1NhjtJMEfjvX2A5+p31dZjFgdeK4q/2LQW4VsQWXJ74a6y1V5iMWI1YF6xG016DUCK4y24tAArDbUX6/KgyyGrA5sUuVao67rI5UEG7GN+IOqbPKJ1YH6ZXC6Qe8MjJNzTMYih1Ou6C0w15cPYHegniuCVvqVuBJ/CJUFlq3+elVeZzFideBSVb4V91i6l9FOEli2ze5V5UUWI1YH1qnyObiHPluMdpJgs2O9wci+oUdDCn05ht7T+9yg1wtoI7sopBU4ybFv1fiPGVJdLei9v+uNuovJzoGmxxC4Q+lusihaH2G99rvYqDsTGYVp0wa8aNTRAUKqj/Ac/HfqJqP+A8Ah0ht5h4D7jX26FH9KyRyjvolhyALVM9aCcfcCGR1pOfAlY1/6IbGwbmOssQ0zjyARiWfQukAeR3oOHG/syySlewR4y6gfmYXK8DtG3R7AdpJ33g7sh0R6SvrYqAvYXyIey1R5MraFchvppKgtwBaG1QB3q9/LK1VMg/7I/OfdvelG/T7YUtrCpBE4zdiHh5V+G/a5PDbvqg40Y38jP0RyDpxqtD0c+FfpW4KCxOiHf2H9dYQ2viC+85ZgP9/+QOkfQHIVIxF1DgTZ2npd/Y6SFbUmhn2PtYgjLOhcwjm4x81lxHEg+LeoXM9HNNYLD+KECDr6umMlWMV1YI0qH6xYqzJJZIdFGfktqlxTsZYDcR2odzyipIslsU8YxYH6aCI3B56N/2B9T4Q2kkilqAuvUoZOJLoTuZZMmYzsWugwaFSHGuUMwx8SRpU24Gqj7cvb++y1sR37MsxMDbLTsZryi3jV2NZdJLuQ3gc8aOzDrIB2liLxcdypzcdAZJdDjzg98mYaDI4GvgpoJyn5HrjOsS/dkGVYUDtbgMeRtW5kLgQ+pPJW/E+4bf14+SY/VGgnDVkB3IfbEmcilT8xOwjMxnaEy6nAfIId14rkkbg4bgAyOsNyp9OUXUjWflikUYXMgUvwz42e7G+/ltAbMhr4M6CB7UhitsuHLKOBL8n2EClMDgPf4JY4NBR4g+CPgdbSwc0YR/lbcRsS9LucsY5A4uG8nRUm3wJXOFzPKUiSZmOJ/l/IJxw+BuH/dq0VeA63RWZvZGcmaOh3VjmC7B+6fF/XF3ivRH99+3UfY5H6Ywtwi0PDIGu5zZ3AIVFlC3Ko5MLUEt3Z3h9GlvzhKccGxyA50nk7Ia7sxZ842hHzlV4z7RGMXlDuxO1cYQjlc0NXlkZk2RZGX/zHso/2AG5QFX5EHssw5hEtBu2s1CEHZUGfRpSykv9DxxurEI/G2pE4jtlWhQzFgmg0dUdSdeuB7jl3pqtxAHjeqjSb/Cf8tGWWxSHWbZv68CpdHtN/AbE6cKCxfldkgKWy1YGmDPYuiumDIGvm/BQkUskjaTwLmojwYigoKCgoKCgoKCgoKCjoUvwHgcEmrcrfLkkAAAAASUVORK5CYII="),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}