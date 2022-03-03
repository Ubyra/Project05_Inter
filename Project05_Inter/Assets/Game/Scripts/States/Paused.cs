using System.Collections;
using UnityEngine;

public class Paused : GameState
{
    public Paused(GameSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Game is Paused.");
        Game.pauseComponents.pauseBgAnim.gameObject.SetActive(true);
        Game.pauseComponents.pauseBgAnim.Play("Start");
        Time.timeScale = 0;
        yield break;
    }

    public override void Pause()
    {
        Game.pauseComponents.pauseBgAnim.Play("Leave");
        Time.timeScale = 1;
        Game.SetState(new Running(Game));
    }
}
