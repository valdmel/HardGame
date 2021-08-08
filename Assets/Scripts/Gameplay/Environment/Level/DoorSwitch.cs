using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Door Switch Properties")]
    [SerializeField] private GameObject doorBodyObjectToOpen;
    #endregion

    private bool isSwitchPressed = false;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => PlayerBody.OnPlayerDeath += ResetSwitch;

    private void OnDisable() => PlayerBody.OnPlayerDeath -= ResetSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody() && !isSwitchPressed)
        {
            ActivateSwitch();
            doorBodyObjectToOpen.GetComponent<Door>().Open();
        }
    }
    #endregion

    #region CLASS METHODS
    private void ActivateSwitch() => isSwitchPressed = true;

    private void ResetSwitch() => isSwitchPressed = false;
    #endregion
}
