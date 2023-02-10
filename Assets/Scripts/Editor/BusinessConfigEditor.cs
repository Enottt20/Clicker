using UnityEditor;

namespace Assets.Scripts
{
    [CustomEditor(typeof(Config<BusinessData>), true)]
    public class BusinessConfigEditor : ConfigEditor<BusinessData>
    {
    }
}