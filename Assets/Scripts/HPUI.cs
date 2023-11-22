using UnityEngine.UI;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    public Text livestext;

    // Update is called once per frame
    void Update()
    {
        livestext.text = PlayerStats.Lives.ToString() + " HP";
    }
}
