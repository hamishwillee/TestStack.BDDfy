﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bddify.Scanners.StepScanners
{
    internal static class StepScannerExtensions
    {
        internal static object[] FlattenArrays(this object[] inputs)
        {
            var flatArray = new List<object>();
            foreach (var input in inputs)
            {
                var inputArray = input as Array;
                if (inputArray != null)
                {
                    var temp = (from object arrElement in inputArray select GetSafeString(arrElement)).ToArray();
                    flatArray.Add(string.Join(", ", temp));
                }
                else if (input == null)
                    flatArray.Add("'null'");
                else
                    flatArray.Add(input);
            }

            return flatArray.ToArray();
        }

        static object GetSafeString(object input)
        {
            if (input == null)
                return "'null'";

            return input.ToString();
        }
    }
}