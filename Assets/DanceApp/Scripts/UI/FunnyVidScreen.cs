using System;
using ABCBoard.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class FunnyVidScreen : BaseScreenWithModel<IDModel>
{
    private int _bookID;

    [SerializeField] private VideoPlayer _video;

    // [SerializeField] private Image _name;
    [SerializeField] private Button _buttonPlay;

    void Start()
    {
        _buttonPlay?.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        AudioManager.Instance.ClickSound();
        //  AudioManager.Instance.PlaySong(_bookID);
        _video.Play();
    }

    public override void BindData(IDModel model)
    {
        _bookID = model.songID;
        SetImage();
    }

    private void SetImage()
    {
        var songSo = GameDataManager.Instance.cardSo;
        //_name.sprite = songSo.GetBookWithID(_bookID).icon;
        _video.clip = songSo.GetBookWithID(_bookID).clip;
        OnClickButton();
    }

    public override void Remove()
    {
        _video.Stop();
        base.Remove();
    }

    public override ScreenType GetID() => ScreenType.FunnyVideo;
}

public class IDModel
{
    public int songID;
}