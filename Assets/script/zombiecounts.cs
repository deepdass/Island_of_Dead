using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombiecounts : MonoBehaviour
{
    public int zombiecount;
    public Text zombietext;
    public void updatecount() {
        zombietext.text = zombiecount.ToString();
    }
}
