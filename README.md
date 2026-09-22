# AI-Keeper-Alpha

An artificial intelligence project for Unity featuring a cube goalkeeper trained to intercept moving balls using **Unity ML-Agents** and **Proximal Policy Optimization (PPO)**.

## Technical Stack
* **Game Engine:** Unity 2021+
* **AI Framework:** Unity ML-Agents 1.1.0
* **Deep Learning Backend:** PyTorch 2.1.2 (CPU)
* **Environment Platform:** Python 3.10.11

---

## Agent Logic & Observations

The `KeeperAgent` component controls horizontal movement along the X-axis. Frame-by-frame, it collects **3 vector observations**:
1. Agent's own X position (`transform.position.x`)
2. Ball's relative X position (`ballTransform.position.x`)
3. Ball's distance along the Z-axis (`ballTransform.position.z`)

### Reward System Matrix:
* **`+1.0f`** — Granted instantly upon collision with the soccer ball prefab (successful save).
* **`-1.0f`** — Granted when the ball enters the inner gate trigger collider (conceded goal).

---

## Environment Deployment Guide (via Windows CMD)

To install dependencies inside an isolated virtual environment (`ml_env`) on clean local storage:

```bash
cd C:\AI_keeper
py -3.10 -m venv ml_env
ml_env\Scripts\activate

# Install precise, conflict-free package versions
pip install torch==2.1.2 numpy==1.23.5 protobuf==3.20.3 mlagents==1.1.0 --no-deps

# Launch the PPO trainer with a x10 simulation warp speed
mlagents-learn --run-id=KeeperAlpha_1 --time-scale=10 --force --env-args --communication-timeout 300
```

---

## Autonomous Inference Mode
Once the training session concludes, the generated policy weights file **`KeeperLearning.onnx`** must be moved to the Unity `Assets` folder and assigned to the `Model` slot within the `Behavior Parameters` component. 

Switch the `Behavior Type` parameter to **Inference Only** to enable local, autonomous AI execution without an active Python connection.
