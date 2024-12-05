using UnityEngine;

[System.Serializable]
public class DelaySystem : FeatureSystem
{
    public float fDelayTimerInSeconds;
    private float _fDelayTimer;


    public delegate void DelayAction(float RangeForm0To1);

    public DelayAction xOnDelayTimerChanged;

    public override void Inanziate()
    {
        ButtonsData.xPumpButton.AddCommand(new GetCommand(ResetDelayTimer));
        ResetDelayTimer();
    }
    public override void ExecuteUpdate()
    {
        if(_fDelayTimer <= 0)
        {
            aOnFinishedExecute?.Invoke();
            return;
        }

        _fDelayTimer -= Time.deltaTime;
        xOnDelayTimerChanged?.Invoke(_fDelayTimer/fDelayTimerInSeconds);
    }

    void ResetDelayTimer()
    {
        _fDelayTimer = fDelayTimerInSeconds;
    }

    public override void Reset()
    {
        ResetDelayTimer();
        xOnDelayTimerChanged -= xOnDelayTimerChanged;
        aOnFinishedExecute -= aOnFinishedExecute;
        xOnDelayTimerChanged = null;
        aOnFinishedExecute = null;
    }
}
