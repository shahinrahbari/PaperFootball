using UnityEngine;
using System.Collections;

public interface BallMovementObserver  {

    void updatePosition(float new_x, float new_y,float velocity);
}
