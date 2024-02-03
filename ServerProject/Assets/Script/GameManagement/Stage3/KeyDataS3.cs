using UnityEngine;

[CreateAssetMenu(fileName = "KeyData", menuName = "ScriptableObjects/KeyDataS3", order = 1)]
public class KeyDataS3 : ScriptableObject
{
    public bool Key1 = false; // 1번 키를 얻었는가?
    public bool Key2 = false; // 2번 키를 얻었는가?
}
