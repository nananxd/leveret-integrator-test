using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;
    [SerializeField] Button timelineButton; 

    private bool isTimelinePlaying = false;

    private void Start()
    {
        timelineButton.interactable = true;
    }

    private void OnEnable()
    {
        timeline.played += OnTimelinePlayed;
        timeline.stopped += OnTimelineStopped;
    }

    private void OnDisable()
    {
        timeline.played -= OnTimelinePlayed;
        timeline.stopped -= OnTimelineStopped;
    }

    public void TimelineButtonTapped()
    {
        if (!isTimelinePlaying)
        {
            timeline.Play();
            timelineButton.interactable = false;
        }
    }

    private void OnTimelinePlayed(PlayableDirector director)
    {
        isTimelinePlaying = true;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        isTimelinePlaying = false;
        StartCoroutine(EnableButtonAfterTimeline());
    }

    private System.Collections.IEnumerator EnableButtonAfterTimeline()
    {
        yield return null;
        timelineButton.interactable = true;
    }
}
