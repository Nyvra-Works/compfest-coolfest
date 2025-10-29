using UnityEngine;
namespace VozSoldat.GlobalVariables
{
    public abstract class GlobalVariable <WrappedType, Self> : ScriptableObject where Self : GlobalVariable<WrappedType, Self> 
    {
#if UNITY_EDITOR
        [Multiline]
        public string Description = "";
#endif
        public WrappedType Value;
        public void SetValue(WrappedType value)
        {
            Value = value;
        }

        public void SetValue(Self value)
        {
            Value = value.Value;
        }
    }
}
