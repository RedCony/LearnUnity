using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventReceiver : MonoBehaviour
{
    public UnityEvent<string> triggerAnimationEvent = new UnityEvent<string>();

    public void OnTriggerAnimation(string eventName)
    {
        Debug.LogFormat("eventName: {0}", eventName);

        triggerAnimationEvent.Invoke(eventName);
    }
}
