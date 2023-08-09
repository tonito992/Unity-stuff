using System;
using UnityEngine;

namespace itonigames.unitystuff.SurvivalSystem
{
    public class VitalSignModifier : MonoBehaviour
    {
        public static event Action<VitalSignSo, int> ApplyModifier;

        [SerializeField] private VitalSignSo sign;
        [SerializeField] private SignModifierSo modifier;

        public void Consume()
        {
            this.OnApplyModifier();
        }

        private void OnApplyModifier()
        {
            ApplyModifier?.Invoke(this.sign, this.modifier.ChangeValue);
        }
    }
}