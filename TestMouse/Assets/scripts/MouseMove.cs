using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float speed = 3f;
    public PressedButton LeftButton;
    public PressedButton RightButton;
    public PressedButton ForwardButton;
    public PressedButton BackwardButton;
    Transform trans;
    Animator anim;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftButton.isPressed)
        {
            if (!source.isPlaying) source.Play();
            trans.Rotate(-Vector3.up * speed);
            anim.SetBool("go", true);
        }
        else if (RightButton.isPressed)
        {
            if (!source.isPlaying) source.Play();
            trans.Rotate(Vector3.up * speed);
            anim.SetBool("go", true);
        }
        else if (ForwardButton.isPressed)
        {
            if (!source.isPlaying) source.Play();
            trans.position += trans.forward * speed / 2 * Time.deltaTime;
            anim.SetBool("go", true);
        }
        else if (BackwardButton.isPressed)
        {
            trans.position -= trans.forward * speed / 2 * Time.deltaTime;
            anim.SetBool("go", true);
        }

        else { anim.SetBool("go", false);
            if (source.isPlaying) source.Pause(); }
    }
}
