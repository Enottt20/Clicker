using UnityEditor;

namespace Assets.Scripts
{
    [CustomEditor(typeof(Config<BusinessInfo>), true)]
    public class BusinessInfoConfigEditor : ConfigEditor<BusinessInfo>
    {
    }
}