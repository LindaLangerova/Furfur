using UnityEngine;
using UnityEngine.UI;

public class BossFightC : MonoBehaviour
{
    private const int BOSS_LIVES = 20;
    private GameObject _boss;
    private BoxCollider2D _bossBoxCollider;

    private Rigidbody2D _bossRigidbody;

    public BulletCreator _bulletCreator;


    private Inventory _inventory;

    private GameObject _player;

    private BoxCollider2D _playerBoxCollider;

    private Slider _slider;
    public bool _stopped = true;

    private Animator BossAnimator;
    public float BossMovement = -0.5f;
    public Sprite BulletSprite;


    // Use this for initialization
    private void Start()
    {
        _player = GameObject.Find("Player");
        _boss = GameObject.Find("NullTerminator");
        BossAnimator = _boss.GetComponent<Animator>();

        _playerBoxCollider = _player.GetComponent<BoxCollider2D>();
        _bossBoxCollider = _boss.GetComponent<BoxCollider2D>();
        _bossRigidbody = _boss.GetComponent<Rigidbody2D>();


        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _slider.maxValue = BOSS_LIVES;
        _slider.value = BOSS_LIVES;
    }

    // Update is called once per frame
    private void Update()
    {
        BossAnimator.SetFloat("velocity", BossMovement);

        if (_player.transform.position.y < 212 && !_stopped)
            OnLost();

        if (_bossBoxCollider.IsTouching(_playerBoxCollider))
            OnCollision();
        if (Input.GetKeyDown(KeyCode.C))
            OnShot();
        if (_slider.value <= 0)
            OnWin();
        if (_stopped) BossMovement = 0;
        else BossMovement = -0.5f;
        if (_player.transform.position.y > 213 && _player.transform.position.x > 434 && _stopped)
            OnBossFightStart();
        if (_boss.transform.position.x < 65)
            OnLost();
    }

    private void OnBossFightStart()
    {
        _stopped = false;
    }

    private void OnCollision()
    {
        var movement = _player.GetComponent<PlayerMovement>();
        movement.pushed = true;
        movement.PushAway(new Vector2(-4, 15));
    }

    private void OnShot()
    {
        if (_inventory.ContainsItems())
        {
            SoundManager.PlayShootSound();
            _inventory.RemoveLast();
            _bulletCreator.SetBullet(_player.transform.position, _playerBoxCollider);
        }
    }

    private void FixedUpdate()
    {
        _bossRigidbody.velocity = new Vector3(BossMovement, 0, 0);
    }

    private void OnWin()
    {
        GameObject.Find("UIText").GetComponent<Text>().text = "";
        GameObject.Find("Terminal").GetComponent<BoxCollider2D>().enabled = false;

        while (_inventory.ContainsItems())
            _inventory.RemoveLast();

        GameObject.Find("WinReaction").GetComponent<ReactionCollection>().React();
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        _stopped = true;
        BossMovement = 0;
        Destroy(_boss, 9.5f);
        enabled = false;
    }

    private void OnLost()
    {
        GameObject.Find("LoseReaction").GetComponent<ReactionCollection>().React();
        _boss.GetComponent<Rigidbody2D>().position = new Vector2(439, 215);
        _stopped = true;
        BossAnimator.SetFloat("velocity", 0);
        _slider.value = BOSS_LIVES;
        enabled = false;
    }
}