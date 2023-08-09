using UnityEngine;

namespace itonigames.unitystuff.SurvivalSystem
{
    [CreateAssetMenu(fileName = "SignModifier", menuName = "Survival System/Sign Modifier", order = 0)]
    public class SignModifierSo : ScriptableObject
    {
        [SerializeField] private string id;
        [Tooltip("Effects this vital sign")][SerializeField] private VitalSignSo signDefinition;
        [SerializeField] private int changeValue;

        public string ID => this.id;
        public int ChangeValue => this.changeValue;
    }
}