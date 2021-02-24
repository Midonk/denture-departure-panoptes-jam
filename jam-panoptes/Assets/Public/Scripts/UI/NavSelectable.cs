using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavSelectable : MonoBehaviour
{
    Selectable selectable;

    private void Awake() {
        selectable = GetComponent<Selectable>();
    }

    private void OnEnable() {   
        selectable.Select();
    }
}
