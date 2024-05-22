using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityEngine
{
    namespace VinExtension
    {
        public class EnumParse
        {
            public static T StringToEnum<T>(String value) where T : struct, Enum
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value cannot be null or empty.");
                }

                if (!Enum.TryParse(value, out T enumValue))
                {
                    throw new ArgumentException($"Failed to parse \"{value}\" as enum of type {typeof(T)}.");
                }

                return enumValue;
            }
        }
    }
}


