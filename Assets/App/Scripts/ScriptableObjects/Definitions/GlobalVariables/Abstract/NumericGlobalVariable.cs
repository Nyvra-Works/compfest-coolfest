using UnityEngine;

namespace VozSoldat.GlobalVariables
{
    public abstract class NumericGlobalVariable <WrappedType, Self> : GlobalVariable<WrappedType, Self> where Self : NumericGlobalVariable<WrappedType, Self> 
    {
        public void ApplyChange(WrappedType amount)
        {
            object result = null;

            if (typeof(WrappedType) == typeof(float))
                result = (float)(object)Value + (float)(object)amount;
            else if (typeof(WrappedType) == typeof(int))
                result = (int)(object)Value + (int)(object)amount;
            else if (typeof(WrappedType) == typeof(double))
                result = (double)(object)Value + (double)(object)amount;
            else if (typeof(WrappedType) == typeof(Vector3))
                result = (Vector3)(object)Value + (Vector3)(object)amount;
            else if (typeof(WrappedType) == typeof(Vector3))
                result = (Vector2)(object)Value + (Vector2)(object)amount;
            else
                throw new System.InvalidOperationException(
                    $"Type {typeof(WrappedType)} does not support addition.");

            Value = (WrappedType)result;
        }

        public void ApplyChange(Self amount)
        {
            ApplyChange(amount.Value);
        }
    }
}