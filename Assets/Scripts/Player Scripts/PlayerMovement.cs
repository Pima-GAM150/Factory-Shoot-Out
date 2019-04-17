using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun, IPunObservable
{
    public float speed
    {
        get { return _speed; }
        set { _speed = value; print("Set speed to " + value); }
    }
    float _speed;
    public float gameSpeed;

    public float lerpSpeed;

    public Sprite Crown;
    public PlayerAppearance appearance;
    Vector3 lastSynchedPos;

    public Rigidbody2D body;
    public CapsuleCollider2D Player;
    public bool alive { get; set; }

    void Start()
    {
        appearance.skin.transform.position = body.transform.position;
        appearance.skin.animator.SetBool("Shoot", false);
        Player.enabled = true;
        alive = true;
        // gameSpeed = gameObject.GetComponent<OptionsSettings>().setSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //GetComponent<KeyBindings>().keys["Up"].ToString()
        //GetComponent<KeyBindings>().keys["Down"].ToString()
        //GetComponent<KeyBindings>().keys["Left"].ToString()
        //GetComponent<KeyBindings>().keys["Right"].ToString()
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal") * speed;
            float y = Input.GetAxis("Vertical") * speed;

            body.velocity = new Vector2(x, y);
            
            appearance.skin.transform.position = body.transform.position;
        }
        else
        {
            appearance.skin.transform.position = Vector3.Lerp(appearance.skin.transform.position, body.transform.position, lerpSpeed);
        }
    }

    public void OnPhotonSerializeView( PhotonStream stream, PhotonMessageInfo info)
    {
        if( stream.IsWriting)
        {
            stream.SendNext(body.transform.position);
        }
        else
        {
            body.transform.position = (Vector3)stream.ReceiveNext();
        }
    }

    public void Hit()
    {
        FindObjectOfType<Audiomanager>().Play("Death");
        Player.enabled = false;
        gameSpeed = 0;
        speed = 0;
        alive = false;
        appearance.skin.animator.SetBool("Dead", true);

        int playersLeftAlive = 0;
        PlayerMovement lastPlayerAlive = null;
        foreach( PhotonView player in NetworkedObjects.find.Players ) {

            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if( playerMovement.alive ) {
                lastPlayerAlive = playerMovement;
                playersLeftAlive++;
            }
        }

        if( playersLeftAlive == 1 ) {
            DeclareWinner( lastPlayerAlive );
        }
    }

    void DeclareWinner( PlayerMovement player ) {

        if( player.photonView.IsMine ) {
            // add score
            FindObjectOfType<Audiomanager>().Play("Victory");
            BigCrown();
            int wins = PlayerPrefs.GetInt( "wins", 0 );
            PlayerPrefs.SetInt( "wins", wins + 1 );
 
        }
        else {
            // and lose screen to losers
        }

        // could reload scene here or load next map:
        if( PhotonNetwork.IsMasterClient ) {
            PlayerPrefs.SetInt( "nextLevel", 3 );
            PhotonNetwork.LoadLevel( 7 );
        }
    }

    void BigCrown()
    {
        photonView.RPC("SpawnCrown", RpcTarget.All);
    }
    [PunRPC]
    public void SpawnCrown()
    {
        Instantiate(Crown);
    }
}
