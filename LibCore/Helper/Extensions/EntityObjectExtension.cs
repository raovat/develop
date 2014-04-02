using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;

namespace LibCore.Helper.Extensions
{
    //Link Ref: http://www.codeproject.com/Articles/137853/Cloning-the-Entity-object-and-all-related-children
    public static class EntityObjectExtension
    {
        public static T Clone<T>(this T source) where T : EntityObject
        {
            var obj = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
            using (var stream = new System.IO.MemoryStream())
            {
                obj.WriteObject(stream, source);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return (T)obj.ReadObject(stream);
            }
        }

        public static EntityObject LoadAllChild(this EntityObject source)
        {
            List<PropertyInfo> PropList = (from a in source.GetType().GetProperties()
                                           where a.PropertyType.Name == "EntityCollection`1"
                                           select a).ToList();
            foreach (PropertyInfo prop in PropList)
            {
                object instance = prop.GetValue(source, null);
                bool isLoad =
                  (bool)instance.GetType().GetProperty("IsLoaded").GetValue(instance, null);
                if (!isLoad)
                {
                    MethodInfo mi = (from a in instance.GetType().GetMethods()
                                     where a.Name == "Load" && a.GetParameters().Length == 0
                                     select a).FirstOrDefault();

                    mi.Invoke(instance, null);
                }
            }
            return (EntityObject)source;
        }

        public static EntityObject ClearEntityReference(this EntityObject source,
                                                bool bcheckHierarchy)
        {
            return source.ClearEntityObject(bcheckHierarchy);
        }

        private static T ClearEntityObject<T>(this  T source,
                         bool bcheckHierarchy) where T : class
        {
            //Throw if passed object has nothing
            if (source == null) { throw new Exception("Null Object cannot be cloned"); }
            // get the TYpe of passed object 
            Type tObj = source.GetType();
            // check object Passed does not have entity key Attribute 
            if (tObj.GetProperty("EntityKey") != null)
            {
                tObj.GetProperty("EntityKey").SetValue(source, null, null);
            }

            //bcheckHierarchy this flag is used to check
            //and clear child object releation keys 
            if (!bcheckHierarchy)
            {
                return (T)source;
            }

            // Clearing the Entity for Child Objects 
            // Using the Linq get only Child Reference objects   from source object 
            List<PropertyInfo> PropList = (from a in source.GetType().GetProperties()
                                           where a.PropertyType.Name.ToUpper() == "ENTITYCOLLECTION`1"
                                           select a).ToList();

            // Loop thorough List of Child Object and Clear the Entity Reference 
            foreach (PropertyInfo prop in PropList)
            {
                IEnumerable keys =
                  (IEnumerable)tObj.GetProperty(prop.Name).GetValue(source, null);

                foreach (object key in keys)
                {
                    //Clearing Entity Reference from Parnet Object
                    var ochildprop = (from a in key.GetType().GetProperties()
                                      where a.PropertyType.Name == "EntityReference`1"
                                      select a).SingleOrDefault();

                    ochildprop.GetValue(key, null).ClearEntityObject(false);

                    //Clearing the the Entity Reference from
                    //Child object .This will recrusive action
                    key.ClearEntityObject(true);
                }
            }
            return (T)source;
        }


        /// <summary>
        /// Gets an object property's value, recursively traversing it's properties if needed.
        /// </summary>
        /// <param name="FrameObject">The object.</param>
        /// <param name="PropertyString">The object property string.
        /// Can be the property of a property. e.g. Position.X</param>
        /// <returns>The value of this object's property.</returns>
        private object GetObjectPropertyValue(Object FrameObject, string PropertyString)
        {
            object Result = FrameObject;

            string[] Properties = PropertyString.Split('.');

            foreach (var Property in Properties)
            {
                Result = Result.GetType().GetProperty(Property).GetValue(Result, null);
            }

            return Result;
        }
    }
}
