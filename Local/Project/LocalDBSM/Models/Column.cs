using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocalDBSM.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataType
    {
        Integer,
        Real,
        Char,
        String,
        TextFile,
        IntegerInvl
    }

    public abstract class Column
    {
        public string Name { get; set; }
        public abstract DataType Type { get; }
        public bool IsNullable { get; set; }
        public Column(string name, bool isNull)
        {
            Name = name;
            IsNullable = isNull;
        }
        public abstract bool Validate(string value);
    }

    public class IntColumn : Column
    {
        public override DataType Type { get; } = DataType.Integer;
        public IntColumn(string name, bool isNull) : base(name, isNull) { }

        public override bool Validate(string value)=> int.TryParse(value, out _);
        
    }

    public class RealColumn : Column
    {
        public override DataType Type { get; } = DataType.Real;
        public RealColumn(string name, bool isNull) : base(name, isNull) { }

        public override bool Validate(string value) => double.TryParse(value, out _);
        
    }

    public class CharColumn : Column
    {
        public override DataType Type { get; } = DataType.Char;
        public CharColumn(string name, bool isNull) : base(name, isNull) { }

        public override bool Validate(string value)=>char.TryParse(value, out _);
        
    }

    public class StringColumn : Column
    {
        public override DataType Type { get; } = DataType.String;
        public StringColumn(string name, bool isNull) : base(name, isNull) { }

        public override bool Validate(string value) => true;
    }

    public class TextFileColumn : Column
    {
        public override DataType Type { get; } = DataType.TextFile;
        public TextFileColumn(string name, bool isNull) : base(name, isNull) { }

        public override bool Validate(string value) => Regex.IsMatch(value, @"^[\w\s-]+\.txt$") ? true : false;
        
    }

    public class IntegerInvlColumn : Column
    {
        public override DataType Type { get; } = DataType.IntegerInvl;
        public IntegerInvlColumn(string name, bool isNull) : base(name, isNull) { }

        public override bool Validate(string value)
        {
            string[] integers = value.Split('-');

            if (integers.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(integers[0], out _))
            {
                return false;
            }

            if (!int.TryParse(integers[1], out _))
            {
                return false;
            }

            return true;
        }
    }
}
