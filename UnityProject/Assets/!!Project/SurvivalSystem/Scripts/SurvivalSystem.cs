using System.Collections.Generic;
using UnityEngine;

namespace itonigames.unitystuff.SurvivalSystem
{
    public class SurvivalSystem : MonoBehaviour
    {
        [Header("Database")]
        [SerializeField] private List<VitalSignSo> vitalSignDefinitions;
        [Header("Display")]
        [SerializeField] private RectTransform viewContainer;
        [SerializeField] private VitalSignView signalViewPrefab;
        [Header("System")]
        [Tooltip("Update system every X update")]
        [SerializeField] private int tickRate;

        private Dictionary<VitalSignSo, VitalSign> vitalSigns;
        private int fixedUpdateCount;

        private void Setup()
        {
            this.vitalSigns = new Dictionary<VitalSignSo, VitalSign>();

            foreach (var vitalSignDefinition in this.vitalSignDefinitions)
            {
                var newSign = new VitalSign(vitalSignDefinition);

                this.vitalSigns.Add(vitalSignDefinition, newSign);
                var view = Instantiate(this.signalViewPrefab, this.viewContainer);
                view.Setup(newSign);
            }
        }

        private void VitalSignModifierOnApplyModifier(VitalSignSo sign, int changeAmount)
        {
            this.vitalSigns[sign].ChangeValue(changeAmount);
        }

        private void UpdateDepletion()
        {
            if (this.fixedUpdateCount % this.tickRate != 0) return;

            foreach (var vitalSign in this.vitalSigns)
            {
                vitalSign.Value.UpdateDepletion();
            }
        }

        private void FixedUpdate()
        {
            this.fixedUpdateCount++;
            this.UpdateDepletion();
        }

        private void Awake()
        {
            this.Setup();
        }

        private void OnEnable()
        {
            VitalSignModifier.ApplyModifier += this.VitalSignModifierOnApplyModifier;
        }

        private void OnDisable()
        {
            VitalSignModifier.ApplyModifier -= this.VitalSignModifierOnApplyModifier;
        }
    }
}