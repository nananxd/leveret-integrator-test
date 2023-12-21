using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;

    public void TimelineButtonTapped()
    {
        timeline.Play();
    }
}