﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace SysPro.Core.EF.DynamicSelectExtensions
{
    //Thanks to Ethan J. Brown:
    //  http://stackoverflow.com/questions/606104/how-to-create-linq-expression-tree-with-anonymous-type-in-it/723018#723018

    public static class DynamicTypeBuilder
    {
        private static AssemblyName assemblyName = new AssemblyName() { Name = "DynamicLinqTypes" };
        private static ModuleBuilder moduleBuilder = null;
        private static Dictionary<string, Tuple<string, Type>> builtTypes = new Dictionary<string, Tuple<string, Type>>();

        static DynamicTypeBuilder()
        {
            moduleBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run).DefineDynamicModule(assemblyName.Name);
        }

        private static string GetTypeKey(Dictionary<string, Type> fields)
        {
            string key = string.Empty;
            foreach (var field in fields.OrderBy(v => v.Key).ThenBy(v => v.Value.Name))
                key += field.Key + ";" + field.Value.Name + ";";
            return key;
        }

        public static Type GetDynamicType(Dictionary<string, Type> fields, Type basetype, Type[] interfaces)
        {
            if (null == fields)
                throw new ArgumentNullException("fields");
            if (0 == fields.Count)
                throw new ArgumentOutOfRangeException("fields", "fields must have at least 1 field definition");

            try
            {
                Monitor.Enter(builtTypes);
                string typeKey = GetTypeKey(fields);

                if (builtTypes.ContainsKey(typeKey))
                    return builtTypes[typeKey].Item2;

                string typeName = "DynamicLinqType" + builtTypes.Count.ToString();
                TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Serializable, null, Type.EmptyTypes);

                foreach (var field in fields)
                    typeBuilder.DefineField(field.Key, field.Value, FieldAttributes.Public);

                builtTypes[typeKey] = new Tuple<string, Type>(typeName, typeBuilder.CreateType());

                return builtTypes[typeKey].Item2;
            }
            catch
            {
                throw;
            }
            finally
            {
                Monitor.Exit(builtTypes);
            }
        }
    }
}
