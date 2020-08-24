using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GetVideoURL : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Get_Stick_Bugged_lol.mp4");
        videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
        videoPlayer.Play();
    }

}
