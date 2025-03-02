using UnityEngine;

public class PracticeDummyLogic : MonoBehaviour
{
    public void TakeDamage()
    {
        Debug.Log(gameObject.name + " taken damage");
    }
}
