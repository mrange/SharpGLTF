﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using TARGET = SharpGLTF.IO.JsonSerializable;

namespace SharpGLTF.Validation
{
    /// <summary>
    /// Represents an exception produced by the serialization or validation of a gltf model.
    /// </summary>
    public class ModelException : Exception
    {
        #region lifecycle

        internal ModelException(TARGET target, String message)
            : base(_CreateBaseMessage(target, message))
        {
            _Target = target;
        }

        internal ModelException(TARGET target, Exception ex)
            : base(_CreateBaseMessage(target, ex.Message), ex)
        {
            _Target = target;
        }

        private static string _CreateBaseMessage(TARGET target, String message)
        {
            if (target == null) return message;

            // TODO: LogicalIndex property should be decorated with DynamicAccess

            var targetTypeInfo = target.GetType().GetTypeInfo();            

            var logicalIndexProp = targetTypeInfo.GetProperty("LogicalIndex");

            var logicalIndex = logicalIndexProp != null
                ? (int)logicalIndexProp.GetValue(target)
                : -1;

            if (logicalIndex >= 0) return $"{targetTypeInfo.Name}[{logicalIndex}] {message}";

            return $"{targetTypeInfo.Name} {message}";
        }

        #endregion

        #region data

        private readonly TARGET _Target;

        #endregion

        #region properties

        internal string MessageSuffix { get; set; }

        public override string Message
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MessageSuffix)) return base.Message;
                else return base.Message + MessageSuffix;
            }
        }

        private string _Generator
        {
            get
            {
                Schema2.ModelRoot root = null;
                if (_Target is Schema2.ModelRoot troot) root = troot;
                if (_Target is Schema2.LogicalChildOfRoot tchild) root = tchild.LogicalParent;

                return root?.Asset?.Generator ?? string.Empty;
            }
        }

        #endregion

        #region API

        internal static void _Decorate(Exception ex)
        {
            if (!(ex is ModelException mex)) return;

            var gen = mex._Generator;

            if (gen.Contains("SHARPGLTF", StringComparison.InvariantCultureIgnoreCase))
            {
                mex.MessageSuffix = $"Model generated by <{gen}> seems to be malformed.";
                return;
            }

            mex.MessageSuffix = $"Model generated by <{gen}> seems to be malformed; Please, check the file at https://github.khronos.org/glTF-Validator/";
        }

        #endregion
    }

    /// <summary>
    /// Represents an exception produced by an invalid JSON document.
    /// </summary>
    public class SchemaException : ModelException
    {
        internal SchemaException(TARGET target, String message)
            : base(target, message) { }

        internal SchemaException(TARGET target, System.Text.Json.JsonException rex)
            : base(target, rex) { }
    }

    /// <summary>
    /// Represents an esception produced by invalid values.
    /// </summary>
    public class SemanticException : ModelException
    {
        internal SemanticException(TARGET target, String message)
            : base(target, message) { }
    }

    /// <summary>
    /// Represents an exception produced by invalid objects relationships.
    /// </summary>
    public class LinkException : ModelException
    {
        internal LinkException(TARGET target, String message)
            : base(target, message) { }
    }

    /// <summary>
    /// Represents an exception produced by invalid data.
    /// </summary>
    public class DataException : ModelException
    {
        internal DataException(TARGET target, String message)
            : base(target, message) { }
    }
}