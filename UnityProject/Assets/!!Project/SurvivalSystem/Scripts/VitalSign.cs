using UnityEngine;

namespace itonigames.unitystuff.SurvivalSystem
{
    public class VitalSign
    {
        private readonly VitalSignSo definition;
        private int currentValue;
        private float timeLastChange;

        public string Name => this.definition.ID;
        public int CurrentValue => this.currentValue;
        public int MaxValue => this.definition.MaxValue;

        public VitalSign(VitalSignSo definition)
        {
            this.definition = definition;
            this.currentValue = this.definition.DefaultValue;
        }

        public void ChangeValue(int amount)
        {
            this.currentValue += amount;
            this.currentValue = Mathf.Clamp(this.currentValue, 0, 100);
            this.timeLastChange = Time.time;
        }

        public void UpdateDepletion()
        {
            if (Time.time > this.timeLastChange + this.definition.DepletionRate)
            {
                this.ChangeValue(this.definition.DepletionAmount);
            }
        }
    }
}