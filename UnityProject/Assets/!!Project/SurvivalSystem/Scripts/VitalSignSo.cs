using System;
using UnityEngine;
using UnityEngine.Events;

namespace itonigames.unitystuff.SurvivalSystem
{
    [CreateAssetMenu(fileName = "VitalSign", menuName = "Survival System/Vital Sign", order = 0)]
    public class VitalSignSo : ScriptableObject
    {
        [Header("Name")]
        [SerializeField] private string id;
        [Header("Values")]
        [SerializeField] private int defaultValue;
        [SerializeField] private int maxValue;
        [Header("Depletion")]
        [Tooltip("Time in seconds")]
        [SerializeField] private float depletionRate;
        [SerializeField] private int depletionAmount;

        public string ID => this.id;

        public int DefaultValue => this.defaultValue;

        public int MaxValue => this.maxValue;

        public float DepletionRate => this.depletionRate;

        public int DepletionAmount => this.depletionAmount;

        private void OnValidate()
        {
            this.defaultValue = Mathf.Clamp(this.defaultValue, 0, this.maxValue);
        }
    }
}