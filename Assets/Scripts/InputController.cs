using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Gravity Inverted");
            // invert gravity
        }
    }
}
