using UnityEngine;

public class Dragon : MonoBehaviour
{
    private bool _alreadyEnding;
    private float _animationTime;

    private GameObject _meteor;
    private PlayerMovement _movement;

    private bool _shouldCreateMeteor;
    private bool _shouldMeteorFall;
    public float MeteorSpeed = 0.1f;

    public bool MountDragon;

    public GameObject Player;

    // Use this for initialization
    private void Start()
    {
        _animationTime = 0;
        MountDragon = false;

        _shouldCreateMeteor = true;
        _shouldMeteorFall = false;

        _meteor = GameObject.Find("Meteor");
        _meteor.transform.position = new Vector3(443, 211, 0);


        _meteor.SetActive(false);

        _movement = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (MountDragon)
        {
            OnMountDragon();
        }
        else
        {
            if (Player.transform.position.y < 206 && Player.transform.position.x > 438.5) OnMeteor();
            if (Player.transform.position.x <= 438.5) _shouldCreateMeteor = true;
        }
    }

    private void OnMeteor()
    {
        if (_shouldCreateMeteor)
        {
            GetComponent<Animator>().SetTrigger("CastMeteor");

            _meteor.SetActive(true);
            _meteor.transform.position = new Vector3(443, 211, 0);

            _shouldCreateMeteor = false;
            _shouldMeteorFall = true;
        }

        if (_shouldMeteorFall)
            if (_meteor.transform.position.y < 204.5)
            {
                _movement.pushed = true;
                _movement.PushAway(new Vector2(-17, 5));
                _meteor.transform.position = new Vector3(443, 211, 0);
                _meteor.SetActive(false);
                _shouldMeteorFall = false;
            }
            else
            {
                _meteor.transform.position += new Vector3(-MeteorSpeed, -2 * MeteorSpeed, 0);
            }
    }

    private void OnMountDragon()
    {
        if (_animationTime == 0)
        {
            GetComponent<Animator>().SetTrigger("GodBattle");
            _animationTime += Time.deltaTime;
        }
        else
        {
            if (_animationTime > 13 && !_alreadyEnding)
            {
                _alreadyEnding = true;

                Debug.Log("Did mount!");
                GameObject.Find("DidMountReaction").GetComponent<ReactionCollection>().React();
                Destroy(GameObject.Find("Flufflekins"), 1);
            }

            _animationTime += Time.deltaTime;
        }
    }
}