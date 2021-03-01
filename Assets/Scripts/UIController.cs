using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnAngleValue(float angle)
    {
        Messenger<float>.Broadcast(GameEvent.ANGLE_CHANGED, angle);
    }
    public void OnRedClick()
    {
        Messenger.Broadcast(GameEvent.RED_CLICK);
    }
    public void OnYellowClick()
    {
        Messenger.Broadcast(GameEvent.RUN);
    }
}
