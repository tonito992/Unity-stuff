using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace itonigames.unitystuff.SurvivalSystem
{
    public class VitalSignView : MonoBehaviour
    {
        [SerializeField] private TMP_Text textName;
        [SerializeField] private TMP_Text textValue;
        [SerializeField] private Image bar;

        private VitalSign model;

        public void Setup(VitalSign vitalSign)
        {
            this.model = vitalSign;
            this.textName.SetText(vitalSign.Name);
            var percentage = (float)vitalSign.CurrentValue / vitalSign.MaxValue;
            this.bar.fillAmount = percentage;
            this.textValue.SetText($"{(percentage * 100):0}%");
        }

        private void FixedUpdate()
        {
            this.Setup(this.model);
        }
    }
}