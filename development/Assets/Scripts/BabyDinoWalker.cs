using UnityEngine;

/// <summary>
/// 아기공룡이 지면 위를 무작위 목적지로 걸어 다니며, 다리·팔·꼬리·머리를 절차적으로 흔드는 컴포넌트.
/// 부위 이름은 Blender 원본(design/work.blend, "Baby Dino" 컬렉션)과 같아야 한다.
/// </summary>
public class BabyDinoWalker : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 0.9f;
    public float turnSpeed = 200f;
    public float wanderRadius = 4f;
    public Vector2 pauseRange = new Vector2(0.4f, 1.4f);
    public float arriveDistance = 0.15f;

    [Header("걸음 애니메이션")]
    public float stepFrequency = 2.4f;
    public float legSwing = 32f;
    public float armSwing = 24f;
    public float tailSway = 16f;
    public float headNod = 4f;
    public float bobHeight = 0.03f;

    Transform legL, legR, armL, armR, tailA, tailB, head;
    Quaternion legLBase, legRBase, armLBase, armRBase, tailABase, tailBBase, headBase;
    Vector3 origin;
    Vector3 target;
    float phase;
    float walkBlend;
    float pauseTimer;
    bool walking;

    void Awake()
    {
        legL = Find("Leg_L"); legR = Find("Leg_R");
        armL = Find("Arm_L"); armR = Find("Arm_R");
        tailA = Find("Tail_A"); tailB = Find("Tail_B");
        head = Find("Head");
        legLBase = Base(legL); legRBase = Base(legR);
        armLBase = Base(armL); armRBase = Base(armR);
        tailABase = Base(tailA); tailBBase = Base(tailB);
        headBase = Base(head);
        origin = transform.position;
    }

    void Start()
    {
        PickTarget();
    }

    Transform Find(string partName)
    {
        foreach (var t in GetComponentsInChildren<Transform>(true))
            if (t.name == partName) return t;
        Debug.LogWarning($"[BabyDinoWalker] '{partName}' 부위를 찾지 못했습니다.", this);
        return null;
    }

    static Quaternion Base(Transform t) => t != null ? t.localRotation : Quaternion.identity;

    void PickTarget()
    {
        Vector2 p = Random.insideUnitCircle * wanderRadius;
        target = origin + new Vector3(p.x, 0f, p.y);
        walking = true;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 to = target - transform.position;
        to.y = 0f;

        if (walking)
        {
            if (to.magnitude <= arriveDistance)
            {
                walking = false;
                pauseTimer = Random.Range(pauseRange.x, pauseRange.y);
            }
            else
            {
                Quaternion want = Quaternion.LookRotation(to.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, want, turnSpeed * dt);
                float facing = Vector3.Angle(transform.forward, to);
                if (facing < 45f)
                    transform.position += transform.forward * (moveSpeed * dt);
            }
        }
        else
        {
            pauseTimer -= dt;
            if (pauseTimer <= 0f) PickTarget();
        }

        walkBlend = Mathf.MoveTowards(walkBlend, walking ? 1f : 0f, dt * 5f);
        phase += dt * stepFrequency * Mathf.PI * 2f * walkBlend;
        Animate();
    }

    void Animate()
    {
        float s = Mathf.Sin(phase);
        float k = walkBlend;

        Rotate(legL, legLBase, Vector3.right, s * legSwing * k);
        Rotate(legR, legRBase, Vector3.right, -s * legSwing * k);
        Rotate(armL, armLBase, Vector3.right, -s * armSwing * k);
        Rotate(armR, armRBase, Vector3.right, s * armSwing * k);
        Rotate(tailA, tailABase, Vector3.up, Mathf.Sin(phase * 0.5f) * tailSway * k + Mathf.Sin(Time.time * 1.5f) * 3f);
        Rotate(tailB, tailBBase, Vector3.up, Mathf.Sin(phase * 0.5f - 0.8f) * tailSway * 0.8f * k);
        Rotate(head, headBase, Vector3.right, Mathf.Sin(phase * 2f) * headNod * k);

        Vector3 pos = transform.position;
        pos.y = origin.y + Mathf.Abs(Mathf.Sin(phase)) * bobHeight * k;
        transform.position = pos;
    }

    static void Rotate(Transform t, Quaternion baseRot, Vector3 axis, float angle)
    {
        // FBX 변환으로 일부 부위에 기본 회전(예: 90°)이 생기므로, 부모 좌표계 기준으로 회전을 곱한다.
        if (t != null) t.localRotation = Quaternion.AngleAxis(angle, axis) * baseRot;
    }
}
