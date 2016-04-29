using UnityEngine;
using System.Collections;

public interface Observerable  {

    //Declare Observers Specific because this Observerable may Handle other Observers Type
     void registerBallMovementObserver(BallMovementObserver observer);
     void notifyBallMovementObservers(float newX,float newY,float newVelocity);
}
