using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Command
{
    public Command()
    {}

    public virtual void Execute()
    {}
}

public class PumpCommand : Command
{
    /*protected*/
    Animator _aAnimator;
    public PumpCommand(Animator _aAnimator) : base()
    {
        this._aAnimator = _aAnimator;
    }

    public override void Execute()
    {
        _aAnimator.Play("PUMPING IRON");
    }
}

public class AddPointCommand : Command
{
    int _iPointsToAdd = 1;
    public AddPointCommand() : base()
    {}

    public AddPointCommand(int pointsToAdd) : base() 
    {
        _iPointsToAdd = pointsToAdd;
    }

    public override void Execute()
    {
        PointsData.iPoints += 1;
    }
}

public class UpdatePoints : Command
{
    TMP_Text _text;

    public UpdatePoints(TMP_Text _text) : base() 
    { 
        this._text = _text;
    }

    public override void Execute()
    {
        _text.text = PointsData.iPoints.ToString();
    }


}

public class PlayAudioCommand : Command
{
    private SFXAudioClip[] _xAudioClips;
    private AudioClip _xAudioClip;
    private float _fVolume;
    private bool _bIsMultipleClips;
    private float _fTimeOfPress;
    public PlayAudioCommand(AudioClip _xAudioClip,float _fVolume) : base()
    {
        this._xAudioClip = _xAudioClip;
        this._fVolume = _fVolume;
        _bIsMultipleClips = false;
    }
    public PlayAudioCommand(SFXAudioClip[] audioClips ) : base()
    {
        _xAudioClips = audioClips;
        _bIsMultipleClips = true;
    }
    public override void Execute()
    {
        if (Time.time - _fTimeOfPress < 1f)
        {
            return;
        }
            _fTimeOfPress = Time.time;

        if (_bIsMultipleClips)
        {
            AudioManager.instance.PlayRandomSFX(_xAudioClips);
            return;
        }

        AudioManager.instance.PlaySFX(_xAudioClip,_fVolume);
        
    }
}

public class GetCommand : Command
{
    public Action aOnExecute;

    public GetCommand(Action aOnExecute) : base()
    {
        this.aOnExecute = aOnExecute;
    }

    public override void Execute()
    {
        aOnExecute?.Invoke();
    }
}


