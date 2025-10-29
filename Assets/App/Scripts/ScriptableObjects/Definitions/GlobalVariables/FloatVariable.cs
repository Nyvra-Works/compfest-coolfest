using UnityEngine;
// namespace VozSoldat.GlobalVariables
// {

[CreateAssetMenu(fileName = "SO_FloatVariable", menuName = "Scriptable Objects/Global Variables/Float Variable", order = 1)]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DesignerDescription = "";
#endif
        public float Value;
        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }
        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }
    }
// }
