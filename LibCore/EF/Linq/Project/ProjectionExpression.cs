using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SysPro.Core.EF.Linq.Project
{
    public class ProjectionExpression<TSource> : IProjectionExpression<TSource>
    {
        private readonly IQueryable<TSource> source;
        private readonly ParameterExpression parameterExpression = Expression.Parameter(typeof(TSource), "s");

        public ProjectionExpression(IQueryable<TSource> source)
        {
            this.source = source;
        }

        public IQueryable<TDest> To<TDest>()
        {
            return To<TDest>(mapper => { });
        }

        public IQueryable<TDest> To<TDest>(Action<Mapper<TSource, TDest>> customMap)
        {
            var customMappings = new List<Mapping>();
            var ignoredProperties = new List<PropertyInfo>();
			var mapper = new Mapper<TSource, TDest>(customMappings, ignoredProperties);
			customMap(mapper);

			Expression<Func<TSource, TDest>> expr = null;
	        var cacheKey = CreateCacheKey(typeof (TSource), typeof (TDest), customMappings, ignoredProperties, mapper.IsDefaultMappingIgnored);
	        expr = ProjectionCache.Current.FindValue(cacheKey) as Expression<Func<TSource, TDest>>;
	        if (expr == null)
	        {
		        expr = BuildExpression<TDest>(customMappings, ignoredProperties, mapper.IsDefaultMappingIgnored);
		        ProjectionCache.Current.SetValue(cacheKey, expr);
	        }
	        var result = source.Select(expr);
            return result;
        }

		/// <summary>
		/// Create unique key for expression
		/// </summary>
		static string CreateCacheKey(Type TSource, Type TDest, List<Mapping> customMappings, List<PropertyInfo> ignoredProperties, bool isDefaultMappingIgnored)
		{
			var cacheKey = String.Format("{0}${1}", TSource.FullName, TDest.FullName);
			if (customMappings.Count > 0)
			{
				var mappingsString = String.Join("$", customMappings.Select(m => String.Format("{0};{1}", m.DestPropertyInfo.Name, m.Transform)).ToArray());
				cacheKey += mappingsString;
			}
			if (ignoredProperties.Count > 0)
			{
				cacheKey += ("$IGNORED:" + String.Join("$", ignoredProperties.Select(p => p.Name).ToArray()));
			}
			if (isDefaultMappingIgnored)
			{
				cacheKey += "$CustomMappingIgnored$";
			}
			return cacheKey;
		}

		private Expression<Func<TSource, TDest>> BuildExpression<TDest>(IEnumerable<Mapping> customMaps, IEnumerable<PropertyInfo> ignoredProperties, bool isDefaultMappingIgnored)
        {
            var sourceMembers = typeof(TSource).GetProperties();
            var destinationMembers = typeof(TDest).GetProperties();

            var resultExp = Expression.MemberInit(
                        Expression.New(typeof(TDest)),
                        destinationMembers
                            .Where(dest => !ignoredProperties.Contains(dest))
                            .Select(dest => CreateAssignment(dest, customMaps, sourceMembers, isDefaultMappingIgnored))
                            .Where(d => d != null)
                            .ToArray());

            var result =
                Expression.Lambda<Func<TSource, TDest>>(
                    resultExp,
                    parameterExpression);
            return result;
        }

		MemberAssignment CreateAssignment(PropertyInfo dest, IEnumerable<Mapping> customMaps, PropertyInfo[] sourceMembers, bool isDefaultMappingIgnored)
        {
            var customMap = customMaps.FirstOrDefault(m => m.DestPropertyInfo == dest);
            if (customMap != null)
            {
                var transformExpression = customMap.Transform;
                var visitor = new CustomExpressionVisitor(parameterExpression);
                var newExpression = (LambdaExpression)visitor.Visit(transformExpression);

                var res = Expression.Bind(dest, newExpression.Body);
                return res;
            }

			//If default mapping is ignored we don't automatically map anything
			if (isDefaultMappingIgnored)
				return null;

            //Check for exact match
            var sourceProp = sourceMembers.FirstOrDefault(pi => pi.Name == dest.Name);
            if (sourceProp != null)
            {
                var exp = Expression.Property(parameterExpression, sourceProp);
                //Map only assignable types
                if (dest.PropertyType.IsAssignableFrom(exp.Type) == false)
                    return null;

                try
                {
                    var res = Expression.Bind(dest, exp);
                    return res;
                }
                catch (ArgumentException)
                {
                    //it's ok. It means - the types of properties are not assignable 
                    return null;
                }
            }

            return FindCamelCaseAssignment(dest, sourceMembers);
        }
        /// <summary>
        /// Finds CamelCase match (e.g. PersonName -> Person.Name)
        /// </summary>
        MemberAssignment FindCamelCaseAssignment(MemberInfo destinationProperty, PropertyInfo[] sourceProperties)
        {
            var allCombinations = StringHelper.SplitToWordGroups(destinationProperty.Name);
            foreach (var comb in allCombinations)
            {
                var properties = sourceProperties;
                PropertyInfo prop = null;
                Expression pe = parameterExpression;

                foreach (var word in comb)
                {
                    if (properties == null)
                        break;
                    prop = properties.FirstOrDefault(p => p.Name == word);
                    if (prop == null)
                        break;
                    properties = prop.PropertyType.GetProperties();
                    pe = Expression.Property(pe, prop);
                }
                if (prop != null)
                {
                    var result = Expression.Bind(destinationProperty, pe);
                    return result;
                }
            }
            return null;
        }
    }

    public class CustomExpressionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression parameter;

        public CustomExpressionVisitor(ParameterExpression parameter)
        {
            this.parameter = parameter;
        }

		protected override Expression VisitParameter(ParameterExpression node)
		{
		    //return parameter;
			if (node.Name == parameter.Name)
				return parameter;
			return node;
		}
    }
}
