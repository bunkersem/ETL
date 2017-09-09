using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Values
{
    public abstract class Value
    {
        private object value;
        public abstract object GetValue();
        public Value(Object value)
        {
            this.value = value;
        }
        public static Value operator +(Value first, Value second)
        {
            if (first is IntegerValue && second is IntegerValue)
                return (first as IntegerValue) + (second as IntegerValue);
            else if (first is BooleanValue && second is BooleanValue)
                return (first as BooleanValue) + (second as BooleanValue);
            else throw new InvalidOperationException("Plain Value object cannot have arithmetic functionality.");
        }

        public static Value operator -(Value first, Value second)
        {
            if (first is IntegerValue && second is IntegerValue)
                return (first as IntegerValue) - (second as IntegerValue);
            else if (first is BooleanValue && second is BooleanValue)
                return (first as BooleanValue) - (second as BooleanValue);
            else throw new InvalidOperationException("Plain Value object cannot have arithmetic functionality.");
        }
        public static Value operator *(Value first, Value second)
        {
            if (first is IntegerValue && second is IntegerValue)
                return (first as IntegerValue) * (second as IntegerValue);
            else if (first is BooleanValue && second is BooleanValue)
                return (first as BooleanValue) * (second as BooleanValue);
            else throw new InvalidOperationException("Plain Value object cannot have arithmetic functionality.");
        }
        public static Value operator /(Value first, Value second)
        {
            if (first is IntegerValue && second is IntegerValue)
                return (first as IntegerValue) / (second as IntegerValue);
            else if (first is BooleanValue && second is BooleanValue)
                return (first as BooleanValue) / (second as BooleanValue);
            else throw new InvalidOperationException("Plain Value object cannot have arithmetic functionality.");
        }

        public static bool operator ==(Value first, Value second)
        {
            if ((first as object) == null
                && (second as object) == null) return true;
            if ((first as object) == null
                || (second as object) == null) return false;
            if (first is BooleanValue && second is BooleanValue)
                return (bool)first.value == (bool)second.value;
            else if (first is IntegerValue && second is IntegerValue)
                return (int)first.value == (int)second.value;

            return first.value == second.value;

            //if (first is IntegerValue && second is IntegerValue)
            //    return (first as IntegerValue) == (second as IntegerValue);
            //else if (first is BooleanValue && second is BooleanValue)
            //    return (first as BooleanValue) == (second as BooleanValue);
            //else throw new InvalidOperationException("Plain Value object cannot have arithmetic functionality.");
        }

        public static bool operator !=(Value first, Value second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
