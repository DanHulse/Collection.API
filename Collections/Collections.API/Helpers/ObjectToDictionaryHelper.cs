using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Collections.API.Helpers
{
    /// <summary>
    /// Helper method to convert an object into a dictionary of it's properties
    /// Found on GiyHub: https://gist.github.com/jarrettmeyer/798667
    /// </summary>
    public static class ObjectToDictionaryHelper
    {
        /// <summary>
        /// Translates object to the dictionary.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns><see cref="IDictionary{TKey, TValue}"/>from object</returns>
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }

        /// <summary>
        /// Translates object to the dictionary.
        /// </summary>
        /// <typeparam name="T">The provided object type</typeparam>
        /// <param name="source">The source.</param>
        /// <returns><see cref="IDictionary{TKey, TValue}"/>from object</returns>
        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null)
                ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
                AddPropertyToDictionary<T>(property, source, dictionary);

            return dictionary;
        }

        /// <summary>
        /// Adds the property to dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The property.</param>
        /// <param name="source">The source.</param>
        /// <param name="dictionary">The dictionary.</param>
        private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source, Dictionary<string, T> dictionary)
        {
            object value = property.GetValue(source);
            if (IsOfType<T>(value))
                dictionary.Add(property.Name, (T)value);
        }

        /// <summary>
        /// Determines whether property is of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>True if the property is of the specified type.</returns>
        private static bool IsOfType<T>(object value)
        {
            return value is T;
        }

        /// <summary>
        /// Throws the exception when source argument is null.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">source - Unable to convert object to a dictionary. The source object is null.</exception>
        private static void ThrowExceptionWhenSourceArgumentIsNull()
        {
            throw new ArgumentNullException("source", "Unable to convert object to a dictionary. The source object is null.");
        }
    }
}